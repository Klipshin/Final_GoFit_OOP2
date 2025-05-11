using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Go
{
    public partial class ManageMeal : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\users.accdb";
        public ManageMeal()
        {
            InitializeComponent();
            
            LoadData();            
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch.KeyDown += txtSearch_KeyDown;
            txtSearch.TextChanged += txtSearch_TextChanged;
        }
        private void LoadData()
        {
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM tblIngredients", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvIngredients.DataSource = dt;
            }
            LoadAutoCompleteSuggestions();
        }
        private void LoadAutoCompleteSuggestions()
        {
            AutoCompleteStringCollection autoText = new AutoCompleteStringCollection();
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "SELECT IngredientName FROM tblIngredients";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            autoText.Add(reader["IngredientName"].ToString());
                        }
                    }
                }
            }

            txtSearch.AutoCompleteCustomSource = autoText;
        }
        private void SearchIngredients(string keyword)
        {
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM tblIngredients WHERE IngredientName LIKE ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", "%" + keyword + "%");

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvIngredients.DataSource = dt;
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Optionally refresh suggestions in real time
            // LoadAutoCompleteSuggestions(); // uncomment if you want to refresh every time
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
                    SearchIngredients(searchText);
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtIngredientName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || !int.TryParse(txtCalories.Text.Trim(), out int calories))
            {
                MessageBox.Show("Please enter a valid ingredient name and numeric calorie value.");
                return;
            }
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "INSERT INTO tblIngredients (IngredientName, CaloriesPer100g) VALUES (?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", name);
                    cmd.Parameters.AddWithValue("?", calories);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            ClearFields();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvIngredients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }
            int id = Convert.ToInt32(dgvIngredients.SelectedRows[0].Cells["IngredientID"].Value);
            string name = txtIngredientName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || !int.TryParse(txtCalories.Text.Trim(), out int calories))
            {
                MessageBox.Show("Please enter a valid ingredient name and numeric calorie value.");
                return;
            }
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "UPDATE tblIngredients SET IngredientName = ?, CaloriesPer100g = ? WHERE IngredientID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", name);
                    cmd.Parameters.AddWithValue("?", calories);
                    cmd.Parameters.AddWithValue("?", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            ClearFields();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvIngredients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            int id = Convert.ToInt32(dgvIngredients.SelectedRows[0].Cells["IngredientID"].Value);

            var result = MessageBox.Show("Are you sure you want to delete this ingredient?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                string query = "DELETE FROM tblIngredients WHERE IngredientID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            ClearFields();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtIngredientName.Clear();
            txtCalories.Clear();
            txtSearch.Clear();
            dgvIngredients.ClearSelection();
            LoadData();
        }
        private void dgvIngredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvIngredients.Rows[e.RowIndex];
                txtIngredientName.Text = row.Cells["IngredientName"].Value.ToString();
                txtCalories.Text = row.Cells["CaloriesPer100g"].Value.ToString();
            }
        }
    }
}
