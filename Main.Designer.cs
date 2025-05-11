namespace Go
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            panel1 = new Panel();
            panel3 = new Panel();
            analyticsbtn = new Button();
            imageList1 = new ImageList(components);
            logoutbtn = new Button();
            imageList2 = new ImageList(components);
            gymlocbtn = new Button();
            mealprepbtn = new Button();
            workoutbtn = new Button();
            panel2 = new Panel();
            usernamelbl = new Label();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            panel5 = new Panel();
            panel9 = new Panel();
            panelContainers = new Panel();
            panelContainer = new Panel();
            panel8 = new Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelContainers.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 877);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(224, 224, 220);
            panel3.Controls.Add(analyticsbtn);
            panel3.Controls.Add(logoutbtn);
            panel3.Controls.Add(gymlocbtn);
            panel3.Controls.Add(mealprepbtn);
            panel3.Controls.Add(workoutbtn);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 317);
            panel3.Name = "panel3";
            panel3.Size = new Size(336, 560);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // analyticsbtn
            // 
            analyticsbtn.BackColor = Color.FromArgb(224, 224, 220);
            analyticsbtn.Dock = DockStyle.Top;
            analyticsbtn.FlatAppearance.BorderSize = 0;
            analyticsbtn.FlatStyle = FlatStyle.Flat;
            analyticsbtn.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            analyticsbtn.ForeColor = Color.FromArgb(30, 81, 123);
            analyticsbtn.ImageKey = "138-1386046_google-analytics-integration-analytics-icon-blue-png-removebg-preview.png";
            analyticsbtn.ImageList = imageList1;
            analyticsbtn.Location = new Point(0, 240);
            analyticsbtn.Name = "analyticsbtn";
            analyticsbtn.Size = new Size(336, 80);
            analyticsbtn.TabIndex = 3;
            analyticsbtn.Text = "   Analytics        ";
            analyticsbtn.TextAlign = ContentAlignment.MiddleLeft;
            analyticsbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            analyticsbtn.UseVisualStyleBackColor = false;
            analyticsbtn.Click += analyticsbtn_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "138-1386046_google-analytics-integration-analytics-icon-blue-png-removebg-preview.png");
            imageList1.Images.SetKeyName(1, "Home_icon_blue-1.png");
            imageList1.Images.SetKeyName(2, "images-removebg-preview (5).png");
            imageList1.Images.SetKeyName(3, "download-blue-search-icon-button-png-7017516949747893a50ute33v-removebg-preview.png");
            imageList1.Images.SetKeyName(4, "images-removebg-preview (6).png");
            imageList1.Images.SetKeyName(5, "ignite-your-business-blue-fire-logo-png-transparent-11563036162ppupdbhtua-removebg-preview.png");
            // 
            // logoutbtn
            // 
            logoutbtn.BackColor = Color.FromArgb(224, 224, 220);
            logoutbtn.Dock = DockStyle.Bottom;
            logoutbtn.FlatAppearance.BorderSize = 0;
            logoutbtn.FlatStyle = FlatStyle.Flat;
            logoutbtn.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoutbtn.ForeColor = Color.FromArgb(30, 81, 123);
            logoutbtn.ImageKey = "images-removebg-preview (6).png";
            logoutbtn.ImageList = imageList2;
            logoutbtn.Location = new Point(0, 498);
            logoutbtn.Name = "logoutbtn";
            logoutbtn.Size = new Size(336, 62);
            logoutbtn.TabIndex = 2;
            logoutbtn.Text = "   Logout            ";
            logoutbtn.TextAlign = ContentAlignment.MiddleLeft;
            logoutbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            logoutbtn.UseVisualStyleBackColor = false;
            logoutbtn.Click += logoutbtn_Click;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "images-removebg-preview (6).png");
            // 
            // gymlocbtn
            // 
            gymlocbtn.BackColor = Color.FromArgb(224, 224, 220);
            gymlocbtn.Dock = DockStyle.Top;
            gymlocbtn.FlatAppearance.BorderSize = 0;
            gymlocbtn.FlatStyle = FlatStyle.Flat;
            gymlocbtn.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gymlocbtn.ForeColor = Color.FromArgb(30, 81, 123);
            gymlocbtn.ImageKey = "download-blue-search-icon-button-png-7017516949747893a50ute33v-removebg-preview.png";
            gymlocbtn.ImageList = imageList1;
            gymlocbtn.Location = new Point(0, 160);
            gymlocbtn.Name = "gymlocbtn";
            gymlocbtn.Size = new Size(336, 80);
            gymlocbtn.TabIndex = 2;
            gymlocbtn.Text = "   Gym Locator   ";
            gymlocbtn.TextAlign = ContentAlignment.MiddleLeft;
            gymlocbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            gymlocbtn.UseVisualStyleBackColor = false;
            gymlocbtn.Click += gymlocbtn_Click;
            // 
            // mealprepbtn
            // 
            mealprepbtn.BackColor = Color.FromArgb(224, 224, 220);
            mealprepbtn.Dock = DockStyle.Top;
            mealprepbtn.FlatAppearance.BorderSize = 0;
            mealprepbtn.FlatStyle = FlatStyle.Flat;
            mealprepbtn.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mealprepbtn.ForeColor = Color.FromArgb(30, 81, 123);
            mealprepbtn.ImageKey = "ignite-your-business-blue-fire-logo-png-transparent-11563036162ppupdbhtua-removebg-preview.png";
            mealprepbtn.ImageList = imageList1;
            mealprepbtn.Location = new Point(0, 80);
            mealprepbtn.Name = "mealprepbtn";
            mealprepbtn.Size = new Size(336, 80);
            mealprepbtn.TabIndex = 2;
            mealprepbtn.Text = "   Meal Prep       ";
            mealprepbtn.TextAlign = ContentAlignment.MiddleLeft;
            mealprepbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            mealprepbtn.UseVisualStyleBackColor = false;
            mealprepbtn.Click += mealprepbtn_Click;
            // 
            // workoutbtn
            // 
            workoutbtn.BackColor = Color.FromArgb(224, 224, 220);
            workoutbtn.Dock = DockStyle.Top;
            workoutbtn.FlatAppearance.BorderSize = 0;
            workoutbtn.FlatStyle = FlatStyle.Flat;
            workoutbtn.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            workoutbtn.ForeColor = Color.FromArgb(30, 81, 123);
            workoutbtn.ImageKey = "images-removebg-preview (5).png";
            workoutbtn.ImageList = imageList1;
            workoutbtn.Location = new Point(0, 0);
            workoutbtn.Name = "workoutbtn";
            workoutbtn.Size = new Size(336, 80);
            workoutbtn.TabIndex = 2;
            workoutbtn.Text = "   Workout         ";
            workoutbtn.TextAlign = ContentAlignment.MiddleLeft;
            workoutbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            workoutbtn.UseVisualStyleBackColor = false;
            workoutbtn.Click += workoutbtn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 220);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(usernamelbl);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 3, 10, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(336, 317);
            panel2.TabIndex = 1;
            // 
            // usernamelbl
            // 
            usernamelbl.AutoSize = true;
            usernamelbl.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernamelbl.ForeColor = Color.Black;
            usernamelbl.Location = new Point(129, 258);
            usernamelbl.Name = "usernamelbl";
            usernamelbl.Size = new Size(73, 32);
            usernamelbl.TabIndex = 1;
            usernamelbl.Text = "user";
            usernamelbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(38, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(263, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(9, 38, 66);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(3, 3, 3, 20);
            panel4.Name = "panel4";
            panel4.Size = new Size(1122, 37);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(9, 38, 66);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 838);
            panel5.Margin = new Padding(3, 20, 3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(1122, 37);
            panel5.TabIndex = 4;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(224, 224, 220);
            panel9.Dock = DockStyle.Right;
            panel9.Location = new Point(1108, 37);
            panel9.Name = "panel9";
            panel9.Size = new Size(14, 801);
            panel9.TabIndex = 6;
            // 
            // panelContainers
            // 
            panelContainers.BackColor = Color.FromArgb(224, 224, 220);
            panelContainers.BorderStyle = BorderStyle.FixedSingle;
            panelContainers.Controls.Add(panelContainer);
            panelContainers.Controls.Add(panel8);
            panelContainers.Controls.Add(panel9);
            panelContainers.Controls.Add(panel5);
            panelContainers.Controls.Add(panel4);
            panelContainers.Dock = DockStyle.Fill;
            panelContainers.Location = new Point(336, 0);
            panelContainers.Name = "panelContainers";
            panelContainers.Size = new Size(1124, 877);
            panelContainers.TabIndex = 6;
            panelContainers.Paint += panelContainer_Paint;
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(14, 37);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1094, 801);
            panelContainer.TabIndex = 8;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(224, 224, 220);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 37);
            panel8.Name = "panel8";
            panel8.Size = new Size(14, 801);
            panel8.TabIndex = 7;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 40);
            ClientSize = new Size(1460, 877);
            Controls.Add(panelContainers);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelContainers.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button gymlocbtn;
        private Button mealprepbtn;
        private Panel panel3;
        private Button workoutbtn;
        private GymLoc gymLoc1;
        private Button logoutbtn;
        private PictureBox pictureBox1;
        private Label usernamelbl;
        private Panel panel4;
        private Panel panel5;
        private Panel panel9;
        private Panel panelContainers;
        private Panel panel8;
        private Panel panelContainer;
        private ImageList imageList1;
        private ImageList imageList2;
        private Button analyticsbtn;
    }
}