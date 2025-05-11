namespace Go
{
    partial class Dashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dashboardbtn = new Button();
            SuspendLayout();
            // 
            // dashboardbtn
            // 
            dashboardbtn.BackColor = Color.FromArgb(224, 224, 220);
            dashboardbtn.Dock = DockStyle.Top;
            dashboardbtn.FlatAppearance.BorderSize = 0;
            dashboardbtn.FlatStyle = FlatStyle.Flat;
            dashboardbtn.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardbtn.ForeColor = Color.FromArgb(30, 81, 123);
            dashboardbtn.ImageKey = "Home_icon_blue-1.png";
            dashboardbtn.Location = new Point(0, 0);
            dashboardbtn.Name = "dashboardbtn";
            dashboardbtn.Size = new Size(1054, 80);
            dashboardbtn.TabIndex = 3;
            dashboardbtn.Text = "   Home              ";
            dashboardbtn.TextAlign = ContentAlignment.MiddleLeft;
            dashboardbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            dashboardbtn.UseVisualStyleBackColor = false;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 220);
            Controls.Add(dashboardbtn);
            Name = "Dashboard";
            Size = new Size(1054, 662);
            ResumeLayout(false);
        }

        #endregion

        private Button dashboardbtn;
    }
}
