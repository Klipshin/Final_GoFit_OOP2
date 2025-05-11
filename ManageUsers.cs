using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Go
{
    public partial class ManageUsers : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\users.accdb";
        public ManageUsers()
        {
            InitializeComponent();
            usersdgv.CellClick += usersdgv_CellClick;
            txtSearch.KeyDown += txtSearch_KeyDown;
            LoadUsers();
            SetupSearchAutocomplete();
        }
        private void LoadUsers()
        {
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT UserID, username, email FROM tblUser", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                usersdgv.DataSource = dt;                
                usersdgv.Columns["UserID"].Visible = false;
                usersdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            profilePic.Image = null;
            usernamelbl.Text = "";
        }
        private void SetupSearchAutocomplete()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "SELECT username FROM tblUser";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        collection.Add(reader["username"].ToString());
                    }
                }
            }
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch.AutoCompleteCustomSource = collection;
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchTerm = txtSearch.Text.Trim();

                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    string query = "SELECT UserID, username, email FROM tblUser WHERE username LIKE ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", "%" + searchTerm + "%");
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        usersdgv.DataSource = dt;
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void usersdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = usersdgv.Rows[e.RowIndex];
                int userId = Convert.ToInt32(row.Cells["UserID"].Value);
                string username = row.Cells["username"].Value.ToString();
                usernamelbl.Text = username;
                LoadUserProfilePic(userId);
            }
        }
        private void LoadUserProfilePic(int userId)
        {
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "SELECT profilePic FROM tblUser WHERE UserID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", userId);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])result;
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            profilePic.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        profilePic.Image = null;
                    }
                }
            }
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (usersdgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }
            int userId = Convert.ToInt32(usersdgv.SelectedRows[0].Cells["UserID"].Value);
            var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "DELETE FROM tblUser WHERE UserID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", userId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadUsers();
        }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}
