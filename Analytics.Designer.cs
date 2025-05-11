namespace Go
{
    partial class Analytics
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
            panel1 = new Panel();
            goalsetbtn = new Button();
            panel2 = new Panel();
            Refresh = new Button();
            button1 = new Button();
            txtweighttoday = new TextBox();
            label1 = new Label();
            panel3 = new Panel();
            splitContainer1 = new SplitContainer();
            panel8 = new Panel();
            panelChart = new Panel();
            panel9 = new Panel();
            panelCal = new Panel();
            panel7 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(goalsetbtn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1060, 57);
            panel1.TabIndex = 6;
            // 
            // goalsetbtn
            // 
            goalsetbtn.Location = new Point(20, 17);
            goalsetbtn.Name = "goalsetbtn";
            goalsetbtn.Size = new Size(149, 34);
            goalsetbtn.TabIndex = 0;
            goalsetbtn.Text = "GOAL SETTING";
            goalsetbtn.UseVisualStyleBackColor = true;
            goalsetbtn.Click += goalsetbtn_Click_1;
            // 
            // panel2
            // 
            panel2.Controls.Add(Refresh);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(txtweighttoday);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 57);
            panel2.Name = "panel2";
            panel2.Size = new Size(1060, 55);
            panel2.TabIndex = 9;
            // 
            // Refresh
            // 
            Refresh.Location = new Point(467, 16);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(115, 34);
            Refresh.TabIndex = 0;
            Refresh.Text = "Refresh";
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refreshbtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(312, 15);
            button1.Name = "button1";
            button1.Size = new Size(149, 34);
            button1.TabIndex = 0;
            button1.Text = "Save Weight";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSaveWeight_Click;
            // 
            // txtweighttoday
            // 
            txtweighttoday.Location = new Point(203, 18);
            txtweighttoday.Name = "txtweighttoday";
            txtweighttoday.Size = new Size(103, 31);
            txtweighttoday.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 18);
            label1.Name = "label1";
            label1.Size = new Size(189, 28);
            label1.TabIndex = 9;
            label1.Text = "Weight today in kg: ";
            // 
            // panel3
            // 
            panel3.Controls.Add(splitContainer1);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 112);
            panel3.Name = "panel3";
            panel3.Size = new Size(1060, 551);
            panel3.TabIndex = 10;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(31, 28);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel8);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelCal);
            splitContainer1.Size = new Size(1001, 495);
            splitContainer1.SplitterDistance = 508;
            splitContainer1.TabIndex = 4;
            // 
            // panel8
            // 
            panel8.Controls.Add(panelChart);
            panel8.Controls.Add(panel9);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(508, 495);
            panel8.TabIndex = 0;
            // 
            // panelChart
            // 
            panelChart.BorderStyle = BorderStyle.FixedSingle;
            panelChart.Dock = DockStyle.Fill;
            panelChart.Location = new Point(0, 0);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(489, 495);
            panelChart.TabIndex = 5;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Right;
            panel9.Location = new Point(489, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(19, 495);
            panel9.TabIndex = 0;
            // 
            // panelCal
            // 
            panelCal.BorderStyle = BorderStyle.FixedSingle;
            panelCal.Dock = DockStyle.Fill;
            panelCal.Location = new Point(0, 0);
            panelCal.Name = "panelCal";
            panelCal.Size = new Size(489, 495);
            panelCal.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(1032, 28);
            panel7.Name = "panel7";
            panel7.Size = new Size(28, 495);
            panel7.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 28);
            panel6.Name = "panel6";
            panel6.Size = new Size(31, 495);
            panel6.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 523);
            panel5.Name = "panel5";
            panel5.Size = new Size(1060, 28);
            panel5.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1060, 28);
            panel4.TabIndex = 0;
            // 
            // Analytics
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 220);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Analytics";
            Size = new Size(1060, 663);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button setbtn;
        private Panel panel1;
        private Button button1;
        private DateTimePicker mealDate;
        private Panel panel2;
        private TextBox txtweighttoday;
        private Label label1;
        private Panel panel3;
        private Button goalsetbtn;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private SplitContainer splitContainer1;
        private Panel panel8;
        private Panel panelChart;
        private Panel panel9;
        private Panel panelCal;
        private Button button2;
        private Button Refresh;
    }
}
