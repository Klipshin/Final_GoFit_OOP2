using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.Defaults;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Painting;

namespace Go
{
    public partial class Analytics : UserControl
    {
        private const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\users.accdb";
        public Analytics()
        {
            InitializeComponent();
            LoadWeightChart();
        }

        private void goalsetbtn_Click_1(object sender, EventArgs e)
        {
            using (GoalSettings frm = new GoalSettings())
            {
                frm.ShowDialog(FindForm());
                LoadWeightChart();
            }
        }
        private void SaveWeightLog()
        {
            if (string.IsNullOrWhiteSpace(txtweighttoday.Text) || !decimal.TryParse(txtweighttoday.Text, out decimal weightValue))
            {
                MessageBox.Show("Please enter a valid weight.");
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();

                    // Check for existing entry today
                    string checkQuery = "SELECT COUNT(*) FROM tblWeightLogs WHERE UserID = ? AND LogDate = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add("@UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        checkCmd.Parameters.Add("@LogDate", OleDbType.Date).Value = DateTime.Today;

                        if ((int)checkCmd.ExecuteScalar() > 0)
                        {
                            // Update existing entry
                            string updateQuery = "UPDATE tblWeightLogs SET WeightUpdate = ? WHERE UserID = ? AND LogDate = ?";
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.Add("@WeightUpdate", OleDbType.Decimal).Value = weightValue;
                                updateCmd.Parameters.Add("@UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                                updateCmd.Parameters.Add("@LogDate", OleDbType.Date).Value = DateTime.Today;
                                updateCmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Weight updated successfully!");
                        }
                        else
                        {                            
                            string insertQuery = "INSERT INTO tblWeightLogs (UserID, LogDate, WeightUpdate) VALUES (?, ?, ?)";
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.Add("@UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                                insertCmd.Parameters.Add("@LogDate", OleDbType.Date).Value = DateTime.Today;
                                insertCmd.Parameters.Add("@WeightUpdate", OleDbType.Decimal).Value = weightValue;
                                insertCmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Weight logged successfully!");
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}\nPlease check your database connection and field types.", "Database Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }
        private int GetGoalDurationInWeeks()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT DurationWeeks FROM tblGoals WHERE UserID = ? AND IsActive = True";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        object result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 2;
                    }
                }
            }
            catch
            {
                return 2; 
            }
        }

        private (DateTime startDate, DateTime endDate, double? targetWeight) GetGoalDates()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT StartDate, TargetWeight FROM tblGoals 
                                WHERE UserID = ? AND IsActive = True";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime startDate = reader.GetDateTime(0);
                                int durationWeeks = GetGoalDurationInWeeks();
                                DateTime endDate = startDate.AddDays(durationWeeks * 7);
                                double? targetWeight = !reader.IsDBNull(1) ? reader.GetDouble(1) : (double?)null;
                                return (startDate, endDate, targetWeight);
                            }
                        }
                    }
                }
            }
            catch
            {
                
                int durationWeeks = GetGoalDurationInWeeks();
                return (DateTime.Today.AddDays(-7 * durationWeeks), DateTime.Today, null);
            }            
            int defaultDurationWeeks = GetGoalDurationInWeeks();
            return (DateTime.Today.AddDays(-7 * defaultDurationWeeks), DateTime.Today, null);
        }

        private void LoadWeightChart()
        {
            try
            {
                var (startDate, endDate, targetWeight) = GetGoalDates();
                List<string> dates = new List<string>();
                List<double> weights = new List<double>();

                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT LogDate, WeightUpdate FROM tblWeightLogs 
                          WHERE UserID = ? AND LogDate BETWEEN ? AND ?
                          ORDER BY LogDate";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        cmd.Parameters.Add("@StartDate", OleDbType.Date).Value = startDate;
                        cmd.Parameters.Add("@EndDate", OleDbType.Date).Value = endDate;

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dates.Add(reader.GetDateTime(0).ToString("MM/dd"));
                                weights.Add(Convert.ToDouble(reader["WeightUpdate"]));
                            }
                        }
                    }
                }

                // Create the weight chart
                panelChart.Controls.Clear();

                if (weights.Count == 0)
                {
                    panelChart.Controls.Add(new Label
                    {
                        Text = "No weight data available for the selected period.",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    });
                }
                else
                {
                    var chart = new CartesianChart
                    {
                        Dock = DockStyle.Fill,
                        Series = new ISeries[]
                        {
                            new LineSeries<double>
                            {
                                Values = weights,
                                Name = "Weight",
                                Fill = null,
                                GeometrySize = 8,
                                LineSmoothness = 0.5,
                                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 3 }
                            }
                        },
                        XAxes = new Axis[]
                        {
                            new Axis
                            {
                                Labels = dates,
                                LabelsRotation = 15,
                                Name = "Date",
                                TextSize = 12
                            }
                        },
                        YAxes = new Axis[]
                        {
                            new Axis
                            {
                                Name = "Weight (kg)",
                                TextSize = 12,
                                MinLimit = targetWeight.HasValue ?
                                    Math.Min(weights.Min(), targetWeight.Value) - 2 : weights.Min() - 2,
                                MaxLimit = targetWeight.HasValue ?
                                    Math.Max(weights.Max(), targetWeight.Value) + 2 : weights.Max() + 2
                            }
                        }
                    };

                    if (targetWeight.HasValue)
                    {
                        var targetLine = new LineSeries<double>
                        {
                            Values = Enumerable.Repeat(targetWeight.Value, dates.Count > 0 ? dates.Count : 2).ToArray(),
                            Name = "Target Weight",
                            Fill = null,
                            Stroke = new SolidColorPaint(SKColors.Red)
                            {
                                StrokeThickness = 2,
                                PathEffect = new LiveChartsCore.SkiaSharpView.Painting.Effects.DashEffect(new float[] { 6, 6 }, 0)
                            },
                            GeometryStroke = null,
                            GeometrySize = 0
                        };
                        chart.Series = chart.Series.Append(targetLine).ToArray();
                    }

                    panelChart.Controls.Add(chart);
                }

                // Load the calorie chart with the same date range
                LoadCalorieChart(startDate, endDate, dates);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart: {ex.Message}", "Error");
            }
        }
        private void LoadCalorieChart(DateTime startDate, DateTime endDate, List<string> dates)
        {
            try
            {
                Dictionary<DateTime, decimal> dailyCalories = new Dictionary<DateTime, decimal>();
                decimal? suggestedCalories = GetSuggestedCalories();                
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    dailyCalories[date] = 0;
                }                
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT m.MealDate, 
                          SUM(i.CaloriesPer100g * mi.Grams / 100) AS TotalCalories
                          FROM (tblMeals m INNER JOIN tblMealIngredients mi ON m.MealID = mi.MealID)
                          INNER JOIN tblIngredients i ON mi.IngredientID = i.IngredientID
                          WHERE m.UserID = ? AND m.MealDate BETWEEN ? AND ?
                          GROUP BY m.MealDate
                          ORDER BY m.MealDate";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        cmd.Parameters.Add("@StartDate", OleDbType.Date).Value = startDate;
                        cmd.Parameters.Add("@EndDate", OleDbType.Date).Value = endDate;

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime mealDate = reader.GetDateTime(0);
                                decimal calories = Convert.ToDecimal(reader["TotalCalories"]);
                                dailyCalories[mealDate] = calories;
                            }
                        }
                    }
                }

                // Prepare data for chart
                List<double> consumedCalories = dailyCalories
                    .Where(kv => kv.Key >= startDate && kv.Key <= endDate)
                    .OrderBy(kv => kv.Key)
                    .Select(kv => (double)kv.Value)
                    .ToList();

                // Create the chart
                panelCal.Controls.Clear();

                var chart = new CartesianChart
                {
                    Dock = DockStyle.Fill,
                    Series = new ISeries[]
                    {
                new ColumnSeries<double> 
                {
                    Values = consumedCalories,
                    Name = "Consumed Calories",
                    Fill = new SolidColorPaint(SKColors.Blue),
                    Stroke = null
                }
                    },
                    XAxes = new Axis[]
                    {
                new Axis
                {
                    Labels = dates,
                    LabelsRotation = 15,
                    Name = "Date",
                    TextSize = 12
                }
                    },
                    YAxes = new Axis[]
                    {
                new Axis
                {
                    Name = "Calories (kcal)",
                    TextSize = 12,
                    MinLimit = consumedCalories.Count > 0 ? Math.Max(0, consumedCalories.Min() - 200) : 0,
                    MaxLimit = consumedCalories.Count > 0 ? consumedCalories.Max() + 200 : (double?)null
                }
                    }
                };
                if (suggestedCalories.HasValue)
                {
                    var targetLine = new LineSeries<double>
                    {
                        Values = Enumerable.Repeat((double)suggestedCalories.Value, dates.Count > 0 ? dates.Count : 2).ToArray(),
                        Name = "Suggested",
                        Fill = null,
                        Stroke = new SolidColorPaint(SKColors.Red)
                        {
                            StrokeThickness = 2,
                            PathEffect = new LiveChartsCore.SkiaSharpView.Painting.Effects.DashEffect(new float[] { 6, 6 }, 0)
                        },
                        GeometryStroke = null,
                        GeometrySize = 0
                    };
                    chart.Series = chart.Series.Append(targetLine).ToArray();
                }

                panelCal.Controls.Add(chart);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading calorie chart: {ex.Message}", "Error");
            }
        }
        private decimal? GetSuggestedCalories()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT DailyCalorieTarget FROM tblGoals WHERE UserID = ? AND IsActive = True";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                        object result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : (decimal?)null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        private void btnSaveWeight_Click(object sender, EventArgs e)
        {
            SaveWeightLog();
            txtweighttoday.Clear(); 
            LoadWeightChart();
        }
        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            LoadWeightChart();
        }
    }
}