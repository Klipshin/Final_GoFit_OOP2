namespace Go
{
    partial class ForgotPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPass));
            txtemail = new TextBox();
            label4 = new Label();
            btnemail = new Button();
            label1 = new Label();
            txtcode = new TextBox();
            btncheckcode = new Button();
            label2 = new Label();
            txtpass = new TextBox();
            label3 = new Label();
            txtconpass = new TextBox();
            showPasscheckbox = new CheckBox();
            verifybtn = new Button();
            backLog = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtemail
            // 
            txtemail.BackColor = SystemColors.ScrollBar;
            txtemail.Font = new Font("MS UI Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtemail.Location = new Point(45, 88);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(378, 39);
            txtemail.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(45, 58);
            label4.Name = "label4";
            label4.Size = new Size(63, 27);
            label4.TabIndex = 15;
            label4.Text = "Email";
            // 
            // btnemail
            // 
            btnemail.BackColor = Color.Gray;
            btnemail.Cursor = Cursors.Hand;
            btnemail.FlatAppearance.BorderSize = 0;
            btnemail.FlatStyle = FlatStyle.Flat;
            btnemail.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnemail.ForeColor = Color.White;
            btnemail.Location = new Point(45, 143);
            btnemail.Name = "btnemail";
            btnemail.Size = new Size(120, 29);
            btnemail.TabIndex = 17;
            btnemail.Text = "Send Code";
            btnemail.UseVisualStyleBackColor = false;
            btnemail.Click += btnemail_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(45, 218);
            label1.Name = "label1";
            label1.Size = new Size(62, 27);
            label1.TabIndex = 15;
            label1.Text = "Code";
            // 
            // txtcode
            // 
            txtcode.BackColor = SystemColors.ScrollBar;
            txtcode.Font = new Font("MS UI Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcode.Location = new Point(45, 248);
            txtcode.Name = "txtcode";
            txtcode.Size = new Size(378, 39);
            txtcode.TabIndex = 16;
            // 
            // btncheckcode
            // 
            btncheckcode.BackColor = Color.Gray;
            btncheckcode.Cursor = Cursors.Hand;
            btncheckcode.FlatAppearance.BorderSize = 0;
            btncheckcode.FlatStyle = FlatStyle.Flat;
            btncheckcode.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btncheckcode.ForeColor = Color.White;
            btncheckcode.Location = new Point(45, 303);
            btncheckcode.Name = "btncheckcode";
            btncheckcode.Size = new Size(120, 29);
            btncheckcode.TabIndex = 17;
            btncheckcode.Text = "Verify Code";
            btncheckcode.UseVisualStyleBackColor = false;
            btncheckcode.Click += btncheckcode_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(45, 374);
            label2.Name = "label2";
            label2.Size = new Size(152, 27);
            label2.TabIndex = 15;
            label2.Text = "New Password";
            // 
            // txtpass
            // 
            txtpass.BackColor = SystemColors.ScrollBar;
            txtpass.Font = new Font("MS UI Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpass.Location = new Point(45, 404);
            txtpass.Name = "txtpass";
            txtpass.PasswordChar = '*';
            txtpass.Size = new Size(378, 39);
            txtpass.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(45, 469);
            label3.Name = "label3";
            label3.Size = new Size(226, 27);
            label3.TabIndex = 15;
            label3.Text = "Confirm New Pasword";
            // 
            // txtconpass
            // 
            txtconpass.BackColor = SystemColors.ScrollBar;
            txtconpass.Font = new Font("MS UI Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtconpass.Location = new Point(45, 499);
            txtconpass.Name = "txtconpass";
            txtconpass.PasswordChar = '*';
            txtconpass.Size = new Size(378, 39);
            txtconpass.TabIndex = 16;
            // 
            // showPasscheckbox
            // 
            showPasscheckbox.AutoSize = true;
            showPasscheckbox.Cursor = Cursors.Hand;
            showPasscheckbox.FlatStyle = FlatStyle.Flat;
            showPasscheckbox.Font = new Font("MS UI Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPasscheckbox.ForeColor = Color.Silver;
            showPasscheckbox.Location = new Point(45, 554);
            showPasscheckbox.Name = "showPasscheckbox";
            showPasscheckbox.Size = new Size(133, 20);
            showPasscheckbox.TabIndex = 18;
            showPasscheckbox.Text = "Show Password";
            showPasscheckbox.UseVisualStyleBackColor = true;
            showPasscheckbox.CheckedChanged += showPasscheckbox_CheckedChanged;
            // 
            // verifybtn
            // 
            verifybtn.BackColor = Color.IndianRed;
            verifybtn.Cursor = Cursors.Hand;
            verifybtn.FlatAppearance.BorderSize = 0;
            verifybtn.FlatStyle = FlatStyle.Flat;
            verifybtn.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            verifybtn.ForeColor = Color.White;
            verifybtn.Location = new Point(45, 601);
            verifybtn.Name = "verifybtn";
            verifybtn.Size = new Size(378, 39);
            verifybtn.TabIndex = 19;
            verifybtn.Text = "VERIFY";
            verifybtn.UseVisualStyleBackColor = false;
            verifybtn.Click += verifybtn_Click;
            // 
            // backLog
            // 
            backLog.AutoSize = true;
            backLog.Cursor = Cursors.Hand;
            backLog.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backLog.ForeColor = Color.IndianRed;
            backLog.Location = new Point(151, 666);
            backLog.Name = "backLog";
            backLog.Size = new Size(152, 27);
            backLog.TabIndex = 20;
            backLog.Text = "Back to LOGIN";
            backLog.Click += backLog_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(474, 750);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // ForgotPass
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(474, 750);
            Controls.Add(backLog);
            Controls.Add(verifybtn);
            Controls.Add(showPasscheckbox);
            Controls.Add(txtconpass);
            Controls.Add(txtpass);
            Controls.Add(btncheckcode);
            Controls.Add(label3);
            Controls.Add(txtcode);
            Controls.Add(label2);
            Controls.Add(btnemail);
            Controls.Add(label1);
            Controls.Add(txtemail);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgotPass";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPass";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtemail;
        private Label label4;
        private Button btnemail;
        private Label label1;
        private TextBox txtcode;
        private Button btncheckcode;
        private Label label2;
        private TextBox txtpass;
        private Label label3;
        private TextBox txtconpass;
        private CheckBox showPasscheckbox;
        private Button verifybtn;
        private Label backLog;
        private PictureBox pictureBox1;
    }
}