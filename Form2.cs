using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
namespace Go
{
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
            Primary.Grey900,       // Primary background (Black)
            Primary.Grey800,     // Darker background (Near black)
            Primary.Grey700,     // Lighter elements (Gray for text fields)
            Accent.Red700,       // Accent (Red buttons and highlights)
            TextShade.WHITE   );     // Text color (White)
                       
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
