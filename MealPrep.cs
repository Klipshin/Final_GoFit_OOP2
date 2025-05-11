using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace Go
{
    public partial class MealPrep : UserControl
    {
        public MealPrep()
        {
            InitializeComponent();
            CustomizeListView(); // Apply custom styling and setup
            LoadIngredients(); // Load data from the database
        }

        // Database connection
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Databases\users.accdb");
        OleDbDataAdapter da;
        DataTable dt;

        private void MealPrep_Load(object sender, EventArgs e)
        {
            LoadIngredients(); // Ensure ingredients are loaded when the control is displayed
        }

        private void LoadIngredients()
        {
            try
            {
                con.Open();
                da = new OleDbDataAdapter("SELECT [IngredientName], [CaloriesPer100g] FROM [IngredientCal]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                listView1.Items.Clear(); // Clear existing items

                // Ensure columns are only added once
                if (listView1.Columns.Count == 0)
                {
                    listView1.Columns.Add("Ingredient Name", 200);
                    listView1.Columns.Add("Calories per 100g", 150);
                }

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IngredientName"].ToString());
                    item.SubItems.Add(row["CaloriesPer100g"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ingredients: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void CustomizeListView()
        {
            listView1.OwnerDraw = true;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.DrawColumnHeader += ListView1_DrawColumnHeader;
            listView1.DrawItem += ListView1_DrawItem;
            listView1.DrawSubItem += ListView1_DrawSubItem;

            // Define columns initially with dynamic width
            listView1.Columns.Add("Ingredients Name", listView1.Width / 2, HorizontalAlignment.Left);
            listView1.Columns.Add("Calories per 100g", listView1.Width / 2, HorizontalAlignment.Left);

            this.Resize += MealPrep_Resize; // Attach resize event
        }

        private void MealPrep_Resize(object sender, EventArgs e)
        {
            AdjustColumnWidths();
        }

        private void AdjustColumnWidths()
        {
            if (listView1.Columns.Count >= 2)
            {
                listView1.Columns[0].Width = listView1.Width / 2;
                listView1.Columns[1].Width = listView1.Width / 2;
            }
        }

        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml("#CD5C5C")))
            using (Pen borderPen = new Pen(Color.Black, 2))
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
                e.Graphics.DrawRectangle(borderPen, e.Bounds);

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.DrawString(e.Header.Text, new Font("Nirmala UI", 10, FontStyle.Bold), textBrush, e.Bounds, sf);
            }
        }

        private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}