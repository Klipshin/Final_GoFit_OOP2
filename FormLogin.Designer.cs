namespace Go
{
    partial class FormLogin
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
            clearbtn = new Button();
            loginbtn = new Button();
            showPasscheckbox = new CheckBox();
            txtpass = new TextBox();
            createAcc = new Label();
            label5 = new Label();
            txtusername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            forgotpass = new Label();
            pictureBox1 = new PictureBox();
            exitbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // clearbtn
            // 
            clearbtn.BackColor = Color.FromArgb(9, 38, 66);
            clearbtn.Cursor = Cursors.Hand;
            clearbtn.FlatStyle = FlatStyle.Flat;
            clearbtn.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearbtn.ForeColor = Color.FromArgb(235, 216, 201);
            clearbtn.Location = new Point(39, 506);
            clearbtn.Name = "clearbtn";
            clearbtn.Size = new Size(378, 39);
            clearbtn.TabIndex = 16;
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
            loginbtn.ForeColor = Color.FromArgb(235, 216, 201);
            loginbtn.Location = new Point(39, 453);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(378, 39);
            loginbtn.TabIndex = 17;
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
            showPasscheckbox.Location = new Point(284, 357);
            showPasscheckbox.Name = "showPasscheckbox";
            showPasscheckbox.Size = new Size(133, 20);
            showPasscheckbox.TabIndex = 15;
            showPasscheckbox.Text = "Show Password";
            showPasscheckbox.UseVisualStyleBackColor = true;
            showPasscheckbox.CheckedChanged += showPasscheckbox_CheckedChanged;
            // 
            // txtpass
            // 
            txtpass.BackColor = SystemColors.ScrollBar;
            txtpass.Font = new Font("MS UI Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpass.Location = new Point(42, 288);
            txtpass.Name = "txtpass";
            txtpass.PasswordChar = '*';
            txtpass.Size = new Size(378, 39);
            txtpass.TabIndex = 13;
            // 
            // createAcc
            // 
            createAcc.AutoSize = true;
            createAcc.Cursor = Cursors.Hand;
            createAcc.Font = new Font("Microsoft YaHei UI", 8F);
            createAcc.ForeColor = Color.FromArgb(235, 216, 201);
            createAcc.Location = new Point(156, 615);
            createAcc.Name = "createAcc";
            createAcc.Size = new Size(128, 21);
            createAcc.TabIndex = 7;
            createAcc.Text = "Create Account";
            createAcc.Click += createAcc_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 8F);
            label5.ForeColor = Color.Silver;
            label5.Location = new Point(127, 573);
            label5.Name = "label5";
            label5.Size = new Size(187, 21);
            label5.TabIndex = 8;
            label5.Text = "Don't Have an Account";
            // 
            // txtusername
            // 
            txtusername.BackColor = SystemColors.ScrollBar;
            txtusername.Font = new Font("MS UI Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtusername.Location = new Point(42, 185);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(378, 39);
            txtusername.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 8F);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(42, 258);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 10;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 8F);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(42, 155);
            label2.Name = "label2";
            label2.Size = new Size(135, 21);
            label2.TabIndex = 11;
            label2.Text = "Username/Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(235, 216, 201);
            label1.Location = new Point(39, 53);
            label1.Name = "label1";
            label1.Size = new Size(273, 40);
            label1.TabIndex = 6;
            label1.Text = "LET'S GOFIT+";
            // 
            // forgotpass
            // 
            forgotpass.AutoSize = true;
            forgotpass.Cursor = Cursors.Hand;
            forgotpass.Font = new Font("Microsoft YaHei UI", 8F);
            forgotpass.ForeColor = Color.FromArgb(235, 216, 201);
            forgotpass.Location = new Point(42, 356);
            forgotpass.Name = "forgotpass";
            forgotpass.Size = new Size(146, 21);
            forgotpass.TabIndex = 7;
            forgotpass.Text = "Forgot Password?";
            forgotpass.Click += forgotpass_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.c20c7c70_40e0_486c_b625_bde5036551bd;
            pictureBox1.Location = new Point(459, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(707, 698);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // exitbtn
            // 
            exitbtn.FlatAppearance.BorderSize = 0;
            exitbtn.FlatStyle = FlatStyle.Flat;
            exitbtn.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.FromArgb(235, 216, 201);
            exitbtn.Location = new Point(1117, 0);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new Size(49, 38);
            exitbtn.TabIndex = 19;
            exitbtn.Text = "X";
            exitbtn.UseVisualStyleBackColor = true;
            exitbtn.Click += exitbtn_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(9, 38, 66);
            ClientSize = new Size(1166, 698);
            Controls.Add(exitbtn);
            Controls.Add(pictureBox1);
            Controls.Add(clearbtn);
            Controls.Add(loginbtn);
            Controls.Add(showPasscheckbox);
            Controls.Add(txtpass);
            Controls.Add(forgotpass);
            Controls.Add(createAcc);
            Controls.Add(label5);
            Controls.Add(txtusername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLogin";
            Load += FormLogin_Load;
            KeyDown += FormLogin_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button clearbtn;
        private Button loginbtn;
        private CheckBox showPasscheckbox;
        private TextBox txtpass;
        private Label createAcc;
        private Label label5;
        private TextBox txtusername;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label forgotpass;
        private PictureBox pictureBox1;
        private Button exitbtn;
    }
}