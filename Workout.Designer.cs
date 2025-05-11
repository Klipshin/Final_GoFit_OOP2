namespace Go
{
    partial class Workout
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Workout));
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            splitContainer1 = new SplitContainer();
            panel6 = new Panel();
            panel14 = new Panel();
            webvideo = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel13 = new Panel();
            panel12 = new Panel();
            btnPin = new Button();
            imageList1 = new ImageList(components);
            videoLink = new Label();
            label3 = new Label();
            namelbl = new Label();
            label2 = new Label();
            panel7 = new Panel();
            panel5 = new Panel();
            panel9 = new Panel();
            workoutdgv = new DataGridView();
            panel8 = new Panel();
            panel11 = new Panel();
            txtSearchWorkout = new TextBox();
            panel10 = new Panel();
            showpinned = new Label();
            exercises = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel6.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webvideo).BeginInit();
            panel12.SuspendLayout();
            panel5.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)workoutdgv).BeginInit();
            panel8.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1094, 23);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 777);
            panel2.Name = "panel2";
            panel2.Size = new Size(1094, 23);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1075, 23);
            panel3.Name = "panel3";
            panel3.Size = new Size(19, 754);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 23);
            panel4.Name = "panel4";
            panel4.Size = new Size(18, 754);
            panel4.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(18, 23);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel6);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Size = new Size(1057, 754);
            splitContainer1.SplitterDistance = 677;
            splitContainer1.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel14);
            panel6.Controls.Add(panel13);
            panel6.Controls.Add(panel12);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(677, 754);
            panel6.TabIndex = 0;
            // 
            // panel14
            // 
            panel14.BorderStyle = BorderStyle.FixedSingle;
            panel14.Controls.Add(webvideo);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(0, 21);
            panel14.Name = "panel14";
            panel14.Size = new Size(653, 631);
            panel14.TabIndex = 3;
            // 
            // webvideo
            // 
            webvideo.AllowExternalDrop = true;
            webvideo.CreationProperties = null;
            webvideo.DefaultBackgroundColor = Color.White;
            webvideo.Dock = DockStyle.Fill;
            webvideo.Location = new Point(0, 0);
            webvideo.Name = "webvideo";
            webvideo.Size = new Size(651, 629);
            webvideo.TabIndex = 26;
            webvideo.ZoomFactor = 1D;
            // 
            // panel13
            // 
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(653, 21);
            panel13.TabIndex = 2;
            // 
            // panel12
            // 
            panel12.Controls.Add(btnPin);
            panel12.Controls.Add(videoLink);
            panel12.Controls.Add(label3);
            panel12.Controls.Add(namelbl);
            panel12.Controls.Add(label2);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 652);
            panel12.Name = "panel12";
            panel12.Size = new Size(653, 102);
            panel12.TabIndex = 1;
            // 
            // btnPin
            // 
            btnPin.FlatAppearance.BorderSize = 0;
            btnPin.FlatStyle = FlatStyle.Flat;
            btnPin.ImageKey = "(none)";
            btnPin.ImageList = imageList1;
            btnPin.Location = new Point(571, 3);
            btnPin.Name = "btnPin";
            btnPin.Size = new Size(79, 43);
            btnPin.TabIndex = 24;
            btnPin.UseVisualStyleBackColor = true;
            btnPin.Click += btnPin_click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "889668-removebg-preview.png");
            // 
            // videoLink
            // 
            videoLink.AutoSize = true;
            videoLink.BackColor = Color.FromArgb(224, 224, 220);
            videoLink.Font = new Font("Microsoft YaHei UI", 11F);
            videoLink.ForeColor = Color.FromArgb(30, 81, 123);
            videoLink.Location = new Point(173, 53);
            videoLink.Name = "videoLink";
            videoLink.Size = new Size(193, 30);
            videoLink.TabIndex = 18;
            videoLink.Text = "__________________";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(224, 224, 220);
            label3.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(30, 81, 123);
            label3.Location = new Point(0, 53);
            label3.Name = "label3";
            label3.Size = new Size(182, 30);
            label3.TabIndex = 19;
            label3.Text = "Reference Link:";
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.BackColor = Color.FromArgb(224, 224, 220);
            namelbl.Font = new Font("Microsoft YaHei UI", 11F);
            namelbl.ForeColor = Color.FromArgb(30, 81, 123);
            namelbl.Location = new Point(173, 12);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(193, 30);
            namelbl.TabIndex = 22;
            namelbl.Text = "__________________";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(224, 224, 220);
            label2.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(30, 81, 123);
            label2.Location = new Point(0, 12);
            label2.Name = "label2";
            label2.Size = new Size(185, 30);
            label2.TabIndex = 23;
            label2.Text = "Exercise name: ";
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(653, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(24, 754);
            panel7.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel9);
            panel5.Controls.Add(panel8);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(376, 754);
            panel5.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(workoutdgv);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 90);
            panel9.Name = "panel9";
            panel9.Size = new Size(376, 664);
            panel9.TabIndex = 1;
            // 
            // workoutdgv
            // 
            workoutdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            workoutdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            workoutdgv.Dock = DockStyle.Fill;
            workoutdgv.Location = new Point(0, 0);
            workoutdgv.Name = "workoutdgv";
            workoutdgv.RowHeadersWidth = 62;
            workoutdgv.Size = new Size(376, 664);
            workoutdgv.TabIndex = 31;
            workoutdgv.SelectionChanged += workoutdgv_SelectionChanged;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel11);
            panel8.Controls.Add(panel10);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(376, 90);
            panel8.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Controls.Add(txtSearchWorkout);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 46);
            panel11.Name = "panel11";
            panel11.Size = new Size(376, 44);
            panel11.TabIndex = 1;
            // 
            // txtSearchWorkout
            // 
            txtSearchWorkout.Dock = DockStyle.Fill;
            txtSearchWorkout.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchWorkout.Location = new Point(0, 0);
            txtSearchWorkout.Name = "txtSearchWorkout";
            txtSearchWorkout.Size = new Size(376, 37);
            txtSearchWorkout.TabIndex = 0;
            txtSearchWorkout.TextChanged += txtSearchWorkout_TextChanged;
            txtSearchWorkout.KeyDown += txtSearchWorkout_KeyDown;
            // 
            // panel10
            // 
            panel10.Controls.Add(showpinned);
            panel10.Controls.Add(exercises);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(376, 46);
            panel10.TabIndex = 0;
            // 
            // showpinned
            // 
            showpinned.AutoSize = true;
            showpinned.Font = new Font("Nirmala UI Semilight", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            showpinned.ForeColor = SystemColors.ActiveCaptionText;
            showpinned.Location = new Point(262, 18);
            showpinned.Name = "showpinned";
            showpinned.Size = new Size(110, 25);
            showpinned.TabIndex = 31;
            showpinned.Text = "show pinned";
            showpinned.Click += showpinned_click;
            // 
            // exercises
            // 
            exercises.AutoSize = true;
            exercises.BackColor = Color.FromArgb(224, 224, 220);
            exercises.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exercises.ForeColor = Color.FromArgb(30, 81, 123);
            exercises.Location = new Point(3, 9);
            exercises.Name = "exercises";
            exercises.Size = new Size(143, 37);
            exercises.TabIndex = 30;
            exercises.Text = "Exercises";
            exercises.Click += exercises_click;
            // 
            // Workout
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 220);
            Controls.Add(splitContainer1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Workout";
            Size = new Size(1094, 800);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webvideo).EndInit();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel5.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)workoutdgv).EndInit();
            panel8.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private SplitContainer splitContainer1;
        private Panel panel6;
        private Panel panel7;
        private Panel panel5;
        private Panel panel8;
        private Panel panel9;
        private DataGridView workoutdgv;
        private Panel panel10;
        private Panel panel11;
        private Label exercises;
        private TextBox txtSearchWorkout;
        private Panel panel14;
        private Panel panel13;
        private Panel panel12;
        private Label videoLink;
        private Label label3;
        private Label namelbl;
        private Label label2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webvideo;
        private ImageList imageList1;
        private Button btnPin;
        private Label showpinned;
    }
}
