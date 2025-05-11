namespace Go
{
    partial class ManageMeal
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
            panel7 = new Panel();
            panel11 = new Panel();
            label3 = new Label();
            btnDelete = new Button();
            btnClear = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtCalories = new TextBox();
            label4 = new Label();
            txtIngredientName = new TextBox();
            panel10 = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            dgvIngredients = new DataGridView();
            panel12 = new Panel();
            txtSearch = new TextBox();
            panel9 = new Panel();
            label1 = new Label();
            panel8 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel7.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).BeginInit();
            panel12.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1230, 603);
            panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(23, 25);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel7);
            splitContainer1.Panel1.Margin = new Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Panel2.Margin = new Padding(10);
            splitContainer1.Size = new Size(1184, 553);
            splitContainer1.SplitterDistance = 442;
            splitContainer1.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel11);
            panel7.Controls.Add(panel10);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(442, 553);
            panel7.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(label3);
            panel11.Controls.Add(btnDelete);
            panel11.Controls.Add(btnClear);
            panel11.Controls.Add(btnUpdate);
            panel11.Controls.Add(btnAdd);
            panel11.Controls.Add(txtCalories);
            panel11.Controls.Add(label4);
            panel11.Controls.Add(txtIngredientName);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 72);
            panel11.Name = "panel11";
            panel11.Size = new Size(442, 481);
            panel11.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala UI", 12F, FontStyle.Bold);
            label3.Location = new Point(19, 49);
            label3.Name = "label3";
            label3.Size = new Size(215, 32);
            label3.TabIndex = 3;
            label3.Text = "Ingredient Name:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(30, 81, 123);
            btnDelete.Font = new Font("Nirmala UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(235, 216, 201);
            btnDelete.Location = new Point(237, 364);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 46);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(30, 81, 123);
            btnClear.Font = new Font("Nirmala UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(235, 216, 201);
            btnClear.Location = new Point(89, 364);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 46);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(30, 81, 123);
            btnUpdate.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.FromArgb(235, 216, 201);
            btnUpdate.Location = new Point(237, 297);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 46);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(30, 81, 123);
            btnAdd.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(235, 216, 201);
            btnAdd.Location = new Point(89, 297);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 46);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtCalories
            // 
            txtCalories.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCalories.Location = new Point(19, 210);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(398, 37);
            txtCalories.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Nirmala UI", 12F, FontStyle.Bold);
            label4.Location = new Point(19, 165);
            label4.Name = "label4";
            label4.Size = new Size(112, 32);
            label4.TabIndex = 0;
            label4.Text = "Calories:";
            // 
            // txtIngredientName
            // 
            txtIngredientName.BackColor = Color.White;
            txtIngredientName.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIngredientName.Location = new Point(19, 100);
            txtIngredientName.Name = "txtIngredientName";
            txtIngredientName.Size = new Size(398, 37);
            txtIngredientName.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Controls.Add(label2);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(442, 72);
            panel10.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(9, 38, 66);
            label2.Location = new Point(141, 12);
            label2.Name = "label2";
            label2.Size = new Size(167, 47);
            label2.TabIndex = 2;
            label2.Text = "Manage";
            // 
            // panel6
            // 
            panel6.Controls.Add(dgvIngredients);
            panel6.Controls.Add(panel12);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(738, 553);
            panel6.TabIndex = 0;
            // 
            // dgvIngredients
            // 
            dgvIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngredients.Dock = DockStyle.Fill;
            dgvIngredients.Location = new Point(13, 112);
            dgvIngredients.Name = "dgvIngredients";
            dgvIngredients.RowHeadersWidth = 62;
            dgvIngredients.Size = new Size(725, 441);
            dgvIngredients.TabIndex = 4;
            dgvIngredients.CellClick += dgvIngredients_CellClick;
            // 
            // panel12
            // 
            panel12.Controls.Add(txtSearch);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(13, 72);
            panel12.Name = "panel12";
            panel12.Size = new Size(725, 40);
            panel12.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(725, 37);
            txtSearch.TabIndex = 3;
            // 
            // panel9
            // 
            panel9.Controls.Add(label1);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(13, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(725, 72);
            panel9.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(9, 38, 66);
            label1.Location = new Point(211, 12);
            label1.Name = "label1";
            label1.Size = new Size(338, 47);
            label1.TabIndex = 2;
            label1.Text = "Ingredients Table";
            // 
            // panel8
            // 
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(13, 553);
            panel8.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1207, 25);
            panel5.Name = "panel5";
            panel5.Size = new Size(23, 553);
            panel5.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 25);
            panel4.Name = "panel4";
            panel4.Size = new Size(23, 553);
            panel4.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 578);
            panel3.Name = "panel3";
            panel3.Size = new Size(1230, 25);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1230, 25);
            panel2.TabIndex = 0;
            // 
            // ManageMeal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 220);
            Controls.Add(panel1);
            Name = "ManageMeal";
            Size = new Size(1230, 603);
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).EndInit();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private SplitContainer splitContainer1;
        private Panel panel7;
        private Panel panel6;
        private Panel panel9;
        private Label label1;
        private Panel panel8;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel11;
        private Panel panel10;
        private Label label2;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtCalories;
        private Label label4;
        private TextBox txtIngredientName;
        private Button btnDelete;
        private Button btnClear;
        private Label label3;
        private DataGridView dgvIngredients;
        private Panel panel12;
        private TextBox txtSearch;
    }
}
