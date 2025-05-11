namespace Go
{
    partial class AdminManage
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
            panel1 = new Panel();
            userbtn = new Button();
            requestbtn = new Button();
            mealbtn = new Button();
            homebtn = new Button();
            panel2 = new Panel();
            panelContainer = new Panel();
            leaveBtn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 81, 123);
            panel1.Controls.Add(userbtn);
            panel1.Controls.Add(requestbtn);
            panel1.Controls.Add(mealbtn);
            panel1.Controls.Add(homebtn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(1230, 80);
            panel1.TabIndex = 2;
            // 
            // userbtn
            // 
            userbtn.Cursor = Cursors.Hand;
            userbtn.FlatStyle = FlatStyle.Flat;
            userbtn.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userbtn.ForeColor = Color.FromArgb(235, 216, 201);
            userbtn.Location = new Point(0, 0);
            userbtn.Name = "userbtn";
            userbtn.Size = new Size(303, 80);
            userbtn.TabIndex = 3;
            userbtn.Text = "Users";
            userbtn.UseVisualStyleBackColor = true;
            userbtn.Click += userbtn_Click;
            // 
            // requestbtn
            // 
            requestbtn.Cursor = Cursors.Hand;
            requestbtn.FlatStyle = FlatStyle.Flat;
            requestbtn.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            requestbtn.ForeColor = Color.FromArgb(235, 216, 201);
            requestbtn.Location = new Point(927, 0);
            requestbtn.Name = "requestbtn";
            requestbtn.Size = new Size(303, 80);
            requestbtn.TabIndex = 3;
            requestbtn.Text = "Requests";
            requestbtn.UseVisualStyleBackColor = true;
            requestbtn.Click += requestbtn_Click;
            // 
            // mealbtn
            // 
            mealbtn.Cursor = Cursors.Hand;
            mealbtn.FlatStyle = FlatStyle.Flat;
            mealbtn.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mealbtn.ForeColor = Color.FromArgb(235, 216, 201);
            mealbtn.Location = new Point(618, 0);
            mealbtn.Name = "mealbtn";
            mealbtn.Size = new Size(303, 80);
            mealbtn.TabIndex = 3;
            mealbtn.Text = "Meals";
            mealbtn.UseVisualStyleBackColor = true;
            mealbtn.Click += mealbtn_Click;
            // 
            // homebtn
            // 
            homebtn.Cursor = Cursors.Hand;
            homebtn.FlatStyle = FlatStyle.Flat;
            homebtn.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homebtn.ForeColor = Color.FromArgb(235, 216, 201);
            homebtn.Location = new Point(309, 0);
            homebtn.Name = "homebtn";
            homebtn.Size = new Size(303, 80);
            homebtn.TabIndex = 3;
            homebtn.Text = "Workouts";
            homebtn.UseVisualStyleBackColor = true;
            homebtn.Click += homebtn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(9, 38, 66);
            panel2.Controls.Add(leaveBtn);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1230, 51);
            panel2.TabIndex = 1;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.FromArgb(224, 224, 220);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 131);
            panelContainer.Margin = new Padding(10);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1230, 603);
            panelContainer.TabIndex = 4;
            // 
            // leaveBtn
            // 
            leaveBtn.FlatStyle = FlatStyle.Flat;
            leaveBtn.ForeColor = Color.FromArgb(235, 216, 201);
            leaveBtn.Location = new Point(12, 11);
            leaveBtn.Name = "leaveBtn";
            leaveBtn.Size = new Size(85, 34);
            leaveBtn.TabIndex = 0;
            leaveBtn.Text = "Leave";
            leaveBtn.UseVisualStyleBackColor = true;
            leaveBtn.Click += leaveBtn_Click;
            // 
            // AdminManage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 216, 201);
            ClientSize = new Size(1230, 734);
            Controls.Add(panelContainer);
            Controls.Add(panel1);
            Controls.Add(panel2);
            MaximizeBox = false;
            Name = "AdminManage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminManage";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button homebtn;
        private Panel panel2;
        private Button requestbtn;
        private Button mealbtn;
        private Button userbtn;
        private Panel panelContainer;
        private Button leaveBtn;
    }
}