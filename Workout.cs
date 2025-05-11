using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace Go
{
    public partial class Workout : UserControl
    {
        private bool showingPinnedOnly = false;       
        private string ConnectionString => GetConnectionString();
        public Workout()
        {
            InitializeComponent();
            LoadWorkoutData();
            workoutdgv.CellClick += Workoutdgv_CellClick;
            UpdateButtonAppearance();
        }
        private string GetConnectionString()
        {            
            string dbPath = Path.Combine(Application.StartupPath, "users.accdb");            
            if (!File.Exists(dbPath))
            {
                dbPath = @"D:\Databases\users.accdb";
                if (!File.Exists(dbPath))
                {
                    MessageBox.Show("Database file not found. Please check the configuration.");
                    return string.Empty;
                }
            }
            return $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath}";
        }
        private void LoadWorkoutData()
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();

                    if (showingPinnedOnly)
                    {                       
                        string query = @"SELECT w.WorkoutID, w.WorkoutName, w.VideoLink 
                                        FROM tblWorkouts w
                                        INNER JOIN tblPinnedWorkouts p ON w.WorkoutID = p.WorkoutID
                                        WHERE p.UserID = ?";

                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("?", FormLogin.CurrentUserID);
                            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }                        
                        dt.Columns.Add("IsPinned", typeof(bool)).DefaultValue = true;
                    }
                    else
                    {                       
                        string allWorkoutsQuery = "SELECT WorkoutID, WorkoutName, VideoLink FROM tblWorkouts";
                        using (OleDbCommand allCmd = new OleDbCommand(allWorkoutsQuery, conn))
                        {
                            using (OleDbDataAdapter allDa = new OleDbDataAdapter(allCmd))
                            {
                                allDa.Fill(dt);
                            }
                        }                       
                        dt.Columns.Add("IsPinned", typeof(bool)).DefaultValue = false;                       
                        string pinnedQuery = "SELECT WorkoutID FROM tblPinnedWorkouts WHERE UserID = ?";
                        using (OleDbCommand pinnedCmd = new OleDbCommand(pinnedQuery, conn))
                        {
                            pinnedCmd.Parameters.AddWithValue("?", FormLogin.CurrentUserID);
                            using (OleDbDataReader pinnedReader = pinnedCmd.ExecuteReader())
                            {
                                while (pinnedReader.Read())
                                {
                                    int pinnedWorkoutID = Convert.ToInt32(pinnedReader["WorkoutID"]);
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (Convert.ToInt32(row["WorkoutID"]) == pinnedWorkoutID)
                                        {
                                            row["IsPinned"] = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    workoutdgv.DataSource = dt;                    
                    workoutdgv.Columns["WorkoutID"].Visible = false;
                    workoutdgv.Columns["VideoLink"].Visible = false;
                    workoutdgv.Columns["IsPinned"].Visible = false;
                    workoutdgv.Columns["WorkoutName"].HeaderText = "Workout";

                    UpdateButtonAppearance();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading workout data: " + ex.Message);
                }
            }
        }
        private void Workoutdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string workoutName = workoutdgv.Rows[e.RowIndex].Cells["WorkoutName"].Value.ToString();
                string videoLinkText = workoutdgv.Rows[e.RowIndex].Cells["VideoLink"].Value.ToString();
                namelbl.Text = workoutName;                
                videoLink.Text = videoLinkText;
                string embedLink = ConvertToEmbed(videoLinkText);
                webvideo.Source = new Uri(embedLink);
            }
        }
        private void btnPin_click(object sender, EventArgs e)
        {
            if (workoutdgv.CurrentRow != null)
            {
                string workoutName = workoutdgv.CurrentRow.Cells["WorkoutName"].Value.ToString();
                
                object isPinnedObj = workoutdgv.CurrentRow.Cells["IsPinned"].Value;
                bool isPinned = (isPinnedObj != null && isPinnedObj != DBNull.Value)
                              ? Convert.ToBoolean(isPinnedObj)
                              : false;

                TogglePinStatus(workoutName, !isPinned);
                LoadWorkoutData();
            }
        }
        private void TogglePinStatus(string workoutName, bool pin)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();                    
                    int workoutID = 0;
                    using (OleDbCommand getIdCmd = new OleDbCommand("SELECT WorkoutID FROM tblWorkouts WHERE WorkoutName = ?", conn))
                    {
                        getIdCmd.Parameters.AddWithValue("?", workoutName);
                        object result = getIdCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            workoutID = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Workout not found in database.");
                            return;
                        }
                    }
                    if (pin)
                    {
                        // Check if already pinned
                        using (OleDbCommand checkCmd = new OleDbCommand(
                            "SELECT COUNT(*) FROM tblPinnedWorkouts WHERE UserID = ? AND WorkoutID = ?", conn))
                        {
                            checkCmd.Parameters.AddWithValue("?", FormLogin.CurrentUserID);
                            checkCmd.Parameters.AddWithValue("?", workoutID);
                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (count == 0)
                            {
                                // Add to pinned
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO tblPinnedWorkouts (UserID, WorkoutID) VALUES (?, ?)", conn))
                                {
                                    cmd.Parameters.AddWithValue("?", FormLogin.CurrentUserID);
                                    cmd.Parameters.AddWithValue("?", workoutID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else
                    {
                        // Remove from pinned
                        using (OleDbCommand cmd = new OleDbCommand(
                            "DELETE FROM tblPinnedWorkouts WHERE UserID = ? AND WorkoutID = ?", conn))
                        {
                            cmd.Parameters.AddWithValue("?", FormLogin.CurrentUserID);
                            cmd.Parameters.AddWithValue("?", workoutID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error toggling pin status: " + ex.Message);
                }
            }
        }
        private void showpinned_click(object sender, EventArgs e)
        {
            showingPinnedOnly = true;
            LoadWorkoutData();
        }
        private void exercises_click(object sender, EventArgs e)
        {
            showingPinnedOnly = false;
            LoadWorkoutData();
        }
        private void UpdateButtonAppearance()
        {
            showpinned.BackColor = showingPinnedOnly ? SystemColors.ControlDark : SystemColors.Control;
            exercises.BackColor = showingPinnedOnly ? SystemColors.Control : SystemColors.ControlDark;

            if (workoutdgv.CurrentRow != null)
            {                
                object isPinnedObj = workoutdgv.CurrentRow.Cells["IsPinned"].Value;
                bool isPinned = (isPinnedObj != null && isPinnedObj != DBNull.Value)
                              ? Convert.ToBoolean(isPinnedObj)
                              : false;

                btnPin.Text = isPinned ? "Unpin" : "Pin";
            }
        }
        private void workoutdgv_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonAppearance();
        }
        private string ConvertToEmbed(string link)
        {
            string videoId = "";

            if (link.Contains("watch?v="))
            {
                videoId = link.Split(new[] { "v=" }, StringSplitOptions.None)[1].Split('&')[0];
            }
            else if (link.Contains("youtu.be/"))
            {
                videoId = link.Split(new[] { "youtu.be/" }, StringSplitOptions.None)[1].Split('?')[0];
            }

            return !string.IsNullOrEmpty(videoId) ?
                $"https://www.youtube.com/embed/{videoId}?autoplay=1" : link;
        }

        private void SearchWorkouts(string keyword)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    DataTable dt = new DataTable();

                    if (showingPinnedOnly)
                    {
                        string query = @"SELECT w.WorkoutID, w.WorkoutName, w.VideoLink 
                                      FROM tblWorkouts w
                                      INNER JOIN tblPinnedWorkouts p ON w.WorkoutID = p.WorkoutID
                                      WHERE p.UserID = ? AND w.WorkoutName LIKE ?";

                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("?", FormLogin.CurrentUserID);
                            cmd.Parameters.AddWithValue("?", "%" + keyword + "%");
                            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }                       
                        dt.Columns.Add("IsPinned", typeof(bool)).DefaultValue = true;
                    }
                    else
                    {                       
                        string allWorkoutsQuery = "SELECT WorkoutID, WorkoutName, VideoLink FROM tblWorkouts WHERE WorkoutName LIKE ?";
                        using (OleDbCommand allCmd = new OleDbCommand(allWorkoutsQuery, con))
                        {
                            allCmd.Parameters.AddWithValue("?", "%" + keyword + "%");
                            using (OleDbDataAdapter allDa = new OleDbDataAdapter(allCmd))
                            {
                                allDa.Fill(dt);
                            }
                        }                        
                        dt.Columns.Add("IsPinned", typeof(bool)).DefaultValue = false;                       
                        string pinnedQuery = "SELECT WorkoutID FROM tblPinnedWorkouts WHERE UserID = ?";
                        using (OleDbCommand pinnedCmd = new OleDbCommand(pinnedQuery, con))
                        {
                            pinnedCmd.Parameters.AddWithValue("?", FormLogin.CurrentUserID);
                            using (OleDbDataReader pinnedReader = pinnedCmd.ExecuteReader())
                            {
                                while (pinnedReader.Read())
                                {
                                    int pinnedWorkoutID = Convert.ToInt32(pinnedReader["WorkoutID"]);
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (Convert.ToInt32(row["WorkoutID"]) == pinnedWorkoutID)
                                        {
                                            row["IsPinned"] = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    workoutdgv.DataSource = dt;
                    workoutdgv.Columns["WorkoutID"].Visible = false;
                    workoutdgv.Columns["VideoLink"].Visible = false;
                    workoutdgv.Columns["IsPinned"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching workouts: " + ex.Message);
                }
            }
        }

        private void txtSearchWorkout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SearchOrReset();
            }
        }
        private void txtSearchWorkout_TextChanged(object sender, EventArgs e)
        {
            SearchOrReset();
        }

        private void SearchOrReset()
        {
            string searchText = txtSearchWorkout.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadWorkoutData();
            }
            else
            {
                SearchWorkouts(searchText);
            }
        }
    }
}