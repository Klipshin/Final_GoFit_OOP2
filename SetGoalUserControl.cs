using Go;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Go
{
    public partial class SetGoalUserControl : UserControl
    {
        // Constants
        private const int CuttingCalorieDeficit = 500;
        private const int BulkingCalorieSurplus = 500;

        public SetGoalUserControl()
        {
            InitializeComponent();
            SetupEventHandlers();
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

        private void Recalculate(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                double weight = double.Parse(currentKgtxt.Text);
                double height = double.Parse(heighttxt.Text);
                int age = int.Parse(agetxt.Text);
                string gender = malebtn.Checked ? "male" : "female";
                string activityLevel = actlevelcmbbox.SelectedItem.ToString();
                string fitnessGoal = fitnessgoalcmbbox.SelectedItem.ToString();

                // Harris-Benedict BMR Calculation
                double bmr = CalculateBMR(gender, age, weight, height);
                double activityFactor = GetActivityFactor(activityLevel);
                double maintenanceCalories = bmr * activityFactor;
                double dailyCalorieTarget = CalculateDailyCalorieTarget(maintenanceCalories, fitnessGoal);

                // BMI Calculation
                double bmi = CalculateBMI(weight, height);
                string bmiCategory = GetBMICategory(bmi);

                // Update UI
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
            // Harris-Benedict Equation
            return gender.ToLower() == "male"
                ? 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age)   // Male
                : 447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age);  // Female
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
        }

        private void setbtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Please fill all fields correctly", "Validation Error");
                return;
            }

            try
            {
                double weight = double.Parse(currentKgtxt.Text);
                double height = double.Parse(heighttxt.Text);
                int age = int.Parse(agetxt.Text);
                string gender = malebtn.Checked ? "Male" : "Female";
                string activityLevel = actlevelcmbbox.SelectedItem.ToString();
                string fitnessGoal = fitnessgoalcmbbox.SelectedItem.ToString();
                double targetWeight = double.Parse(targettxt.Text);
                int durationWeeks = int.Parse(goaldurationtxt.Text);

                // Calculations
                double bmi = CalculateBMI(weight, height);
                string bmiCategory = GetBMICategory(bmi);
                double bmr = CalculateBMR(gender.ToLower(), age, weight, height);
                double maintenanceCalories = bmr * GetActivityFactor(activityLevel);
                double dailyCalorieTarget = CalculateDailyCalorieTarget(maintenanceCalories, fitnessGoal);
                double targetBmi = CalculateBMI(targetWeight, height);

                // Save to database
                SaveUserProfile(weight, height, age, gender, activityLevel, fitnessGoal,
                               bmi, bmiCategory, maintenanceCalories, dailyCalorieTarget);

                SaveGoal(weight, targetWeight, durationWeeks, fitnessGoal, bmi, targetBmi, dailyCalorieTarget);

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
            string connStr = @"Your_Connection_String";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Update or insert logic
                string query = @"IF EXISTS (SELECT 1 FROM tblUserProfile WHERE UserID = @UserID)
                                UPDATE tblUserProfile SET 
                                    InitialWeight = @Weight,
                                    Height = @Height,
                                    Age = @Age,
                                    Gender = @Gender,
                                    ActivityLevel = @ActivityLevel,
                                    BMI = @BMI,
                                    BMICategory = @BMICategory,
                                    MaintenanceCalories = @MaintenanceCalories,
                                    FitnessGoal = @FitnessGoal,
                                    GoalCalorie = @GoalCalorie,
                                    SetDate = @SetDate
                                WHERE UserID = @UserID
                                ELSE
                                INSERT INTO tblUserProfile (
                                    UserID, InitialWeight, Height, Age, Gender,
                                    ActivityLevel, BMI, BMICategory, MaintenanceCalories,
                                    FitnessGoal, GoalCalorie, SetDate
                                ) VALUES (
                                    @UserID, @Weight, @Height, @Age, @Gender,
                                    @ActivityLevel, @BMI, @BMICategory, @MaintenanceCalories,
                                    @FitnessGoal, @GoalCalorie, @SetDate
                                )";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", FormLogin.CurrentUserID);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@Height", height);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@ActivityLevel", activityLevel);
                    cmd.Parameters.AddWithValue("@BMI", bmi);
                    cmd.Parameters.AddWithValue("@BMICategory", bmiCategory);
                    cmd.Parameters.AddWithValue("@MaintenanceCalories", maintenanceCalories);
                    cmd.Parameters.AddWithValue("@FitnessGoal", fitnessGoal);
                    cmd.Parameters.AddWithValue("@GoalCalorie", goalCalorie);
                    cmd.Parameters.AddWithValue("@SetDate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveGoal(double initialWeight, double targetWeight, int durationWeeks,
                            string goalType, double initialBmi, double targetBmi,
                            double dailyCalorieTarget)
        {
            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Databases\users.accdb";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Deactivate previous goals
                string deactivateQuery = "UPDATE tblGoals SET IsActive = False WHERE UserID = @UserID";
                using (OleDbCommand cmd = new OleDbCommand(deactivateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", FormLogin.CurrentUserID);
                    cmd.ExecuteNonQuery();
                }

                // Insert new goal
                string insertQuery = @"INSERT INTO tblGoals (
                                    UserID, StartDate, InitialWeight, TargetWeight,
                                    DurationWeeks, GoalType, IsActive, GoalEndDate,
                                    InitialBMI, TargetBMI, DailyCalorieTarget
                                ) VALUES (
                                    @UserID, @StartDate, @InitialWeight, @TargetWeight,
                                    @DurationWeeks, @GoalType, @IsActive, @GoalEndDate,
                                    @InitialBMI, @TargetBMI, @DailyCalorieTarget
                                )";

                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", FormLogin.CurrentUserID);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@InitialWeight", initialWeight);
                    cmd.Parameters.AddWithValue("@TargetWeight", targetWeight);
                    cmd.Parameters.AddWithValue("@DurationWeeks", durationWeeks);
                    cmd.Parameters.AddWithValue("@GoalType", goalType);
                    cmd.Parameters.AddWithValue("@IsActive", true);
                    cmd.Parameters.AddWithValue("@GoalEndDate", DateTime.Now.AddDays(durationWeeks * 7));
                    cmd.Parameters.AddWithValue("@InitialBMI", initialBmi);
                    cmd.Parameters.AddWithValue("@TargetBMI", targetBmi);
                    cmd.Parameters.AddWithValue("@DailyCalorieTarget", dailyCalorieTarget);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
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
        }
    }

    public partial class CopyOfSetGoalUserControl : UserControl
    {
        // Constants
        private const int CuttingCalorieDeficit = 500;
        private const int BulkingCalorieSurplus = 500;

        public CopyOfSetGoalUserControl()
        {
            InitializeComponent();
            SetupEventHandlers();
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

        private void Recalculate(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                double weight = double.Parse(currentKgtxt.Text);
                double height = double.Parse(heighttxt.Text);
                int age = int.Parse(agetxt.Text);
                string gender = malebtn.Checked ? "male" : "female";
                string activityLevel = actlevelcmbbox.SelectedItem.ToString();
                string fitnessGoal = fitnessgoalcmbbox.SelectedItem.ToString();

                // Harris-Benedict BMR Calculation
                double bmr = CalculateBMR(gender, age, weight, height);
                double activityFactor = GetActivityFactor(activityLevel);
                double maintenanceCalories = bmr * activityFactor;
                double dailyCalorieTarget = CalculateDailyCalorieTarget(maintenanceCalories, fitnessGoal);

                // BMI Calculation
                double bmi = CalculateBMI(weight, height);
                string bmiCategory = GetBMICategory(bmi);

                // Update UI
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
            // Harris-Benedict Equation
            return gender.ToLower() == "male"
                ? 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age)   // Male
                : 447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age);  // Female
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
        }

        private void setbtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Please fill all fields correctly", "Validation Error");
                return;
            }

            try
            {
                double weight = double.Parse(currentKgtxt.Text);
                double height = double.Parse(heighttxt.Text);
                int age = int.Parse(agetxt.Text);
                string gender = malebtn.Checked ? "Male" : "Female";
                string activityLevel = actlevelcmbbox.SelectedItem.ToString();
                string fitnessGoal = fitnessgoalcmbbox.SelectedItem.ToString();
                double targetWeight = double.Parse(targettxt.Text);
                int durationWeeks = int.Parse(goaldurationtxt.Text);

                // Calculations
                double bmi = CalculateBMI(weight, height);
                string bmiCategory = GetBMICategory(bmi);
                double bmr = CalculateBMR(gender.ToLower(), age, weight, height);
                double maintenanceCalories = bmr * GetActivityFactor(activityLevel);
                double dailyCalorieTarget = CalculateDailyCalorieTarget(maintenanceCalories, fitnessGoal);
                double targetBmi = CalculateBMI(targetWeight, height);

                // Save to database
                SaveUserProfile(weight, height, age, gender, activityLevel, fitnessGoal,
                               bmi, bmiCategory, maintenanceCalories, dailyCalorieTarget);

                SaveGoal(weight, targetWeight, durationWeeks, fitnessGoal, bmi, targetBmi, dailyCalorieTarget);

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
            string connStr = @"Your_Connection_String";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Update or insert logic
                string query = @"IF EXISTS (SELECT 1 FROM tblUserProfile WHERE UserID = @UserID)
                                UPDATE tblUserProfile SET 
                                    InitialWeight = @Weight,
                                    Height = @Height,
                                    Age = @Age,
                                    Gender = @Gender,
                                    ActivityLevel = @ActivityLevel,
                                    BMI = @BMI,
                                    BMICategory = @BMICategory,
                                    MaintenanceCalories = @MaintenanceCalories,
                                    FitnessGoal = @FitnessGoal,
                                    GoalCalorie = @GoalCalorie,
                                    SetDate = @SetDate
                                WHERE UserID = @UserID
                                ELSE
                                INSERT INTO tblUserProfile (
                                    UserID, InitialWeight, Height, Age, Gender,
                                    ActivityLevel, BMI, BMICategory, MaintenanceCalories,
                                    FitnessGoal, GoalCalorie, SetDate
                                ) VALUES (
                                    @UserID, @Weight, @Height, @Age, @Gender,
                                    @ActivityLevel, @BMI, @BMICategory, @MaintenanceCalories,
                                    @FitnessGoal, @GoalCalorie, @SetDate
                                )";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", FormLogin.CurrentUserID);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@Height", height);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@ActivityLevel", activityLevel);
                    cmd.Parameters.AddWithValue("@BMI", bmi);
                    cmd.Parameters.AddWithValue("@BMICategory", bmiCategory);
                    cmd.Parameters.AddWithValue("@MaintenanceCalories", maintenanceCalories);
                    cmd.Parameters.AddWithValue("@FitnessGoal", fitnessGoal);
                    cmd.Parameters.AddWithValue("@GoalCalorie", goalCalorie);
                    cmd.Parameters.AddWithValue("@SetDate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveGoal(double initialWeight, double targetWeight, int durationWeeks,
                            string goalType, double initialBmi, double targetBmi,
                            double dailyCalorieTarget)
        {
            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Databases\users.accdb";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Deactivate previous goals
                string deactivateQuery = "UPDATE tblGoals SET IsActive = False WHERE UserID = @UserID";
                using (OleDbCommand cmd = new OleDbCommand(deactivateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", FormLogin.CurrentUserID);
                    cmd.ExecuteNonQuery();
                }

                // Insert new goal
                string insertQuery = @"INSERT INTO tblGoals (
                                    UserID, StartDate, InitialWeight, TargetWeight,
                                    DurationWeeks, GoalType, IsActive, GoalEndDate,
                                    InitialBMI, TargetBMI, DailyCalorieTarget
                                ) VALUES (
                                    @UserID, @StartDate, @InitialWeight, @TargetWeight,
                                    @DurationWeeks, @GoalType, @IsActive, @GoalEndDate,
                                    @InitialBMI, @TargetBMI, @DailyCalorieTarget
                                )";

                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", FormLogin.CurrentUserID);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@InitialWeight", initialWeight);
                    cmd.Parameters.AddWithValue("@TargetWeight", targetWeight);
                    cmd.Parameters.AddWithValue("@DurationWeeks", durationWeeks);
                    cmd.Parameters.AddWithValue("@GoalType", goalType);
                    cmd.Parameters.AddWithValue("@IsActive", true);
                    cmd.Parameters.AddWithValue("@GoalEndDate", DateTime.Now.AddDays(durationWeeks * 7));
                    cmd.Parameters.AddWithValue("@InitialBMI", initialBmi);
                    cmd.Parameters.AddWithValue("@TargetBMI", targetBmi);
                    cmd.Parameters.AddWithValue("@DailyCalorieTarget", dailyCalorieTarget);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
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
        }
    }
}