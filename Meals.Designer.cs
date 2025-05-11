namespace Go
{
    partial class Meals
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
            panelcontainer = new Panel();
            SuspendLayout();
            // 
            // panelcontainer
            // 
            panelcontainer.Dock = DockStyle.Fill;
            panelcontainer.Location = new Point(0, 0);
            panelcontainer.Name = "panelcontainer";
            panelcontainer.Size = new Size(1093, 811);
            panelcontainer.TabIndex = 1;
            // 
            // Meals
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 40);
            Controls.Add(panelcontainer);
            Name = "Meals";
            Size = new Size(1093, 811);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelcontainer;
    }
}
