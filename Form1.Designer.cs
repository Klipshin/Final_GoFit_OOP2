namespace Go
{
    partial class Register
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            label1 = new Label();
            label2 = new Label();
            txtusername = new TextBox();
            label3 = new Label();
            txtpass = new TextBox();
            label4 = new Label();
            txtconpass = new TextBox();
            showPasscheckbox = new CheckBox();
            registerbtn = new Button();
            clearbtn = new Button();
            label5 = new Label();
            backLog = new Label();
            label6 = new Label();
            txtemail = new TextBox();
            pictureBox1 = new PictureBox();
            exitbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(235, 216, 201);
            label1.Location = new Point(36, 40);
            label1.Name = "label1";
            label1.Size = new Size(273, 40);
            label1.TabIndex = 1;
            label1.Text = "LET'S GOFIT+";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(36, 98);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // txtusername
            // 
            txtusername.BackColor = SystemColors.ScrollBar;
            txtusername.Font = new Font("MS UI Gothic", 14F);
            txtusername.Location = new Point(36, 128);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(378, 35);
            txtusername.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 8F);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(36, 268);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // txtpass
            // 
            txtpass.BackColor = SystemColors.ScrollBar;
            txtpass.Font = new Font("MS UI Gothic", 14F);
            txtpass.Location = new Point(36, 298);
            txtpass.Name = "txtpass";
            txtpass.PasswordChar = '*';
            txtpass.Size = new Size(378, 35);
            txtpass.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 8F);
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(36, 350);
            label4.Name = "label4";
            label4.Size = new Size(149, 21);
            label4.TabIndex = 2;
            label4.Text = "Confirm Password";
            // 
            // txtconpass
            // 
            txtconpass.BackColor = SystemColors.ScrollBar;
            txtconpass.Font = new Font("MS UI Gothic", 14F);
            txtconpass.Location = new Point(36, 380);
            txtconpass.Name = "txtconpass";
            txtconpass.PasswordChar = '*';
            txtconpass.Size = new Size(378, 35);
            txtconpass.TabIndex = 3;
            // 
            // showPasscheckbox
            // 
            showPasscheckbox.AutoSize = true;
            showPasscheckbox.Cursor = Cursors.Hand;
            showPasscheckbox.FlatStyle = FlatStyle.Flat;
            showPasscheckbox.Font = new Font("MS UI Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPasscheckbox.ForeColor = Color.Silver;
            showPasscheckbox.Location = new Point(281, 437);
            showPasscheckbox.Name = "showPasscheckbox";
            showPasscheckbox.Size = new Size(133, 20);
            showPasscheckbox.TabIndex = 4;
            showPasscheckbox.Text = "Show Password";
            showPasscheckbox.UseVisualStyleBackColor = true;
            showPasscheckbox.CheckedChanged += showPasscheckbox_CheckedChanged;
            // 
            // registerbtn
            // 
            registerbtn.BackColor = Color.FromArgb(30, 81, 123);
            registerbtn.Cursor = Cursors.Hand;
            registerbtn.FlatAppearance.BorderSize = 0;
            registerbtn.FlatStyle = FlatStyle.Flat;
            registerbtn.Font = new Font("MS UI Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerbtn.ForeColor = Color.White;
            registerbtn.Location = new Point(36, 492);
            registerbtn.Name = "registerbtn";
            registerbtn.Size = new Size(378, 39);
            registerbtn.TabIndex = 5;
            registerbtn.Text = "REGISTER";
            registerbtn.UseVisualStyleBackColor = false;
            registerbtn.Click += registerbtn_Click;
            // 
            // clearbtn
            // 
            clearbtn.BackColor = Color.FromArgb(9, 38, 66);
            clearbtn.Cursor = Cursors.Hand;
            clearbtn.FlatStyle = FlatStyle.Flat;
            clearbtn.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearbtn.ForeColor = Color.FromArgb(235, 216, 201);
            clearbtn.Location = new Point(36, 545);
            clearbtn.Name = "clearbtn";
            clearbtn.Size = new Size(378, 39);
            clearbtn.TabIndex = 5;
            clearbtn.Text = "CLEAR";
            clearbtn.UseVisualStyleBackColor = false;
            clearbtn.Click += clearbtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Silver;
            label5.Location = new Point(122, 628);
            label5.Name = "label5";
            label5.Size = new Size(202, 21);
            label5.TabIndex = 2;
            label5.Text = "Already Have an Account";
            // 
            // backLog
            // 
            backLog.AutoSize = true;
            backLog.Cursor = Cursors.Hand;
            backLog.Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backLog.ForeColor = Color.FromArgb(235, 216, 201);
            backLog.Location = new Point(161, 658);
            backLog.Name = "backLog";
            backLog.Size = new Size(123, 21);
            backLog.TabIndex = 2;
            backLog.Text = "Back to LOGIN";
            backLog.Click += backLog_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Silver;
            label6.Location = new Point(36, 180);
            label6.Name = "label6";
            label6.Size = new Size(51, 21);
            label6.TabIndex = 2;
            label6.Text = "Email";
            // 
            // txtemail
            // 
            txtemail.BackColor = SystemColors.ScrollBar;
            txtemail.Font = new Font("MS UI Gothic", 14F);
            txtemail.Location = new Point(36, 210);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(378, 35);
            txtemail.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(459, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(707, 698);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
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
            exitbtn.TabIndex = 7;
            exitbtn.Text = "X";
            exitbtn.UseVisualStyleBackColor = true;
            exitbtn.Click += exitbtn_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(9, 38, 66);
            ClientSize = new Size(1166, 698);
            Controls.Add(exitbtn);
            Controls.Add(pictureBox1);
            Controls.Add(clearbtn);
            Controls.Add(registerbtn);
            Controls.Add(showPasscheckbox);
            Controls.Add(txtconpass);
            Controls.Add(txtpass);
            Controls.Add(backLog);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtemail);
            Controls.Add(txtusername);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Register_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox txtusername;
        private Label label3;
        private TextBox txtpass;
        private Label label4;
        private TextBox txtconpass;
        private CheckBox showPasscheckbox;
        private Button registerbtn;
        private Button clearbtn;
        private Label label5;
        private Label backLog;
        private Label label6;
        private TextBox txtemail;
        private PictureBox pictureBox1;
        private Button exitbtn;
    }
}
