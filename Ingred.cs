using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace Go
{
    public partial class Ingred : UserControl
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\users.accdb";
        private DataTable dtIngredients = new DataTable();
        private DataTable dtSelected = new DataTable();
        private int currentMealID = -1;
        public Ingred()
        {
            InitializeComponent();
            InitializeSelectedTable();
            SetupEventHandlers();
            LoadIngredients();
            mealDate.Value = DateTime.Today;
        }
        private void SetupEventHandlers()
        {
            Ingredientdgv.CellDoubleClick += Ingredientdgv_CellDoubleClick;
            txtSearchIngredient.TextChanged += txtSearchIngredient_TextChanged;
            Selecteddgv.SelectionChanged += Selecteddgv_SelectionChanged;
        }
        private void InitializeSelectedTable()
        {          
            dtSelected.Columns.Add("MealIngredientID", typeof(int));
            dtSelected.Columns.Add("IngredientID", typeof(int));
            dtSelected.Columns.Add("IngredientName", typeof(string));
            dtSelected.Columns.Add("Grams", typeof(decimal));
            dtSelected.Columns.Add("CaloriesPer100g", typeof(decimal));
            dtSelected.Columns.Add("CalculatedCalories", typeof(decimal), "Grams * CaloriesPer100g / 100");            
            Selecteddgv.DataSource = dtSelected;
            
            ConfigureDataGridView(Selecteddgv, new[] { "MealIngredientID", "IngredientID", "CaloriesPer100g" });
           
            Selecteddgv.Columns["CalculatedCalories"].DefaultCellStyle.Format = "N1";
            Selecteddgv.Columns["Grams"].DefaultCellStyle.Format = "N1";
        }
        private void ConfigureDataGridView(DataGridView dgv, string[] hiddenColumns)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;

            foreach (string col in hiddenColumns)
            {
                if (dgv.Columns.Contains(col))
                {
                    dgv.Columns[col].Visible = false;
                }
            }            
            if (dgv == Selecteddgv)
            {
                dgv.Columns["IngredientName"].DisplayIndex = 0;
                dgv.Columns["Grams"].DisplayIndex = 1;
                dgv.Columns["CalculatedCalories"].DisplayIndex = 2;
            }
        }
        private void LoadIngredients()
        {
            try
            {
                using (var connection = new OleDbConnection(connectionString))
                using (var da = new OleDbDataAdapter(
                    "SELECT IngredientID, IngredientName, CaloriesPer100g FROM tblIngredients ORDER BY IngredientName",
                    connection))
                {
                    dtIngredients.Clear();
                    da.Fill(dtIngredients);
                    Ingredientdgv.DataSource = dtIngredients;
                    ConfigureDataGridView(Ingredientdgv, new[] { "IngredientID" });
                    SetupSearchAutoComplete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ingredients: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupSearchAutoComplete()
        {
            txtSearchIngredient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchIngredient.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (DataRow row in dtIngredients.Rows)
            {
                autoCompleteCollection.Add(row["IngredientName"].ToString());
            }
            txtSearchIngredient.AutoCompleteCustomSource = autoCompleteCollection;
        }
        private void txtSearchIngredient_TextChanged(object sender, EventArgs e)
        {
            if (dtIngredients != null)
            {
                string searchText = txtSearchIngredient.Text.ToLower();
                DataView dv = dtIngredients.DefaultView;
                dv.RowFilter = string.IsNullOrEmpty(searchText)
                    ? ""
                    : $"IngredientName LIKE '*{searchText}*'";
            }
        }
        private void Selecteddgv_SelectionChanged(object sender, EventArgs e)
        {
            if (Selecteddgv.SelectedRows.Count > 0)
            {
                txtGrams.Text = Selecteddgv.SelectedRows[0].Cells["Grams"].Value?.ToString() ?? "";
            }
        }
        private void AddSelectedIngredient()
        {
            if (Ingredientdgv.SelectedRows.Count == 0) return;

            DataGridViewRow row = Ingredientdgv.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["IngredientID"].Value);
            string name = row.Cells["IngredientName"].Value.ToString();
            decimal caloriesPer100g = Convert.ToDecimal(row.Cells["CaloriesPer100g"].Value);

            // Check if ingredient already exists
            if (dtSelected.AsEnumerable().Any(r => Convert.ToInt32(r["IngredientID"]) == id))
            {
                MessageBox.Show($"{name} is already added.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dtSelected.Rows.Add(-1, id, name, 100, caloriesPer100g);
            UpdateTotalCalories();
            txtSearchIngredient.Clear();
        }
        private void UpdateGramValues()
        {
            if (Selecteddgv.SelectedRows.Count == 0 || !decimal.TryParse(txtGrams.Text, out decimal grams) || grams <= 0)
            {
                MessageBox.Show("Please select an ingredient and enter valid grams.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow row = Selecteddgv.SelectedRows[0];
            row.Cells["Grams"].Value = grams;
            UpdateTotalCalories();
            txtGrams.Clear();
        }
        private void RemoveSelectedIngredient()
        {
            if (Selecteddgv.SelectedRows.Count == 0) return;

            var confirm = MessageBox.Show("Remove selected ingredient?", "Confirm",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Selecteddgv.Rows.Remove(Selecteddgv.SelectedRows[0]);
                UpdateTotalCalories();
            }
        }
        private void UpdateTotalCalories()
        {
            decimal total = 0;
            foreach (DataRow row in dtSelected.Rows)
            {
                if (row["CalculatedCalories"] != DBNull.Value)
                {
                    total += Convert.ToDecimal(row["CalculatedCalories"]);
                }
            }
            lbltotalCal.Text = $"Total Calories: {total:N1}";
        }
        private bool ValidateMeal()
        {
            if (dtSelected.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(MealTypecmbo.Text))
            {
                MessageBox.Show("Please select a meal type.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (DataRow row in dtSelected.Rows)
            {
                if (row["Grams"] == DBNull.Value || Convert.ToDecimal(row["Grams"]) <= 0)
                {
                    MessageBox.Show("All ingredients must have grams > 0", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private bool SaveMealData()
        {
            try
            {
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {                            
                            if (currentMealID == -1)
                            {
                                currentMealID = CreateMeal(connection, transaction);
                            }
                            else
                            {
                                UpdateMeal(connection, transaction);
                            }                           
                            SyncMealIngredients(connection, transaction);

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Save failed: {ex.Message}", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private int CreateMeal(OleDbConnection connection, OleDbTransaction transaction)
        {
            const string query = @"INSERT INTO tblMeals (UserID, MealType, MealDate) 
                                 VALUES (?, ?, ?)";

            using (var cmd = new OleDbCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@p1", FormLogin.CurrentUserID);
                cmd.Parameters.AddWithValue("@p2", MealTypecmbo.Text);
                cmd.Parameters.AddWithValue("@p3", mealDate.Value.Date);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private void UpdateMeal(OleDbConnection connection, OleDbTransaction transaction)
        {
            const string query = @"UPDATE tblMeals 
                                 SET MealType = ?, MealDate = ? 
                                 WHERE MealID = ? AND UserID = ?";

            using (var cmd = new OleDbCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@p1", MealTypecmbo.Text);
                cmd.Parameters.AddWithValue("@p2", mealDate.Value.Date);
                cmd.Parameters.AddWithValue("@p3", currentMealID);
                cmd.Parameters.AddWithValue("@p4", FormLogin.CurrentUserID);
                cmd.ExecuteNonQuery();
            }
        }
        private void SyncMealIngredients(OleDbConnection connection, OleDbTransaction transaction)
        {            
            const string deleteQuery = "DELETE FROM tblMealIngredients WHERE MealID = ?";
            using (var cmd = new OleDbCommand(deleteQuery, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@p1", currentMealID);
                cmd.ExecuteNonQuery();
            }            
            const string insertQuery = "INSERT INTO tblMealIngredients (MealID, IngredientID, Grams) VALUES (?, ?, ?)";
            foreach (DataRow row in dtSelected.Rows)
            {
                using (var cmd = new OleDbCommand(insertQuery, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@p1", currentMealID);
                    cmd.Parameters.AddWithValue("@p2", row["IngredientID"]);
                    cmd.Parameters.AddWithValue("@p3", row["Grams"]);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool LoadMeal(int mealID, string mealType, DateTime date)
        {
            currentMealID = mealID;
            MealTypecmbo.Text = mealType;
            mealDate.Value = date;
            dtSelected.Clear();
            if (mealID <= 0) return true; 

            try
            {
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();                    
                    const string verifyQuery = @"SELECT 1 FROM tblMeals 
                                               WHERE MealID = ? AND UserID = ?";
                    using (var cmd = new OleDbCommand(verifyQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", mealID);
                        cmd.Parameters.AddWithValue("@p2", FormLogin.CurrentUserID);
                        if (cmd.ExecuteScalar() == null)
                        {
                            MessageBox.Show("Meal not found or access denied.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }                    
                    const string query = @"SELECT mi.MealIngredientID, mi.IngredientID, 
                                         i.IngredientName, i.CaloriesPer100g, mi.Grams
                                         FROM tblMealIngredients mi
                                         INNER JOIN tblIngredients i ON mi.IngredientID = i.IngredientID
                                         WHERE mi.MealID = ?";
                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", mealID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dtSelected.Rows.Add(
                                    reader["MealIngredientID"],
                                    reader["IngredientID"],
                                    reader["IngredientName"],
                                    reader["Grams"],
                                    reader["CaloriesPer100g"]
                                );
                            }
                        }
                    }                   
                    ConfigureDataGridView(Selecteddgv, new[] { "MealIngredientID", "IngredientID", "CaloriesPer100g" });
                    UpdateTotalCalories();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading meal: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }        
        private void btnAddIngredient_Click(object sender, EventArgs e) => AddSelectedIngredient();
        private void Ingredientdgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => AddSelectedIngredient();
        private void updateGrambtn_Click(object sender, EventArgs e) => UpdateGramValues();
        private void removeIngredientbtn_Click(object sender, EventArgs e) => RemoveSelectedIngredient();
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (ValidateMeal() && SaveMealData())
            {
                MessageBox.Show("Meal saved successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);                
                dtSelected.Clear();
                UpdateTotalCalories();
                MealTypecmbo.SelectedIndex = -1;
                mealDate.Value = DateTime.Today;
            }
        }
    }
}