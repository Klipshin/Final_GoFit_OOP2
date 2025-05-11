namespace Go
{
    partial class Ingred
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
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            panel3 = new Panel();
            MealTypecmbo = new ComboBox();
            savebtn = new Button();
            btnAddIngredient = new Button();
            txtSearchIngredient = new TextBox();
            label6 = new Label();
            label1 = new Label();
            Ingredientdgv = new DataGridView();
            panel2 = new Panel();
            panel4 = new Panel();
            mealDate = new DateTimePicker();
            removeIngredientbtn = new Button();
            updateGrambtn = new Button();
            lbltotalCal = new Label();
            label4 = new Label();
            label3 = new Label();
            txtGrams = new TextBox();
            Selecteddgv = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Ingredientdgv).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Selecteddgv).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(1093, 732);
            splitContainer1.SplitterDistance = 546;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(224, 224, 220);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(MealTypecmbo);
            panel1.Controls.Add(savebtn);
            panel1.Controls.Add(btnAddIngredient);
            panel1.Controls.Add(txtSearchIngredient);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Ingredientdgv);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 732);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(9, 38, 66);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(546, 40);
            panel3.TabIndex = 36;
            // 
            // MealTypecmbo
            // 
            MealTypecmbo.BackColor = SystemColors.ScrollBar;
            MealTypecmbo.DropDownStyle = ComboBoxStyle.DropDownList;
            MealTypecmbo.FlatStyle = FlatStyle.Flat;
            MealTypecmbo.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MealTypecmbo.FormattingEnabled = true;
            MealTypecmbo.Items.AddRange(new object[] { "Breakfast", "Lunch", "Dinner", "Snacks" });
            MealTypecmbo.Location = new Point(218, 64);
            MealTypecmbo.Name = "MealTypecmbo";
            MealTypecmbo.Size = new Size(271, 40);
            MealTypecmbo.TabIndex = 35;
            // 
            // savebtn
            // 
            savebtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            savebtn.FlatStyle = FlatStyle.Flat;
            savebtn.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            savebtn.ForeColor = Color.FromArgb(30, 81, 123);
            savebtn.Location = new Point(53, 666);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(164, 39);
            savebtn.TabIndex = 25;
            savebtn.Text = "Save Meal";
            savebtn.UseVisualStyleBackColor = true;
            savebtn.Click += savebtn_Click;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddIngredient.FlatStyle = FlatStyle.Flat;
            btnAddIngredient.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddIngredient.ForeColor = Color.FromArgb(30, 81, 123);
            btnAddIngredient.Location = new Point(420, 146);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(69, 39);
            btnAddIngredient.TabIndex = 25;
            btnAddIngredient.Text = "Add";
            btnAddIngredient.UseVisualStyleBackColor = true;
            btnAddIngredient.Click += btnAddIngredient_Click;
            // 
            // txtSearchIngredient
            // 
            txtSearchIngredient.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchIngredient.BackColor = SystemColors.ScrollBar;
            txtSearchIngredient.Location = new Point(53, 151);
            txtSearchIngredient.Name = "txtSearchIngredient";
            txtSearchIngredient.Size = new Size(361, 31);
            txtSearchIngredient.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(9, 38, 66);
            label6.Location = new Point(53, 62);
            label6.Name = "label6";
            label6.Size = new Size(159, 38);
            label6.TabIndex = 23;
            label6.Text = "Meal Type:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(9, 38, 66);
            label1.Location = new Point(53, 100);
            label1.Name = "label1";
            label1.Size = new Size(269, 38);
            label1.TabIndex = 23;
            label1.Text = "Search Ingredients:";
            // 
            // Ingredientdgv
            // 
            Ingredientdgv.AllowUserToOrderColumns = true;
            Ingredientdgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Ingredientdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Ingredientdgv.BackgroundColor = SystemColors.ControlDarkDark;
            Ingredientdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Ingredientdgv.Location = new Point(53, 203);
            Ingredientdgv.Name = "Ingredientdgv";
            Ingredientdgv.RowHeadersWidth = 62;
            Ingredientdgv.Size = new Size(436, 457);
            Ingredientdgv.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(224, 224, 220);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(mealDate);
            panel2.Controls.Add(removeIngredientbtn);
            panel2.Controls.Add(updateGrambtn);
            panel2.Controls.Add(lbltotalCal);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtGrams);
            panel2.Controls.Add(Selecteddgv);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(543, 732);
            panel2.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(9, 38, 66);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(543, 40);
            panel4.TabIndex = 37;
            // 
            // mealDate
            // 
            mealDate.CalendarFont = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mealDate.CalendarMonthBackground = Color.RosyBrown;
            mealDate.CalendarTitleBackColor = Color.IndianRed;
            mealDate.CalendarTitleForeColor = Color.RosyBrown;
            mealDate.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mealDate.Format = DateTimePickerFormat.Short;
            mealDate.Location = new Point(52, 58);
            mealDate.Name = "mealDate";
            mealDate.Size = new Size(204, 39);
            mealDate.TabIndex = 36;
            // 
            // removeIngredientbtn
            // 
            removeIngredientbtn.FlatStyle = FlatStyle.Flat;
            removeIngredientbtn.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            removeIngredientbtn.ForeColor = Color.IndianRed;
            removeIngredientbtn.Location = new Point(382, 146);
            removeIngredientbtn.Name = "removeIngredientbtn";
            removeIngredientbtn.Size = new Size(106, 44);
            removeIngredientbtn.TabIndex = 26;
            removeIngredientbtn.Text = "Remove";
            removeIngredientbtn.UseVisualStyleBackColor = true;
            removeIngredientbtn.Click += removeIngredientbtn_Click;
            // 
            // updateGrambtn
            // 
            updateGrambtn.FlatStyle = FlatStyle.Flat;
            updateGrambtn.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            updateGrambtn.ForeColor = Color.FromArgb(30, 81, 123);
            updateGrambtn.Location = new Point(266, 146);
            updateGrambtn.Name = "updateGrambtn";
            updateGrambtn.Size = new Size(106, 44);
            updateGrambtn.TabIndex = 26;
            updateGrambtn.Text = "Update";
            updateGrambtn.UseVisualStyleBackColor = true;
            updateGrambtn.Click += updateGrambtn_Click;
            // 
            // lbltotalCal
            // 
            lbltotalCal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbltotalCal.AutoSize = true;
            lbltotalCal.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltotalCal.ForeColor = Color.FromArgb(30, 81, 123);
            lbltotalCal.Location = new Point(266, 664);
            lbltotalCal.Name = "lbltotalCal";
            lbltotalCal.Size = new Size(197, 38);
            lbltotalCal.TabIndex = 24;
            lbltotalCal.Text = "_______________";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(9, 38, 66);
            label4.Location = new Point(52, 666);
            label4.Name = "label4";
            label4.Size = new Size(208, 38);
            label4.TabIndex = 24;
            label4.Text = "Total Calories: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(30, 81, 123);
            label3.Location = new Point(52, 151);
            label3.Name = "label3";
            label3.Size = new Size(86, 32);
            label3.TabIndex = 24;
            label3.Text = "Grams:";
            // 
            // txtGrams
            // 
            txtGrams.BackColor = SystemColors.ScrollBar;
            txtGrams.Location = new Point(144, 154);
            txtGrams.Name = "txtGrams";
            txtGrams.Size = new Size(116, 31);
            txtGrams.TabIndex = 24;
            // 
            // Selecteddgv
            // 
            Selecteddgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Selecteddgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Selecteddgv.BackgroundColor = SystemColors.ControlDarkDark;
            Selecteddgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Selecteddgv.Location = new Point(52, 203);
            Selecteddgv.Name = "Selecteddgv";
            Selecteddgv.RowHeadersWidth = 62;
            Selecteddgv.Size = new Size(436, 460);
            Selecteddgv.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(9, 38, 66);
            label2.Location = new Point(52, 100);
            label2.Name = "label2";
            label2.Size = new Size(292, 38);
            label2.TabIndex = 23;
            label2.Text = "Selected Ingredients:";
            // 
            // Ingred
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 40);
            Controls.Add(splitContainer1);
            Name = "Ingred";
            Size = new Size(1093, 732);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Ingredientdgv).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Selecteddgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private DataGridView Ingredientdgv;
        private Panel panel2;
        private Button btnAddIngredient;
        private TextBox txtSearchIngredient;
        private Label label1;
        private Label label3;
        private DataGridView Selecteddgv;
        private Label label2;
        private Label lbltotalCal;
        private Label label4;
        private TextBox txtGrams;
        private Button updateGrambtn;
        private Button removeIngredientbtn;
        private Label label6;
        private ComboBox MealTypecmbo;
        private DateTimePicker mealDate;
        private Button savebtn;
        private Panel panel3;
        private Panel panel4;
    }
}
