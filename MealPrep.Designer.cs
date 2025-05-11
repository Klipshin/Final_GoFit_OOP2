namespace Go
{
    partial class MealPrep
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
            label1 = new Label();
            button2 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            listView2 = new ListView();
            panelContainer = new Panel();
            dateTimePicker1 = new DateTimePicker();
            mealtypecombo = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            IngredientsName = new ColumnHeader("(none)");
            Calories = new ColumnHeader();
            listView1 = new ListView();
            tableLayoutPanel1.SuspendLayout();
            panelContainer.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(17, 13);
            label1.Name = "label1";
            label1.Size = new Size(150, 38);
            label1.TabIndex = 22;
            label1.Text = "Meal Prep";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.IndianRed;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(923, 737);
            button2.Name = "button2";
            button2.Size = new Size(112, 46);
            button2.TabIndex = 30;
            button2.Text = "Save Meal";
            button2.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(listView2, 1, 0);
            tableLayoutPanel1.Controls.Add(listView1, 0, 0);
            tableLayoutPanel1.Location = new Point(71, 318);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(967, 393);
            tableLayoutPanel1.TabIndex = 31;
            // 
            // listView2
            // 
            listView2.Dock = DockStyle.Fill;
            listView2.Location = new Point(486, 3);
            listView2.Name = "listView2";
            listView2.Size = new Size(478, 387);
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // panelContainer
            // 
            panelContainer.Controls.Add(dateTimePicker1);
            panelContainer.Controls.Add(mealtypecombo);
            panelContainer.Controls.Add(tableLayoutPanel2);
            panelContainer.Controls.Add(button1);
            panelContainer.Controls.Add(tableLayoutPanel1);
            panelContainer.Controls.Add(button2);
            panelContainer.Controls.Add(label1);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1093, 811);
            panelContainer.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.CalendarMonthBackground = Color.RosyBrown;
            dateTimePicker1.CalendarTitleBackColor = Color.IndianRed;
            dateTimePicker1.CalendarTitleForeColor = Color.RosyBrown;
            dateTimePicker1.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(557, 89);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(204, 39);
            dateTimePicker1.TabIndex = 35;
            // 
            // mealtypecombo
            // 
            mealtypecombo.BackColor = SystemColors.ScrollBar;
            mealtypecombo.DropDownStyle = ComboBoxStyle.DropDownList;
            mealtypecombo.FlatStyle = FlatStyle.Flat;
            mealtypecombo.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mealtypecombo.FormattingEnabled = true;
            mealtypecombo.Items.AddRange(new object[] { "Breakfast", "Lunch", "Dinner", "Snacks" });
            mealtypecombo.Location = new Point(74, 88);
            mealtypecombo.Name = "mealtypecombo";
            mealtypecombo.Size = new Size(398, 40);
            mealtypecombo.TabIndex = 34;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.6380577F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.3619423F));
            tableLayoutPanel2.Controls.Add(label3, 1, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(textBox2, 0, 1);
            tableLayoutPanel2.Controls.Add(textBox3, 1, 1);
            tableLayoutPanel2.Location = new Point(71, 183);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel2.Size = new Size(967, 86);
            tableLayoutPanel2.TabIndex = 32;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(483, 0);
            label3.Name = "label3";
            label3.Size = new Size(481, 32);
            label3.TabIndex = 37;
            label3.Text = "Grams:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(474, 32);
            label2.TabIndex = 36;
            label2.Text = "Select Ingredient:";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ScrollBar;
            textBox2.Dock = DockStyle.Left;
            textBox2.Location = new Point(3, 37);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(416, 46);
            textBox2.TabIndex = 21;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ScrollBar;
            textBox3.Dock = DockStyle.Left;
            textBox3.Location = new Point(483, 37);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(396, 46);
            textBox3.TabIndex = 20;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.IndianRed;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(923, 275);
            button1.Name = "button1";
            button1.Size = new Size(112, 37);
            button1.TabIndex = 19;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            // 
            // IngredientsName
            // 
            IngredientsName.Text = "Ingredients Name";
            IngredientsName.Width = 250;
            // 
            // Calories
            // 
            Calories.Text = "Calories per 100g";
            Calories.Width = 225;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.BackColor = Color.Black;
            listView1.Columns.AddRange(new ColumnHeader[] { IngredientsName, Calories });
            listView1.Font = new Font("Nirmala UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listView1.ForeColor = Color.IndianRed;
            listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(477, 387);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // MealPrep
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 40);
            Controls.Add(panelContainer);
            Name = "MealPrep";
            Size = new Size(1093, 811);
            Load += MealPrep_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ListView listView2;
        private Label label1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelContainer;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label3;
        private ComboBox mealtypecombo;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ListView listView1;
        private ColumnHeader IngredientsName;
        private ColumnHeader Calories;
    }
}
