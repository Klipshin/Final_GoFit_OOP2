using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
namespace Go
{
    public partial class ManageRequest : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\users.accdb";
        int selectedLocationId = -1;
        public ManageRequest()
        {
            InitializeComponent();
            LoadRequests();
            SetupSearchAutocomplete();
            locationsdgv.CellClick += locationsdgv_CellClick;
            txtSearch.KeyDown += txtSearch_KeyDown;
        }
        private void LoadRequests(string filter = "")
        {
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "SELECT l.LocationID, l.LocationName, l.Message, l.ApprovalDate, l.RequestDate, l.UserID, u.username " +
                               "FROM tblChatLocations l " +
                               "INNER JOIN tblUser u ON l.UserID = u.UserID " +
                               "WHERE l.IsApproved = False";

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    query += " AND l.LocationName LIKE ?";
                }
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        cmd.Parameters.AddWithValue("?", "%" + filter + "%");
                    }
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    locationsdgv.DataSource = dt;
                }
            }
        }
        private void SetupSearchAutocomplete()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "SELECT LocationName FROM tblChatLocations WHERE IsApproved = False";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        collection.Add(reader["LocationName"].ToString());
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
                LoadRequests(txtSearch.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void locationsdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = locationsdgv.Rows[e.RowIndex];
                selectedLocationId = Convert.ToInt32(row.Cells["LocationID"].Value);
                txtlocationname.Text = row.Cells["LocationName"].Value.ToString();
                txtmessagerequest.Text = row.Cells["Message"].Value.ToString();
                txtrequestedby.Text = row.Cells["username"].Value.ToString();

                if (DateTime.TryParse(row.Cells["RequestDate"].Value?.ToString(), out DateTime requestDate))
                    txtrequestdate.Text = requestDate.ToShortDateString();
                else
                    txtrequestdate.Text = "N/A";
            }
        }
        private void approvebtn_Click(object sender, EventArgs e)
        {
            if (selectedLocationId == -1)
            {
                MessageBox.Show("Please select a request to approve.");
                return;
            }
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "UPDATE tblChatLocations SET IsApproved = True, ApprovalDate = ? WHERE LocationID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.Add("ApprovalDate", OleDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("LocationID", OleDbType.Integer).Value = selectedLocationId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Request approved.");
            ClearDetails();
            LoadRequests();
        }
        private void rejectbtn_Click(object sender, EventArgs e)
        {
            if (selectedLocationId == -1)
            {
                MessageBox.Show("Please select a request to reject.");
                return;
            }
            var confirm = MessageBox.Show("Are you sure you want to reject this request?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "DELETE FROM tblChatLocations WHERE LocationID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.Add("LocationID", OleDbType.Integer).Value = selectedLocationId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Request rejected.");
            ClearDetails();
            LoadRequests();
        }
        private void ClearDetails()
        {
            selectedLocationId = -1;
            txtlocationname.Clear();
            txtmessagerequest.Clear();
            txtrequestedby.Clear();
            txtrequestdate.Clear();
            locationsdgv.ClearSelection();
        }
    }
}
