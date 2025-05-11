using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;

namespace Go
{
    public partial class GoalSettings : Form
    {
        private const int CuttingCalorieDeficit = 500;
        private const int BulkingCalorieSurplus = 500;

        // Method to get connection string dynamically
        private string GetConnectionString()
        {
            // Get the executable directory (bin/Debug/net8.0 or bin/Release/net8.0)
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;

            // Path to the database in the bin folder
            string dbPath = Path.Combine(executablePath, "users.accdb");

            return $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
        }

        public GoalSettings()
        {
            InitializeComponent();
            CheckAndCreateDatabasePath();
            SetupEventHandlers();
            LoadUserData();
        }

        private void CheckAndCreateDatabasePath()
        {
            try
            {
                string executablePath = AppDomain.CurrentDomain.BaseDirectory;
                string dbPath = Path.Combine(executablePath, "users.accdb");

                if (!File.Exists(dbPath))
                {
                    MessageBox.Show("Database file not found in application directory.\n" +
                                    "Please make sure 'users.accdb' is placed in the application folder.",
                                    "Database Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking database: {ex.Message}", "Error");
            }
        }

        private void SetupEventHandlers()
        {
            currentKgtxt.TextChanged += Recalculate;
            heighttxt.TextChanged += Recalculate;
            agetxt.TextChanged += Recalculate;
            malebtn.CheckedChanged += Recalculate;
            femalebtn.CheckedChanged += Recalculate;
            actlevelcmbbox.SelectedIndexChanged += Recalculate;
            fitnessgoalcmbbox.SelectedIndexChanged += Recalculate;
            targettxt.TextChanged += Recalculate;
            goaldurationtxt.TextChanged += Recalculate;
        }

        private void LoadUserData()
        {
            if (FormLogin.CurrentUserID <= 0) return;

            string connStr = GetConnectionString();

            try
            {
                using (var conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    string profileQuery = "SELECT * FROM tblUserProfile WHERE [UserID] = ?";
                    using (var profileCmd = new OleDbCommand(profileQuery, conn))
                    {
                        profileCmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        using (var reader = profileCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentKgtxt.Text = reader["Weight"].ToString();
                                heighttxt.Text = reader["Height"].ToString();
                                agetxt.Text = reader["Age"].ToString();

                                string gender = reader["Gender"].ToString();
                                malebtn.Checked = gender.Equals("Male", StringComparison.OrdinalIgnoreCase);
                                femalebtn.Checked = gender.Equals("Female", StringComparison.OrdinalIgnoreCase);

                                actlevelcmbbox.SelectedItem = reader["ActivityLevel"].ToString();
                                fitnessgoalcmbbox.SelectedItem = reader["FitnessGoal"].ToString();

                                bmiresultlbl.Text = reader["BMI"].ToString();
                                categorylbl.Text = reader["BMICategory"].ToString();
                                lblmaintainCal.Text = reader["MaintenanceCalories"].ToString();
                                cutbulkreslbl.Text = reader["GoalCalories"].ToString();
                                lblcutorbulk.Text = reader["FitnessGoal"].ToString() == "Maintain" ? "Maintain:" : $"{reader["FitnessGoal"]}:";
                            }
                        }
                    }

                    string goalQuery = "SELECT * FROM tblGoals WHERE [UserID] = ? AND [IsActive] = True";
                    using (var goalCmd = new OleDbCommand(goalQuery, conn))
                    {
                        goalCmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        using (var reader = goalCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime endDate = (DateTime)reader["GoalEndDate"];
                                if (endDate >= DateTime.Now)
                                {
                                    targettxt.Text = reader["TargetWeight"].ToString();
                                    goaldurationtxt.Text = CalculateRemainingWeeks(endDate).ToString();
                                    lbltargetbmi.Text = reader["TargetBMI"].ToString();
                                    lbltargetbmicategory.Text = reader["TargetBMICategory"].ToString();
                                }
                                else
                                {
                                    DeactivateGoal(FormLogin.CurrentUserID);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}", "Database Error");
            }
        }

        private int CalculateRemainingWeeks(DateTime endDate)
        {
            TimeSpan remaining = endDate - DateTime.Now;
            return (int)Math.Ceiling(remaining.TotalDays / 7);
        }

        private void DeactivateGoal(int userId)
        {
            string connStr = GetConnectionString();
            try
            {
                using (var conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    string updateQuery = "UPDATE tblGoals SET [IsActive] = False WHERE [UserID] = ? AND [IsActive] = True";
                    using (var cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.Add("UserID", OleDbType.Integer).Value = userId;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deactivating goal: {ex.Message}", "Database Error");
            }
        }

        private bool HasActiveGoal(int userId)
        {
            string connStr = GetConnectionString();
            try
            {
                using (var conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM tblGoals WHERE [UserID] = ? AND [IsActive] = True";
                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("UserID", OleDbType.Integer).Value = userId;
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private DateTime? GetGoalEndDate(int userId)
        {
            string connStr = GetConnectionString();
            try
            {
                using (var conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT GoalEndDate FROM tblGoals WHERE UserID = ? AND IsActive = True";
                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("UserID", OleDbType.Integer).Value = userId;
                        object result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value ? (DateTime?)result : null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private void Recalculate(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                double weight = double.Parse(currentKgtxt.Text);
                double height = double.Parse(heighttxt.Text);
                int age = int.Parse(agetxt.Text);
                string gender = malebtn.Checked ? "male" : "female";
                string activityLevel = actlevelcmbbox.SelectedItem?.ToString() ?? "";
                string fitnessGoal = fitnessgoalcmbbox.SelectedItem?.ToString() ?? "";

                double bmr = CalculateBMR(gender, age, weight, height);
                double activityFactor = GetActivityFactor(activityLevel);
                double maintenanceCalories = bmr * activityFactor;
                double dailyCalorieTarget = CalculateDailyCalorieTarget(maintenanceCalories, fitnessGoal);

                double bmi = CalculateBMI(weight, height);
                string bmiCategory = GetBMICategory(bmi);

                if (double.TryParse(targettxt.Text, out double targetWeight) && targetWeight > 0)
                {
                    double targetBmi = CalculateBMI(targetWeight, height);
                    string targetBmiCategory = GetBMICategory(targetBmi);
                    lbltargetbmi.Text = targetBmi.ToString("0.00");
                    lbltargetbmicategory.Text = targetBmiCategory;
                }
                else
                {
                    lbltargetbmi.Text = "";
                    lbltargetbmicategory.Text = "";
                }
                bmiresultlbl.Text = bmi.ToString("0.00");
                categorylbl.Text = bmiCategory;
                lblmaintainCal.Text = Math.Round(maintenanceCalories).ToString();
                cutbulkreslbl.Text = Math.Round(dailyCalorieTarget).ToString();
                lblcutorbulk.Text = fitnessGoal == "Maintain" ? "Maintain:" : $"{fitnessGoal}:";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Recalculation error: {ex.Message}", "Error");
            }
        }

        private double CalculateBMR(string gender, int age, double weight, double height)
        {
            return gender.ToLower() == "male"
                ? 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age)
                : 447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age);
        }

        private double GetActivityFactor(string activityLevel)
        {
            return activityLevel switch
            {
                "Sedentary" => 1.2,
                "Lightly active" => 1.375,
                "Moderately active" => 1.55,
                "Very active" => 1.725,
                "Extra active" => 1.9,
                _ => 1.2
            };
        }

        private double CalculateBMI(double weight, double height)
        {
            double heightM = height / 100;
            return weight / (heightM * heightM);
        }

        private string GetBMICategory(double bmi)
        {
            return bmi < 18.5 ? "Underweight" :
                   bmi < 24.9 ? "Normal" :
                   bmi < 29.9 ? "Overweight" : "Obese";
        }

        private double CalculateDailyCalorieTarget(double maintenanceCalories, string fitnessGoal)
        {
            return fitnessGoal switch
            {
                "Cutting" => maintenanceCalories - CuttingCalorieDeficit,
                "Bulking" => maintenanceCalories + BulkingCalorieSurplus,
                _ => maintenanceCalories
            };
        }

        private bool ValidateInputs()
        {
            if (currentKgtxt == null || heighttxt == null || agetxt == null)
                return false;

            if (!double.TryParse(currentKgtxt.Text, out double weight) || weight <= 0)
            {
                ClearResults();
                return false;
            }
            if (!double.TryParse(heighttxt.Text, out double height) || height <= 0)
            {
                ClearResults();
                return false;
            }
            if (!int.TryParse(agetxt.Text, out int age) || age <= 0)
            {
                ClearResults();
                return false;
            }
            if (!(malebtn.Checked || femalebtn.Checked))
            {
                ClearResults();
                return false;
            }
            if (actlevelcmbbox.SelectedIndex == -1 || fitnessgoalcmbbox.SelectedIndex == -1)
            {
                ClearResults();
                return false;
            }
            return true;
        }

        private void ClearResults()
        {
            bmiresultlbl.Text = "";
            categorylbl.Text = "";
            lblmaintainCal.Text = "";
            cutbulkreslbl.Text = "";
            lblcutorbulk.Text = "";
            lbltargetbmi.Text = "";
            lbltargetbmicategory.Text = "";
        }

        private void setbtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Please fill all fields correctly", "Validation Error");
                return;
            }

            if (!double.TryParse(targettxt.Text, out double targetWeight) || targetWeight <= 0)
            {
                MessageBox.Show("Please enter a valid target weight", "Validation Error");
                return;
            }

            if (!int.TryParse(goaldurationtxt.Text, out int durationWeeks) || durationWeeks <= 0)
            {
                MessageBox.Show("Please enter a valid goal duration in weeks", "Validation Error");
                return;
            }

            bool hasActiveGoal = HasActiveGoal(FormLogin.CurrentUserID);
            string message = hasActiveGoal
                ? "You already have an active goal. Setting a new one will override it. Are you sure?"
                : "Are you sure you want to set this goal?";

            DialogResult result = MessageBox.Show(
                message,
                "Confirm Goal Setting",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            try
            {
                double weight = double.Parse(currentKgtxt.Text);
                double height = double.Parse(heighttxt.Text);
                int age = int.Parse(agetxt.Text);
                string gender = malebtn.Checked ? "Male" : "Female";
                string activityLevel = actlevelcmbbox.SelectedItem.ToString();
                string fitnessGoal = fitnessgoalcmbbox.SelectedItem.ToString();

                double bmi = CalculateBMI(weight, height);
                string bmiCategory = GetBMICategory(bmi);
                double bmr = CalculateBMR(gender.ToLower(), age, weight, height);
                double maintenanceCalories = bmr * GetActivityFactor(activityLevel);
                double dailyCalorieTarget = CalculateDailyCalorieTarget(maintenanceCalories, fitnessGoal);
                double targetBmi = CalculateBMI(targetWeight, height);
                string targetBmiCategory = GetBMICategory(targetBmi);

                SaveUserProfile(weight, height, age, gender, activityLevel, fitnessGoal,
                               bmi, bmiCategory, maintenanceCalories, dailyCalorieTarget);

                SaveGoal(weight, targetWeight, durationWeeks, fitnessGoal, bmi, targetBmi,
                        targetBmiCategory, dailyCalorieTarget);

                MessageBox.Show("Goal set successfully!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Database Error");
            }
        }

        private void SaveUserProfile(double weight, double height, int age, string gender,
               string activityLevel, string fitnessGoal,
               double bmi, string bmiCategory,
               double maintenanceCalories, double goalCalorie)
        {
            if (FormLogin.CurrentUserID <= 0)
            {
                MessageBox.Show("Invalid UserID: " + FormLogin.CurrentUserID);
                return;
            }

            string connStr = GetConnectionString();

            using (var conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM tblUserProfile WHERE [UserID] = ?";
                    bool recordExists = false;

                    using (var checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        recordExists = (int)checkCmd.ExecuteScalar() > 0;
                    }

                    string sql;
                    if (recordExists)
                    {
                        sql = @"UPDATE tblUserProfile SET
                            [Weight] = ?,
                            [Height] = ?,
                            [Age] = ?,
                            [Gender] = ?,
                            [ActivityLevel] = ?,
                            [BMI] = ?,
                            [BMICategory] = ?,
                            [MaintenanceCalories] = ?,
                            [FitnessGoal] = ?,
                            [GoalCalories] = ?,
                            [SetDate] = ?
                        WHERE [UserID] = ?";
                    }
                    else
                    {
                        sql = @"INSERT INTO tblUserProfile
                            ([UserID], [Weight], [Height], [Age], [Gender],
                             [ActivityLevel], [BMI], [BMICategory],
                             [MaintenanceCalories], [FitnessGoal], [GoalCalories], [SetDate])
                        VALUES
                            (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    }

                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        if (recordExists)
                        {
                            cmd.Parameters.Add("Weight", OleDbType.Double).Value = weight;
                            cmd.Parameters.Add("Height", OleDbType.Double).Value = height;
                            cmd.Parameters.Add("Age", OleDbType.Integer).Value = age;
                            cmd.Parameters.Add("Gender", OleDbType.VarChar).Value = gender;
                            cmd.Parameters.Add("ActivityLevel", OleDbType.VarChar).Value = activityLevel;
                            cmd.Parameters.Add("BMI", OleDbType.Double).Value = bmi;
                            cmd.Parameters.Add("BMICategory", OleDbType.VarChar).Value = bmiCategory;
                            cmd.Parameters.Add("MaintenanceCalories", OleDbType.Double).Value = maintenanceCalories;
                            cmd.Parameters.Add("FitnessGoal", OleDbType.VarChar).Value = fitnessGoal;
                            cmd.Parameters.Add("GoalCalories", OleDbType.Double).Value = goalCalorie;
                            cmd.Parameters.Add("SetDate", OleDbType.Date).Value = DateTime.Now;
                            cmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        }
                        else
                        {
                            cmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                            cmd.Parameters.Add("Weight", OleDbType.Double).Value = weight;
                            cmd.Parameters.Add("Height", OleDbType.Double).Value = height;
                            cmd.Parameters.Add("Age", OleDbType.Integer).Value = age;
                            cmd.Parameters.Add("Gender", OleDbType.VarChar).Value = gender;
                            cmd.Parameters.Add("ActivityLevel", OleDbType.VarChar).Value = activityLevel;
                            cmd.Parameters.Add("BMI", OleDbType.Double).Value = bmi;
                            cmd.Parameters.Add("BMICategory", OleDbType.VarChar).Value = bmiCategory;
                            cmd.Parameters.Add("MaintenanceCalories", OleDbType.Double).Value = maintenanceCalories;
                            cmd.Parameters.Add("FitnessGoal", OleDbType.VarChar).Value = fitnessGoal;
                            cmd.Parameters.Add("GoalCalories", OleDbType.Double).Value = goalCalorie;
                            cmd.Parameters.Add("SetDate", OleDbType.Date).Value = DateTime.Now;
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"SQL Error in SaveUserProfile: {ex.Message}", "Database Error");
                    throw;
                }
            }
        }

        private void SaveGoal(double initialWeight, double targetWeight, int durationWeeks,
            string goalType, double initialBmi, double targetBmi,
            string targetBmiCategory, double dailyCalorieTarget)
        {
            if (FormLogin.CurrentUserID <= 0)
            {
                MessageBox.Show("Invalid UserID: " + FormLogin.CurrentUserID);
                return;
            }

            string connStr = GetConnectionString();
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Deactivate previous goals
                    string deactivateQuery = "UPDATE tblGoals SET [IsActive] = False WHERE [UserID] = ?";
                    using (OleDbCommand cmd = new OleDbCommand(deactivateQuery, conn))
                    {
                        cmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        cmd.ExecuteNonQuery();
                    }

                    // Calculate end date
                    DateTime startDate = DateTime.Now;
                    DateTime endDate = startDate.AddDays(durationWeeks * 7);

                    // Insert new goal
                    string insert =
                    @"INSERT INTO tblGoals
                        ([UserID], [StartDate], [InitialWeight], [TargetWeight],
                         [DurationWeeks], [GoalType], [IsActive], [GoalEndDate],
                         [InitialBMI], [TargetBMI], [TargetBMICategory], [DailyCalorieTarget])
                    VALUES
                        (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insert, conn))
                    {
                        cmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        cmd.Parameters.Add("StartDate", OleDbType.Date).Value = startDate;
                        cmd.Parameters.Add("InitialWeight", OleDbType.Double).Value = initialWeight;
                        cmd.Parameters.Add("TargetWeight", OleDbType.Double).Value = targetWeight;
                        cmd.Parameters.Add("DurationWeeks", OleDbType.Integer).Value = durationWeeks;
                        cmd.Parameters.Add("GoalType", OleDbType.VarChar).Value = goalType;
                        cmd.Parameters.Add("IsActive", OleDbType.Boolean).Value = true;
                        cmd.Parameters.Add("GoalEndDate", OleDbType.Date).Value = endDate;
                        cmd.Parameters.Add("InitialBMI", OleDbType.Double).Value = initialBmi;
                        cmd.Parameters.Add("TargetBMI", OleDbType.Double).Value = targetBmi;
                        cmd.Parameters.Add("TargetBMICategory", OleDbType.VarChar).Value = targetBmiCategory;
                        cmd.Parameters.Add("DailyCalorieTarget", OleDbType.Double).Value = dailyCalorieTarget;

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"SQL Error in SaveGoal: {ex.Message}", "Database Error");
                    throw;
                }
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            bool hasActiveGoal = HasActiveGoal(FormLogin.CurrentUserID);

            if (hasActiveGoal)
            {
                DateTime? endDate = GetGoalEndDate(FormLogin.CurrentUserID);

                if (endDate.HasValue && endDate > DateTime.Now)
                {
                    DialogResult result = MessageBox.Show(
                        "Your goal is still active. Resetting will cancel it. Are you sure?",
                        "Active Goal",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No) return;
                }
            }
            currentKgtxt.Clear();
            heighttxt.Clear();
            agetxt.Clear();
            malebtn.Checked = false;
            femalebtn.Checked = false;
            actlevelcmbbox.SelectedIndex = -1;
            fitnessgoalcmbbox.SelectedIndex = -1;
            targettxt.Clear();
            goaldurationtxt.Clear();
            ClearResults();

            DeactivateGoal(FormLogin.CurrentUserID);

            MessageBox.Show("Goal reset successfully!", "Reset Complete");
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "About - Calorie Tracking\n\n" +
                "The calorie suggestions in GoFit+ are based on the Harris-Benedict Equation,\n" +
                "which calculates your Basal Metabolic Rate (BMR) and adjusts it by your activity level\n" +
                "to estimate daily calorie needs.\n\n" +
                "This ensures that the app provides accurate and personalized guidance.",
                "About GoFit+",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}