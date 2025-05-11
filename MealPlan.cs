using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;

namespace Go
{
    public partial class MealPlan : UserControl
    {
        private OleDbConnection con = new OleDbConnection($@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Application.StartupPath}\users.accdb");
        private DateTime currentDate;
        private decimal suggestedCalories = 0;
        public MealPlan()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            mealDate.Value = currentDate;
            InitializeDataGridViews();
            LoadSuggestedCalories();
            LoadDayMeals(currentDate);
        }
        private void LoadSuggestedCalories()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                string query = @"SELECT DailyCalorieTarget FROM tblGoals 
                              WHERE UserID = ? AND IsActive = True";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        suggestedCalories = Convert.ToDecimal(result);
                        suggestedlbl.Text = $"Suggested: {suggestedCalories:N0} kcal";
                    }
                    else
                    {
                        suggestedlbl.Text = "No active goal found";
                    }
                }
            }
            catch (Exception ex)
            {
                suggestedlbl.Text = "Error loading goal";
                MessageBox.Show("Error loading suggested calories: " + ex.Message,
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private void InitializeDataGridViews()
        {
            foreach (DataGridView dgv in new[] { dgvBreakfast, dgvLunch, dgvDinner, dgvSnacks })
            {
                dgv.AutoGenerateColumns = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.RowHeadersVisible = false;               
                dgv.Columns.Clear();
                dgv.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "IngredientName",
                    HeaderText = "Ingredient",
                    DataPropertyName = "IngredientName",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dgv.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "Grams",
                    HeaderText = "Grams",
                    DataPropertyName = "Grams",
                    DefaultCellStyle = new DataGridViewCellStyle() { Format = "N1" }
                });

                dgv.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "Calories",
                    HeaderText = "Calories",
                    DataPropertyName = "Calories",
                    DefaultCellStyle = new DataGridViewCellStyle() { Format = "N1" }
                });
            }
        }
        private void LoadDayMeals(DateTime date)
        {
            currentDate = date;
            mealDate.Value = date;

            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                LoadMealType("Breakfast", dgvBreakfast, breakfasttotlbl);
                LoadMealType("Lunch", dgvLunch, lunchtotlbl);
                LoadMealType("Dinner", dgvDinner, dinnertotlbl);
                LoadMealType("Snacks", dgvSnacks, snackstotlbl);
                CalculateDailyTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading meals: " + ex.Message,
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private void LoadMealType(string mealType, DataGridView dgv, Label totalLabel)
        {
            string query = @"SELECT i.IngredientName, mi.Grams, 
                          (i.CaloriesPer100g * mi.Grams / 100) AS Calories
                          FROM (tblMeals m INNER JOIN tblMealIngredients mi ON m.MealID = mi.MealID)
                          INNER JOIN tblIngredients i ON mi.IngredientID = i.IngredientID
                          WHERE m.MealDate = @Date AND m.MealType = @MealType AND m.UserID = @UserID";

            DataTable dt = new DataTable();
            using (OleDbCommand cmd = new OleDbCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Date", currentDate.Date);
                cmd.Parameters.AddWithValue("@MealType", mealType);
                cmd.Parameters.AddWithValue("@UserID", FormLogin.CurrentUserID);

                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            dgv.DataSource = dt;
            
            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["Calories"]);
            }
            totalLabel.Text = $"{total:N1} kcal";
        }

        private void CalculateDailyTotal()
        {
            decimal total = GetLabelValue(breakfasttotlbl) +
                           GetLabelValue(lunchtotlbl) +
                           GetLabelValue(dinnertotlbl) +
                           GetLabelValue(snackstotlbl);

            dailytotallbl.Text = $"{total:N1} kcal";

            // Update color based on comparison with suggested calories
            if (suggestedCalories > 0)
            {
                if (total > suggestedCalories * 1.1m) // More than 10% over
                {
                    dailytotallbl.ForeColor = Color.Red;
                }
                else if (total < suggestedCalories * 0.9m) // More than 10% under
                {
                    dailytotallbl.ForeColor = Color.Blue;
                }
                else // Within 10% range
                {
                    dailytotallbl.ForeColor = Color.Green;
                }
            }
        }
        private decimal GetLabelValue(Label label)
        {
            string text = label.Text.Replace(" kcal", "");
            return decimal.TryParse(text, out decimal value) ? value : 0;
        }
        private void btnPrevday_Click(object sender, EventArgs e)
        {
            LoadDayMeals(currentDate.AddDays(-1));
        }
        private void btnNextday_Click(object sender, EventArgs e)
        {
            LoadDayMeals(currentDate.AddDays(1));
        }
        private void mealDate_ValueChanged(object sender, EventArgs e)
        {
            LoadDayMeals(mealDate.Value);
        }
        private void EditMeal(string mealType)
        {
            try
            {
                int mealID = GetMealID(currentDate, mealType);
                var ingredControl = new Ingred();

                if (con.State != ConnectionState.Open)
                    con.Open();

                ingredControl.LoadMeal(mealID, mealType, currentDate);

                var form = new Form
                {
                    Text = $"{mealType} - {currentDate:d}",
                    Size = new Size(1200, 715),
                    StartPosition = FormStartPosition.CenterScreen
                };
                form.Controls.Add(ingredControl);
                ingredControl.Dock = DockStyle.Fill;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    
                    LoadDayMeals(currentDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error editing meal: " + ex.Message,
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
        private int GetMealID(DateTime date, string mealType, OleDbConnection connection = null, OleDbTransaction transaction = null)
        {
            bool useExternalConnection = connection != null;
            var localConnection = useExternalConnection ? null : new OleDbConnection(con.ConnectionString);
            try
            {
                if (!useExternalConnection)
                {
                    localConnection.Open();
                }

                string query = "SELECT MealID FROM tblMeals WHERE MealDate = @Date AND MealType = @MealType AND UserID = @UserID";

                using (var cmd = new OleDbCommand(query, useExternalConnection ? connection : localConnection, transaction))
                {
                    cmd.Parameters.AddWithValue("@Date", date.Date);
                    cmd.Parameters.AddWithValue("@MealType", mealType);
                    cmd.Parameters.AddWithValue("@UserID", FormLogin.CurrentUserID);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            finally
            {
                if (!useExternalConnection && localConnection != null)
                {
                    localConnection.Close();
                }
            }
        }
        private void btnbreakedit_Click(object sender, EventArgs e) => EditMeal("Breakfast");
        private void btnlunchedit_Click(object sender, EventArgs e) => EditMeal("Lunch");
        private void btndinneredit_Click(object sender, EventArgs e) => EditMeal("Dinner");
        private void btnsnacksedit_Click(object sender, EventArgs e) => EditMeal("Snacks");        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDayMeals(currentDate);
        }
        private void repeatbtn_Click(object sender, EventArgs e)
        {
            try
            {
               
                var result = MessageBox.Show("This will copy today's meals to the next 6 days. Continue?",
                                          "Confirm Repeat",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                   if (con.State != ConnectionState.Open)
                    con.Open();

                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        string[] mealTypes = { "Breakfast", "Lunch", "Dinner", "Snacks" };

                        foreach (string mealType in mealTypes)
                        {
                            int sourceMealID = GetMealID(currentDate, mealType, con, transaction);
                            if (sourceMealID == -1) continue;

                            var ingredients = new DataTable();
                            using (var cmd = new OleDbCommand(
                                "SELECT IngredientID, Grams FROM tblMealIngredients WHERE MealID = @MealID",
                                con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@MealID", sourceMealID);
                                using (var da = new OleDbDataAdapter(cmd))
                                {
                                    da.Fill(ingredients);
                                }
                            }                            
                            for (int i = 1; i <= 6; i++)
                            {
                                DateTime newDate = currentDate.AddDays(i);                                
                                int existingMealID = GetMealID(newDate, mealType, con, transaction);
                                if (existingMealID != -1)
                                {
                                    continue;
                                }                                
                                int newMealID = InsertMeal(newDate, mealType, con, transaction);                                
                                foreach (DataRow row in ingredients.Rows)
                                {
                                    InsertMealIngredient(newMealID,
                                        Convert.ToInt32(row["IngredientID"]),
                                        Convert.ToDecimal(row["Grams"]),
                                        con, transaction);
                                }
                            }
                        }
                        transaction.Commit();
                        MessageBox.Show("Meal plan successfully repeated for the next 6 days!",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);                        
                        LoadDayMeals(currentDate);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Transaction failed. Changes were rolled back. Error: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error repeating meal plan: {ex.Message}\n\nDetails: {ex.InnerException?.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private int InsertMeal(DateTime date, string mealType, OleDbConnection connection, OleDbTransaction transaction)
        {
            string query = @"INSERT INTO tblMeals (UserID, MealDate, MealType) 
                           VALUES (@UserID, @MealDate, @MealType)";

            using (var cmd = new OleDbCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@UserID", FormLogin.CurrentUserID);
                cmd.Parameters.AddWithValue("@MealDate", date);
                cmd.Parameters.AddWithValue("@MealType", mealType);
                cmd.ExecuteNonQuery();
            }            
            return GetMealID(date, mealType, connection, transaction);
        }
        private void InsertMealIngredient(int mealID, int ingredientID, decimal grams,
                                        OleDbConnection connection, OleDbTransaction transaction)
        {
            string query = @"INSERT INTO tblMealIngredients (MealID, IngredientID, Grams) 
                           VALUES (@MealID, @IngredientID, @Grams)";
            using (var cmd = new OleDbCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@MealID", mealID);
                cmd.Parameters.AddWithValue("@IngredientID", ingredientID);
                cmd.Parameters.AddWithValue("@Grams", grams);
                cmd.ExecuteNonQuery();
            }
        }
        private void AboutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "About - Calorie Tracking\n\n" +
                "The calorie tracking and suggestions in GoFit+ are based on:\n\n" +
                "• The Harris-Benedict Equation (for estimating daily calorie needs).\n" +
                "• Calorie reference data from https://www.calories.info/.\n\n" +
                "These references ensure the app provides accurate and reliable guidance for users.\n\n" +
                "How to Use the Calorie Chart\n\n" +
                "While the quality of food is important for a healthy diet, quantity also plays a crucial role. Regularly check a calorie database and nutrition labels " +
                "to make sure you're not consuming too many calories, as excess ones are stored as fat. It's important to balance calorie-dense foods with healthier options.\n\n" +
                "For weight loss, it's best to limit foods high in calories but low in nutrients, which are considered 'empty calories.' Choose whole foods with fewer additives.\n\n" +
                "Review the nutrition facts and make informed choices about foods that provide energy while maintaining a healthy balance of complex carbs, fats, and proteins.",
                "About GoFit+",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}