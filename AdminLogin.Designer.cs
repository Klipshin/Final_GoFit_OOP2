namespace Go
{
    partial class AdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            clearbtn = new Button();
            loginbtn = new Button();
            showPasscheckbox = new CheckBox();
            txtpass = new TextBox();
            txtusername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            backUserlbl = new Label();
            exitbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(460, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(662, 588);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Copperplate Gothic Bold", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(235, 216, 201);
            label1.Location = new Point(28, 44);
            label1.Name = "label1";
            label1.Size = new Size(390, 44);
            label1.TabIndex = 7;
            label1.Text = "Welcome Admin!";
            // 
            // clearbtn
            // 
            clearbtn.BackColor = Color.FromArgb(9, 38, 66);
            clearbtn.Cursor = Cursors.Hand;
            clearbtn.FlatStyle = FlatStyle.Flat;
            clearbtn.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearbtn.ForeColor = Color.FromArgb(235, 216, 201);
            clearbtn.Location = new Point(37, 440);
            clearbtn.Name = "clearbtn";
            clearbtn.Size = new Size(378, 39);
            clearbtn.TabIndex = 23;
            clearbtn.Text = "CLEAR";
            clearbtn.UseVisualStyleBackColor = false;
            clearbtn.Click += clearbtn_Click;
            // 
            // loginbtn
            // 
            loginbtn.BackColor = Color.FromArgb(30, 81, 123);
            loginbtn.Cursor = Cursors.Hand;
            loginbtn.FlatAppearance.BorderSize = 0;
            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginbtn.ForeColor = Color.White;
            loginbtn.Location = new Point(37, 387);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(378, 39);
            loginbtn.TabIndex = 24;
            loginbtn.Text = "LOGIN";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // showPasscheckbox
            // 
            showPasscheckbox.AutoSize = true;
            showPasscheckbox.Cursor = Cursors.Hand;
            showPasscheckbox.FlatStyle = FlatStyle.Flat;
            showPasscheckbox.Font = new Font("MS UI Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPasscheckbox.ForeColor = Color.Silver;
            showPasscheckbox.Location = new Point(282, 318);
            showPasscheckbox.Name = "showPasscheckbox";
            showPasscheckbox.Size = new Size(133, 20);
            showPasscheckbox.TabIndex = 22;
            showPasscheckbox.Text = "Show Password";
            showPasscheckbox.UseVisualStyleBackColor = true;
            showPasscheckbox.CheckedChanged += showPasscheckbox_CheckedChanged;
            // 
            // txtpass
            // 
            txtpass.BackColor = SystemColors.ScrollBar;
            txtpass.Font = new Font("MS UI Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpass.Location = new Point(40, 249);
            txtpass.Name = "txtpass";
            txtpass.PasswordChar = '*';
            txtpass.Size = new Size(378, 39);
            txtpass.TabIndex = 20;
            // 
            // txtusername
            // 
            txtusername.BackColor = SystemColors.ScrollBar;
            txtusername.Font = new Font("MS UI Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtusername.Location = new Point(40, 159);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(378, 39);
            txtusername.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 8F);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(40, 219);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 18;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 8F);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(40, 129);
            label2.Name = "label2";
            label2.Size = new Size(135, 21);
            label2.TabIndex = 19;
            label2.Text = "Username/Email";
            // 
            // backUserlbl
            // 
            backUserlbl.AutoSize = true;
            backUserlbl.Cursor = Cursors.Hand;
            backUserlbl.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            backUserlbl.ForeColor = Color.FromArgb(235, 216, 201);
            backUserlbl.Location = new Point(170, 514);
            backUserlbl.Name = "backUserlbl";
            backUserlbl.Size = new Size(116, 24);
            backUserlbl.TabIndex = 25;
            backUserlbl.Text = "Back to User";
            backUserlbl.Click += backUserlbl_Click;
            // 
            // exitbtn
            // 
            exitbtn.FlatAppearance.BorderSize = 0;
            exitbtn.FlatStyle = FlatStyle.Flat;
            exitbtn.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.FromArgb(235, 216, 201);
            exitbtn.Location = new Point(1073, 0);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new Size(49, 38);
            exitbtn.TabIndex = 26;
            exitbtn.Text = "X";
            exitbtn.UseVisualStyleBackColor = true;
            exitbtn.Click += exitbtn_Click;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(9, 38, 66);
            ClientSize = new Size(1122, 588);
            Controls.Add(exitbtn);
            Controls.Add(backUserlbl);
            Controls.Add(clearbtn);
            Controls.Add(loginbtn);
            Controls.Add(showPasscheckbox);
            Controls.Add(txtpass);
            Controls.Add(txtusername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminLogin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AdminLogin";
            Load += AdminLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button clearbtn;
        private Button loginbtn;
        private CheckBox showPasscheckbox;
        private TextBox txtpass;
        private TextBox txtusername;
        private Label label3;
        private Label label2;
        private Label backUserlbl;
        private Button exitbtn;
    }
}