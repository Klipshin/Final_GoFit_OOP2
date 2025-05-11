namespace Go
{
    partial class ManageRequest
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
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            panel13 = new Panel();
            rejectbtn = new Button();
            approvebtn = new Button();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtrequestdate = new TextBox();
            txtrequestedby = new TextBox();
            txtmessagerequest = new TextBox();
            txtlocationname = new TextBox();
            panel10 = new Panel();
            panel8 = new Panel();
            panel5 = new Panel();
            panel3 = new Panel();
            panel6 = new Panel();
            panel14 = new Panel();
            locationsdgv = new DataGridView();
            panel11 = new Panel();
            panel7 = new Panel();
            panel4 = new Panel();
            panel15 = new Panel();
            txtSearch = new TextBox();
            panel12 = new Panel();
            panel9 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            panel13.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)locationsdgv).BeginInit();
            panel4.SuspendLayout();
            panel15.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Controls.Add(panel9);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1230, 603);
            panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 77);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2.Margin = new Padding(10);
            splitContainer1.Size = new Size(1230, 526);
            splitContainer1.SplitterDistance = 513;
            splitContainer1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel13);
            panel2.Controls.Add(panel10);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(513, 526);
            panel2.TabIndex = 0;
            // 
            // panel13
            // 
            panel13.Controls.Add(rejectbtn);
            panel13.Controls.Add(approvebtn);
            panel13.Controls.Add(label5);
            panel13.Controls.Add(label4);
            panel13.Controls.Add(label1);
            panel13.Controls.Add(label3);
            panel13.Controls.Add(txtrequestdate);
            panel13.Controls.Add(txtrequestedby);
            panel13.Controls.Add(txtmessagerequest);
            panel13.Controls.Add(txtlocationname);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(10, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(486, 511);
            panel13.TabIndex = 0;
            // 
            // rejectbtn
            // 
            rejectbtn.BackColor = Color.IndianRed;
            rejectbtn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rejectbtn.ForeColor = Color.FromArgb(235, 216, 201);
            rejectbtn.Location = new Point(269, 440);
            rejectbtn.Name = "rejectbtn";
            rejectbtn.Size = new Size(114, 45);
            rejectbtn.TabIndex = 6;
            rejectbtn.Text = "Reject";
            rejectbtn.UseVisualStyleBackColor = false;
            rejectbtn.Click += rejectbtn_Click;
            // 
            // approvebtn
            // 
            approvebtn.BackColor = Color.FromArgb(30, 81, 123);
            approvebtn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            approvebtn.ForeColor = Color.FromArgb(235, 216, 201);
            approvebtn.Location = new Point(112, 440);
            approvebtn.Name = "approvebtn";
            approvebtn.Size = new Size(114, 45);
            approvebtn.TabIndex = 6;
            approvebtn.Text = "Approve";
            approvebtn.UseVisualStyleBackColor = false;
            approvebtn.Click += approvebtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Nirmala UI", 12F, FontStyle.Bold);
            label5.Location = new Point(18, 331);
            label5.Name = "label5";
            label5.Size = new Size(169, 32);
            label5.TabIndex = 5;
            label5.Text = "Request date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Nirmala UI", 12F, FontStyle.Bold);
            label4.Location = new Point(18, 242);
            label4.Name = "label4";
            label4.Size = new Size(175, 32);
            label4.TabIndex = 5;
            label4.Text = "Requested by:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 12F, FontStyle.Bold);
            label1.Location = new Point(18, 115);
            label1.Name = "label1";
            label1.Size = new Size(120, 32);
            label1.TabIndex = 5;
            label1.Text = "Message:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala UI", 12F, FontStyle.Bold);
            label3.Location = new Point(18, 25);
            label3.Name = "label3";
            label3.Size = new Size(193, 32);
            label3.TabIndex = 5;
            label3.Text = "Location Name:";
            // 
            // txtrequestdate
            // 
            txtrequestdate.BackColor = Color.White;
            txtrequestdate.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtrequestdate.Location = new Point(18, 366);
            txtrequestdate.Name = "txtrequestdate";
            txtrequestdate.Size = new Size(462, 37);
            txtrequestdate.TabIndex = 4;
            // 
            // txtrequestedby
            // 
            txtrequestedby.BackColor = Color.White;
            txtrequestedby.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtrequestedby.Location = new Point(18, 277);
            txtrequestedby.Name = "txtrequestedby";
            txtrequestedby.Size = new Size(462, 37);
            txtrequestedby.TabIndex = 4;
            // 
            // txtmessagerequest
            // 
            txtmessagerequest.BackColor = Color.White;
            txtmessagerequest.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtmessagerequest.Location = new Point(18, 150);
            txtmessagerequest.Multiline = true;
            txtmessagerequest.Name = "txtmessagerequest";
            txtmessagerequest.Size = new Size(462, 89);
            txtmessagerequest.TabIndex = 4;
            // 
            // txtlocationname
            // 
            txtlocationname.BackColor = Color.White;
            txtlocationname.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtlocationname.Location = new Point(18, 60);
            txtlocationname.Name = "txtlocationname";
            txtlocationname.Size = new Size(462, 37);
            txtlocationname.TabIndex = 4;
            // 
            // panel10
            // 
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(10, 511);
            panel10.Name = "panel10";
            panel10.Size = new Size(486, 15);
            panel10.TabIndex = 2;
            // 
            // panel8
            // 
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(10, 526);
            panel8.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(496, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(17, 526);
            panel5.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(713, 526);
            panel3.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel14);
            panel6.Controls.Add(panel11);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 38);
            panel6.Name = "panel6";
            panel6.Size = new Size(713, 488);
            panel6.TabIndex = 1;
            // 
            // panel14
            // 
            panel14.Controls.Add(locationsdgv);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(0, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(693, 473);
            panel14.TabIndex = 3;
            // 
            // locationsdgv
            // 
            locationsdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            locationsdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            locationsdgv.Dock = DockStyle.Fill;
            locationsdgv.Location = new Point(0, 0);
            locationsdgv.Name = "locationsdgv";
            locationsdgv.RowHeadersWidth = 62;
            locationsdgv.Size = new Size(693, 473);
            locationsdgv.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Dock = DockStyle.Right;
            panel11.Location = new Point(693, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(20, 473);
            panel11.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(0, 473);
            panel7.Name = "panel7";
            panel7.Size = new Size(713, 15);
            panel7.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel15);
            panel4.Controls.Add(panel12);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(713, 38);
            panel4.TabIndex = 0;
            // 
            // panel15
            // 
            panel15.Controls.Add(txtSearch);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(0, 0);
            panel15.Name = "panel15";
            panel15.Size = new Size(693, 38);
            panel15.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(693, 34);
            txtSearch.TabIndex = 0;
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Right;
            panel12.Location = new Point(693, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(20, 38);
            panel12.TabIndex = 2;
            // 
            // panel9
            // 
            panel9.Controls.Add(label2);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(1230, 77);
            panel9.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(9, 38, 66);
            label2.Location = new Point(408, 14);
            label2.Name = "label2";
            label2.Size = new Size(415, 47);
            label2.TabIndex = 2;
            label2.Text = "GoFit+ Chat Requests";
            // 
            // ManageRequest
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 220);
            Controls.Add(panel1);
            Name = "ManageRequest";
            Size = new Size(1230, 603);
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)locationsdgv).EndInit();
            panel4.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private SplitContainer splitContainer1;
        private Panel panel2;
        private Panel panel5;
        private Panel panel3;
        private Panel panel4;
        private Panel panel9;
        private Label label2;
        private Panel panel8;
        private Panel panel6;
        private Panel panel7;
        private DataGridView locationsdgv;
        private TextBox txtSearch;
        private Panel panel13;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Label label5;
        private Label label4;
        private Label label1;
        private Label label3;
        private TextBox txtrequestdate;
        private TextBox txtrequestedby;
        private TextBox txtmessagerequest;
        private TextBox txtlocationname;
        private Button rejectbtn;
        private Button approvebtn;
        private Panel panel14;
        private Panel panel15;
    }
}
