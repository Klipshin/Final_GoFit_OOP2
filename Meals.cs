using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Go
{
    public partial class Meals : UserControl
    {
        private Ingred ucIngred;
        private MealPlan ucMealPlan;

        public Meals()
        {
            InitializeComponent();

            // Load MealPlan as the default UserControl when Meals is opened
            if (ucMealPlan == null) ucMealPlan = new MealPlan();
            LoadUserControl(ucMealPlan);
        }

        private void LoadUserControl(UserControl uc)
        {
            if (panelcontainer == null) return; // Prevent errors if panelcontainer is missing

            panelcontainer.Controls.Clear(); // Remove previous control
            uc.Dock = DockStyle.Fill;
            panelcontainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void planbtn_Click(object sender, EventArgs e)
        {
            if (ucMealPlan == null) ucMealPlan = new MealPlan();
            LoadUserControl(ucMealPlan);
        }

        private void ingredbtn_Click(object sender, EventArgs e)
        {
            if (ucIngred == null) ucIngred = new Ingred();
            LoadUserControl(ucIngred);
        }
    }
}
