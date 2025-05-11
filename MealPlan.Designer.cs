namespace Go
{
    partial class MealPlan
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
            Aboutbtn = new Button();
            btnRefresh = new Button();
            repeatbtn = new Button();
            panel7 = new Panel();
            panel19 = new Panel();
            suggestedlbl = new Label();
            dailytotallbl = new Label();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel11 = new Panel();
            panel12 = new Panel();
            panel13 = new Panel();
            dinnertotlbl = new Label();
            label8 = new Label();
            dgvDinner = new DataGridView();
            panel14 = new Panel();
            btndinneredit = new Button();
            label3 = new Label();
            panel5 = new Panel();
            panel15 = new Panel();
            panel17 = new Panel();
            snackstotlbl = new Label();
            label10 = new Label();
            dgvSnacks = new DataGridView();
            panel18 = new Panel();
            btnsnacksedit = new Button();
            label6 = new Label();
            panel4 = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            breakfasttotlbl = new Label();
            label7 = new Label();
            dgvBreakfast = new DataGridView();
            panel10 = new Panel();
            btnbreakedit = new Button();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel6 = new Panel();
            lunchtotlbl = new Label();
            label9 = new Label();
            dgvLunch = new DataGridView();
            panel16 = new Panel();
            btnlunchedit = new Button();
            label2 = new Label();
            btnPrevday = new Button();
            btnNextday = new Button();
            mealDate = new DateTimePicker();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel19.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDinner).BeginInit();
            panel14.SuspendLayout();
            panel5.SuspendLayout();
            panel15.SuspendLayout();
            panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSnacks).BeginInit();
            panel18.SuspendLayout();
            panel4.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBreakfast).BeginInit();
            panel10.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLunch).BeginInit();
            panel16.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 220);
            panel1.Controls.Add(Aboutbtn);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(repeatbtn);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(btnPrevday);
            panel1.Controls.Add(btnNextday);
            panel1.Controls.Add(mealDate);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1093, 732);
            panel1.TabIndex = 0;
            // 
            // Aboutbtn
            // 
            Aboutbtn.FlatStyle = FlatStyle.Flat;
            Aboutbtn.ForeColor = Color.FromArgb(9, 38, 66);
            Aboutbtn.Location = new Point(886, 30);
            Aboutbtn.Name = "Aboutbtn";
            Aboutbtn.Size = new Size(104, 34);
            Aboutbtn.TabIndex = 6;
            Aboutbtn.Text = "About";
            Aboutbtn.UseVisualStyleBackColor = true;
            Aboutbtn.Click += AboutBtn_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.FromArgb(9, 38, 66);
            btnRefresh.Location = new Point(764, 30);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(104, 34);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // repeatbtn
            // 
            repeatbtn.FlatStyle = FlatStyle.Flat;
            repeatbtn.ForeColor = Color.FromArgb(9, 38, 66);
            repeatbtn.Location = new Point(605, 30);
            repeatbtn.Name = "repeatbtn";
            repeatbtn.Size = new Size(141, 34);
            repeatbtn.TabIndex = 4;
            repeatbtn.Text = "Repeat 1 week";
            repeatbtn.UseVisualStyleBackColor = true;
            repeatbtn.Click += repeatbtn_Click;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel7.Controls.Add(panel19);
            panel7.Controls.Add(dailytotallbl);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(28, 664);
            panel7.Name = "panel7";
            panel7.Size = new Size(1029, 65);
            panel7.TabIndex = 3;
            // 
            // panel19
            // 
            panel19.Controls.Add(suggestedlbl);
            panel19.Dock = DockStyle.Right;
            panel19.Location = new Point(517, 0);
            panel19.Name = "panel19";
            panel19.Size = new Size(512, 65);
            panel19.TabIndex = 27;
            // 
            // suggestedlbl
            // 
            suggestedlbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            suggestedlbl.AutoSize = true;
            suggestedlbl.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            suggestedlbl.ForeColor = Color.OliveDrab;
            suggestedlbl.Location = new Point(15, 16);
            suggestedlbl.Name = "suggestedlbl";
            suggestedlbl.Size = new Size(173, 38);
            suggestedlbl.TabIndex = 30;
            suggestedlbl.Text = "_____________";
            // 
            // dailytotallbl
            // 
            dailytotallbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dailytotallbl.AutoSize = true;
            dailytotallbl.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dailytotallbl.ForeColor = Color.Brown;
            dailytotallbl.Location = new Point(323, 16);
            dailytotallbl.Name = "dailytotallbl";
            dailytotallbl.Size = new Size(173, 38);
            dailytotallbl.TabIndex = 26;
            dailytotallbl.Text = "_____________";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Nirmala UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(30, 81, 123);
            label4.Location = new Point(9, 9);
            label4.Name = "label4";
            label4.Size = new Size(325, 45);
            label4.TabIndex = 25;
            label4.Text = "Total Daily Calories: ";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel11, 0, 1);
            tableLayoutPanel1.Controls.Add(panel5, 1, 1);
            tableLayoutPanel1.Controls.Add(panel4, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Location = new Point(28, 85);
            tableLayoutPanel1.Margin = new Padding(8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1029, 580);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panel11
            // 
            panel11.Controls.Add(panel12);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(3, 293);
            panel11.Name = "panel11";
            panel11.Size = new Size(508, 284);
            panel11.TabIndex = 5;
            // 
            // panel12
            // 
            panel12.Controls.Add(panel13);
            panel12.Controls.Add(dgvDinner);
            panel12.Controls.Add(panel14);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(15, 10, 15, 10);
            panel12.Size = new Size(508, 284);
            panel12.TabIndex = 7;
            // 
            // panel13
            // 
            panel13.Controls.Add(dinnertotlbl);
            panel13.Controls.Add(label8);
            panel13.Dock = DockStyle.Bottom;
            panel13.Location = new Point(15, 246);
            panel13.Name = "panel13";
            panel13.Size = new Size(478, 28);
            panel13.TabIndex = 9;
            // 
            // dinnertotlbl
            // 
            dinnertotlbl.AutoSize = true;
            dinnertotlbl.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dinnertotlbl.ForeColor = Color.Brown;
            dinnertotlbl.Location = new Point(157, 0);
            dinnertotlbl.Name = "dinnertotlbl";
            dinnertotlbl.Size = new Size(116, 28);
            dinnertotlbl.TabIndex = 5;
            dinnertotlbl.Text = "_____________";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(30, 81, 123);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(151, 28);
            label8.TabIndex = 5;
            label8.Text = "Total Calories: ";
            // 
            // dgvDinner
            // 
            dgvDinner.AllowUserToAddRows = false;
            dgvDinner.AllowUserToDeleteRows = false;
            dgvDinner.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDinner.Dock = DockStyle.Fill;
            dgvDinner.GridColor = Color.OliveDrab;
            dgvDinner.Location = new Point(15, 54);
            dgvDinner.Name = "dgvDinner";
            dgvDinner.ReadOnly = true;
            dgvDinner.RowHeadersWidth = 62;
            dgvDinner.Size = new Size(478, 220);
            dgvDinner.TabIndex = 10;
            // 
            // panel14
            // 
            panel14.Controls.Add(btndinneredit);
            panel14.Controls.Add(label3);
            panel14.Dock = DockStyle.Top;
            panel14.Location = new Point(15, 10);
            panel14.Name = "panel14";
            panel14.Size = new Size(478, 44);
            panel14.TabIndex = 11;
            // 
            // btndinneredit
            // 
            btndinneredit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btndinneredit.FlatStyle = FlatStyle.Flat;
            btndinneredit.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btndinneredit.ForeColor = Color.OliveDrab;
            btndinneredit.Location = new Point(389, 7);
            btndinneredit.Name = "btndinneredit";
            btndinneredit.Size = new Size(86, 34);
            btndinneredit.TabIndex = 4;
            btndinneredit.Text = "Edit";
            btndinneredit.UseVisualStyleBackColor = true;
            btndinneredit.Click += btndinneredit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(9, 38, 66);
            label3.Location = new Point(6, 11);
            label3.Name = "label3";
            label3.Size = new Size(82, 30);
            label3.TabIndex = 5;
            label3.Text = "Dinner";
            // 
            // panel5
            // 
            panel5.Controls.Add(panel15);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(517, 293);
            panel5.Name = "panel5";
            panel5.Size = new Size(509, 284);
            panel5.TabIndex = 0;
            // 
            // panel15
            // 
            panel15.Controls.Add(panel17);
            panel15.Controls.Add(dgvSnacks);
            panel15.Controls.Add(panel18);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(0, 0);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(15, 10, 15, 10);
            panel15.Size = new Size(509, 284);
            panel15.TabIndex = 7;
            // 
            // panel17
            // 
            panel17.Controls.Add(snackstotlbl);
            panel17.Controls.Add(label10);
            panel17.Dock = DockStyle.Bottom;
            panel17.Location = new Point(15, 246);
            panel17.Name = "panel17";
            panel17.Size = new Size(479, 28);
            panel17.TabIndex = 9;
            // 
            // snackstotlbl
            // 
            snackstotlbl.AutoSize = true;
            snackstotlbl.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            snackstotlbl.ForeColor = Color.Brown;
            snackstotlbl.Location = new Point(163, 0);
            snackstotlbl.Name = "snackstotlbl";
            snackstotlbl.Size = new Size(116, 28);
            snackstotlbl.TabIndex = 5;
            snackstotlbl.Text = "_____________";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(30, 81, 123);
            label10.Location = new Point(6, 0);
            label10.Name = "label10";
            label10.Size = new Size(151, 28);
            label10.TabIndex = 5;
            label10.Text = "Total Calories: ";
            // 
            // dgvSnacks
            // 
            dgvSnacks.AllowUserToAddRows = false;
            dgvSnacks.AllowUserToDeleteRows = false;
            dgvSnacks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSnacks.Dock = DockStyle.Fill;
            dgvSnacks.Location = new Point(15, 54);
            dgvSnacks.Name = "dgvSnacks";
            dgvSnacks.ReadOnly = true;
            dgvSnacks.RowHeadersWidth = 62;
            dgvSnacks.Size = new Size(479, 220);
            dgvSnacks.TabIndex = 10;
            // 
            // panel18
            // 
            panel18.Controls.Add(btnsnacksedit);
            panel18.Controls.Add(label6);
            panel18.Dock = DockStyle.Top;
            panel18.Location = new Point(15, 10);
            panel18.Name = "panel18";
            panel18.Size = new Size(479, 44);
            panel18.TabIndex = 11;
            // 
            // btnsnacksedit
            // 
            btnsnacksedit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnsnacksedit.FlatStyle = FlatStyle.Flat;
            btnsnacksedit.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnsnacksedit.ForeColor = Color.OliveDrab;
            btnsnacksedit.Location = new Point(390, 7);
            btnsnacksedit.Name = "btnsnacksedit";
            btnsnacksedit.Size = new Size(86, 34);
            btnsnacksedit.TabIndex = 4;
            btnsnacksedit.Text = "Edit";
            btnsnacksedit.UseVisualStyleBackColor = true;
            btnsnacksedit.Click += btnsnacksedit_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(9, 38, 66);
            label6.Location = new Point(6, 11);
            label6.Name = "label6";
            label6.Size = new Size(83, 30);
            label6.TabIndex = 5;
            label6.Text = "Snacks";
            // 
            // panel4
            // 
            panel4.Controls.Add(panel9);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(508, 284);
            panel4.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(panel8);
            panel9.Controls.Add(dgvBreakfast);
            panel9.Controls.Add(panel10);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(15, 10, 15, 10);
            panel9.Size = new Size(508, 284);
            panel9.TabIndex = 6;
            // 
            // panel8
            // 
            panel8.Controls.Add(breakfasttotlbl);
            panel8.Controls.Add(label7);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(15, 246);
            panel8.Name = "panel8";
            panel8.Size = new Size(478, 28);
            panel8.TabIndex = 9;
            // 
            // breakfasttotlbl
            // 
            breakfasttotlbl.AutoSize = true;
            breakfasttotlbl.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            breakfasttotlbl.ForeColor = Color.Brown;
            breakfasttotlbl.Location = new Point(157, 0);
            breakfasttotlbl.Name = "breakfasttotlbl";
            breakfasttotlbl.Size = new Size(116, 28);
            breakfasttotlbl.TabIndex = 5;
            breakfasttotlbl.Text = "_____________";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(30, 81, 123);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(151, 28);
            label7.TabIndex = 5;
            label7.Text = "Total Calories: ";
            // 
            // dgvBreakfast
            // 
            dgvBreakfast.AllowUserToAddRows = false;
            dgvBreakfast.AllowUserToDeleteRows = false;
            dgvBreakfast.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBreakfast.Dock = DockStyle.Fill;
            dgvBreakfast.GridColor = Color.Black;
            dgvBreakfast.Location = new Point(15, 54);
            dgvBreakfast.Name = "dgvBreakfast";
            dgvBreakfast.ReadOnly = true;
            dgvBreakfast.RowHeadersWidth = 62;
            dgvBreakfast.Size = new Size(478, 220);
            dgvBreakfast.TabIndex = 10;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnbreakedit);
            panel10.Controls.Add(label1);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(15, 10);
            panel10.Name = "panel10";
            panel10.Size = new Size(478, 44);
            panel10.TabIndex = 11;
            // 
            // btnbreakedit
            // 
            btnbreakedit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnbreakedit.FlatStyle = FlatStyle.Flat;
            btnbreakedit.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnbreakedit.ForeColor = Color.OliveDrab;
            btnbreakedit.Location = new Point(389, 7);
            btnbreakedit.Name = "btnbreakedit";
            btnbreakedit.Size = new Size(86, 34);
            btnbreakedit.TabIndex = 4;
            btnbreakedit.Text = "Edit";
            btnbreakedit.UseVisualStyleBackColor = true;
            btnbreakedit.Click += btnbreakedit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(9, 38, 66);
            label1.Location = new Point(6, 11);
            label1.Name = "label1";
            label1.Size = new Size(111, 30);
            label1.TabIndex = 5;
            label1.Text = "Breakfast";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(517, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(509, 284);
            panel2.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(dgvLunch);
            panel3.Controls.Add(panel16);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15, 10, 15, 10);
            panel3.Size = new Size(509, 284);
            panel3.TabIndex = 7;
            // 
            // panel6
            // 
            panel6.Controls.Add(lunchtotlbl);
            panel6.Controls.Add(label9);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(15, 246);
            panel6.Name = "panel6";
            panel6.Size = new Size(479, 28);
            panel6.TabIndex = 9;
            // 
            // lunchtotlbl
            // 
            lunchtotlbl.AutoSize = true;
            lunchtotlbl.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lunchtotlbl.ForeColor = Color.Brown;
            lunchtotlbl.Location = new Point(163, 0);
            lunchtotlbl.Name = "lunchtotlbl";
            lunchtotlbl.Size = new Size(116, 28);
            lunchtotlbl.TabIndex = 5;
            lunchtotlbl.Text = "_____________";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(30, 81, 123);
            label9.Location = new Point(6, 0);
            label9.Name = "label9";
            label9.Size = new Size(151, 28);
            label9.TabIndex = 5;
            label9.Text = "Total Calories: ";
            // 
            // dgvLunch
            // 
            dgvLunch.AllowUserToAddRows = false;
            dgvLunch.AllowUserToDeleteRows = false;
            dgvLunch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLunch.Dock = DockStyle.Fill;
            dgvLunch.GridColor = Color.Brown;
            dgvLunch.Location = new Point(15, 54);
            dgvLunch.Name = "dgvLunch";
            dgvLunch.ReadOnly = true;
            dgvLunch.RowHeadersWidth = 62;
            dgvLunch.Size = new Size(479, 220);
            dgvLunch.TabIndex = 10;
            // 
            // panel16
            // 
            panel16.Controls.Add(btnlunchedit);
            panel16.Controls.Add(label2);
            panel16.Dock = DockStyle.Top;
            panel16.Location = new Point(15, 10);
            panel16.Name = "panel16";
            panel16.Size = new Size(479, 44);
            panel16.TabIndex = 11;
            // 
            // btnlunchedit
            // 
            btnlunchedit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnlunchedit.FlatStyle = FlatStyle.Flat;
            btnlunchedit.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnlunchedit.ForeColor = Color.OliveDrab;
            btnlunchedit.Location = new Point(390, 7);
            btnlunchedit.Name = "btnlunchedit";
            btnlunchedit.Size = new Size(86, 34);
            btnlunchedit.TabIndex = 4;
            btnlunchedit.Text = "Edit";
            btnlunchedit.UseVisualStyleBackColor = true;
            btnlunchedit.Click += btnlunchedit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(9, 38, 66);
            label2.Location = new Point(6, 11);
            label2.Name = "label2";
            label2.Size = new Size(74, 30);
            label2.TabIndex = 5;
            label2.Text = "Lunch";
            // 
            // btnPrevday
            // 
            btnPrevday.FlatStyle = FlatStyle.Flat;
            btnPrevday.ForeColor = Color.FromArgb(9, 38, 66);
            btnPrevday.Location = new Point(28, 30);
            btnPrevday.Name = "btnPrevday";
            btnPrevday.Size = new Size(112, 34);
            btnPrevday.TabIndex = 1;
            btnPrevday.Text = "Previous";
            btnPrevday.UseVisualStyleBackColor = true;
            btnPrevday.Click += btnPrevday_Click;
            // 
            // btnNextday
            // 
            btnNextday.FlatStyle = FlatStyle.Flat;
            btnNextday.ForeColor = Color.FromArgb(9, 38, 66);
            btnNextday.Location = new Point(475, 30);
            btnNextday.Name = "btnNextday";
            btnNextday.Size = new Size(112, 34);
            btnNextday.TabIndex = 1;
            btnNextday.Text = "Next";
            btnNextday.UseVisualStyleBackColor = true;
            btnNextday.Click += btnNextday_Click;
            // 
            // mealDate
            // 
            mealDate.CalendarFont = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mealDate.Location = new Point(159, 33);
            mealDate.Name = "mealDate";
            mealDate.Size = new Size(300, 31);
            mealDate.TabIndex = 0;
            // 
            // MealPlan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 40);
            Controls.Add(panel1);
            Name = "MealPlan";
            Size = new Size(1093, 732);
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDinner).EndInit();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel5.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSnacks).EndInit();
            panel18.ResumeLayout(false);
            panel18.PerformLayout();
            panel4.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBreakfast).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLunch).EndInit();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnPrevday;
        private Button btnNextday;
        private DateTimePicker mealDate;
        private Panel panel4;
        private Label label4;
        private Panel panel5;
        private Panel panel2;
        private Label dailytotallbl;
        private Panel panel7;
        private Panel panel9;
        private Panel panel11;
        private Panel panel8;
        private DataGridView dgvBreakfast;
        private Panel panel10;
        private Label label1;
        private Panel panel3;
        private Panel panel6;
        private DataGridView dgvLunch;
        private Panel panel16;
        private Label label2;
        private Panel panel12;
        private Panel panel13;
        private DataGridView dgvDinner;
        private Panel panel14;
        private Label label3;
        private Panel panel15;
        private Panel panel17;
        private DataGridView dgvSnacks;
        private Panel panel18;
        private Label label6;
        private Label dinnertotlbl;
        private Label label8;
        private Label label10;
        private Label label7;
        private Label label9;
        private Label snackstotlbl;
        private Label breakfasttotlbl;
        private Label lunchtotlbl;
        private Button btnbreakedit;
        private Button btndinneredit;
        private Button btnsnacksedit;
        private Button btnlunchedit;
        private Button repeatbtn;
        private Button btnRefresh;
        private Panel panel19;
        private Label suggestedlbl;
        private Button Aboutbtn;
    }
}
