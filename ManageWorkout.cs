using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Go
{
    public partial class ManageWorkout : UserControl
    {
        private const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\users.accdb";
        public ManageWorkout()
        {
            InitializeComponent();
            LoadData();
            SetupAutoComplete();            
            txtSearch.KeyDown += txtSearch_KeyDown;
            txtSearch.TextChanged += txtSearch_TextChanged;
            dgvWorkouts.CellClick += dgvWorkouts_CellClick;
        }
        private void LoadData()
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                try
                {
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM tblWorkouts", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvWorkouts.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading workouts: " + ex.Message);
                }
            }
        }
        private void SetupAutoComplete()
        {
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoText = new AutoCompleteStringCollection();

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string query = "SELECT WorkoutName FROM tblWorkouts";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            autoText.Add(reader["WorkoutName"].ToString());
                        }
                    }
                }
            }

            txtSearch.AutoCompleteCustomSource = autoText;
        }
        private void SearchWorkouts(string keyword)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string query = "SELECT * FROM tblWorkouts WHERE WorkoutName LIKE ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", "%" + keyword + "%");

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvWorkouts.DataSource = dt;
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Optional: Add real-time search if desired
            // string searchText = txtSearch.Text.Trim();
            // if (!string.IsNullOrWhiteSpace(searchText))
            // {
            //     SearchWorkouts(searchText);
            // }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                string searchText = txtSearch.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    LoadData();
                }
                else
                {
                    SearchWorkouts(searchText);
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtExerciseName.Text.Trim();
            string videoLink = txtVideoLink.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(videoLink))
            {
                MessageBox.Show("Please enter both workout name and video link.");
                return;
            }
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string query = "INSERT INTO tblWorkouts (WorkoutName, VideoLink) VALUES (?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", name);
                    cmd.Parameters.AddWithValue("?", videoLink);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            ClearFields();
            SetupAutoComplete(); 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvWorkouts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a workout to update.");
                return;
            }
            int id = Convert.ToInt32(dgvWorkouts.SelectedRows[0].Cells["WorkoutID"].Value);
            string name = txtExerciseName.Text.Trim();
            string videoLink = txtVideoLink.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(videoLink))
            {
                MessageBox.Show("Please enter both workout name and video link.");
                return;
            }
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                string query = "UPDATE tblWorkouts SET WorkoutName = ?, VideoLink = ? WHERE WorkoutID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", name);
                    cmd.Parameters.AddWithValue("?", videoLink);
                    cmd.Parameters.AddWithValue("?", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            ClearFields();
            SetupAutoComplete(); 
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWorkouts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a workout to delete.");
                return;
            }

            int id = Convert.ToInt32(dgvWorkouts.SelectedRows[0].Cells["WorkoutID"].Value);

            var result = MessageBox.Show("Are you sure you want to delete this workout?",
                                      "Confirm Delete",
                                      MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                
                string deletePinnedQuery = "DELETE FROM tblPinnedWorkouts WHERE WorkoutName IN " +
                                         "(SELECT WorkoutName FROM tblWorkouts WHERE WorkoutID = ?)";
                using (OleDbCommand pinnedCmd = new OleDbCommand(deletePinnedQuery, con))
                {
                    pinnedCmd.Parameters.AddWithValue("?", id);
                    con.Open();
                    pinnedCmd.ExecuteNonQuery();
                }               
                string deleteQuery = "DELETE FROM tblWorkouts WHERE WorkoutID = ?";
                using (OleDbCommand cmd = new OleDbCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("?", id);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadData();
            ClearFields();
            SetupAutoComplete(); 
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtExerciseName.Clear();
            txtVideoLink.Clear();
            txtSearch.Clear();
            dgvWorkouts.ClearSelection();
        }
        private void dgvWorkouts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvWorkouts.Rows[e.RowIndex];
                txtExerciseName.Text = row.Cells["WorkoutName"].Value.ToString();
                txtVideoLink.Text = row.Cells["VideoLink"].Value.ToString();
            }
        }
    }
}