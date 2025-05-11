using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Go
{
    public partial class Main : Form
    {        
        private readonly OleDbConnection con = new OleDbConnection(
    $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.accdb")}");
        private OleDbCommand cmd;
        private string loggedInUser;
        private Dashboard ucDashboard;
        private Analytics ucAnalytics;
        private Workout ucWorkout;
        private MealPrep ucMealPrep;
        private GymLoc ucGymLoc;
        private SetGoal ucSetGoal;
        private Meals ucMeals;
        public Main(string username)
        {
            InitializeComponent();
            loggedInUser = username; 
            cmd = new OleDbCommand();
            LoadUserInfo();
            if (ucWorkout == null) ucWorkout = new Workout();
            LoadUserControl(ucWorkout);
        }        
        private void LoadUserInfo()
        {
            try
            {
                con.Open();
                string query = "SELECT username, profilePic FROM tblUser WHERE username = ?";
                cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("?", loggedInUser.Trim());
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usernamelbl.Text = reader["username"].ToString();                   
                    if (!reader.IsDBNull(reader.GetOrdinal("profilePic")))
                    {
                        object picValue = reader["profilePic"];
                        if (picValue is byte[])
                        {                            
                            byte[] imageData = (byte[])picValue;
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else if (picValue is string)
                        {                            
                            string base64String = (string)picValue;
                            byte[] imageData = Convert.FromBase64String(base64String);
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        private void LoadUserControl(UserControl uc)
        {
            if (panelContainer == null) return;
            panelContainer.Controls.Clear(); 
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }      
        private void analyticsbtn_Click(object sender, EventArgs e)
        {
            if (ucAnalytics == null) ucAnalytics = new Analytics();
            LoadUserControl(ucAnalytics);
        }
        private void workoutbtn_Click(object sender, EventArgs e)
        {
            if (ucWorkout == null) ucWorkout = new Workout();
            LoadUserControl(ucWorkout);
        }
        private void mealprepbtn_Click(object sender, EventArgs e)
        {
            if (ucMeals == null) ucMeals = new Meals();
            LoadUserControl(ucMeals);
        }
        private void gymlocbtn_Click(object sender, EventArgs e)
        {
            if (ucGymLoc == null) ucGymLoc = new GymLoc();
            LoadUserControl(ucGymLoc);
        }       
        private void logoutbtn_Click(object sender, EventArgs e)
        {            
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                                                  "Logout",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {               
                Register loginForm = new Register();
                loginForm.Show();
                this.Close();
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Profile Picture";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image selectedImage = Image.FromFile(ofd.FileName);
                    pictureBox1.Image = selectedImage;
                    byte[] imageBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        selectedImage.Save(ms, selectedImage.RawFormat);
                        imageBytes = ms.ToArray();
                    }
                    try
                    {
                        con.Open();
                        string updateQuery = "UPDATE tblUser SET profilePic = ? WHERE username = ?";
                        using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, con))
                        {                           
                            OleDbParameter param = updateCmd.Parameters.Add("?", OleDbType.Binary);
                            param.Value = imageBytes;

                            updateCmd.Parameters.Add("?", OleDbType.VarChar).Value = loggedInUser;
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
