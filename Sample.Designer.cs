namespace Go
{
    partial class Sample
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
            tableLayoutPanel1 = new TableLayoutPanel();
            listView1 = new ListView();
            button1 = new Button();
            txtGrams = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            mealtypecombo = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            button2 = new Button();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(listView1, 0, 0);
            tableLayoutPanel1.Location = new Point(49, 201);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(967, 393);
            tableLayoutPanel1.TabIndex = 20;
            // 
            // listView1
            // 
            listView1.GridLines = true;
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(182, 146);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.IndianRed;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(904, 118);
            button1.Name = "button1";
            button1.Size = new Size(112, 46);
            button1.TabIndex = 18;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            // 
            // txtGrams
            // 
            txtGrams.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGrams.BackColor = SystemColors.ScrollBar;
            txtGrams.Location = new Point(546, 118);
            txtGrams.Multiline = true;
            txtGrams.Name = "txtGrams";
            txtGrams.Size = new Size(322, 46);
            txtGrams.TabIndex = 17;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(546, 76);
            label3.Name = "label3";
            label3.Size = new Size(94, 32);
            label3.TabIndex = 16;
            label3.Text = "Grams:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(49, 118);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(470, 46);
            textBox1.TabIndex = 15;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(49, 76);
            label2.Name = "label2";
            label2.Size = new Size(215, 32);
            label2.TabIndex = 14;
            label2.Text = "Select Ingredient:";
            // 
            // mealtypecombo
            // 
            mealtypecombo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mealtypecombo.BackColor = SystemColors.ScrollBar;
            mealtypecombo.DropDownStyle = ComboBoxStyle.DropDownList;
            mealtypecombo.FlatStyle = FlatStyle.Flat;
            mealtypecombo.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mealtypecombo.FormattingEnabled = true;
            mealtypecombo.Items.AddRange(new object[] { "Breakfast", "Lunch", "Dinner", "Snacks", "Pre/Post-Workout " });
            mealtypecombo.Location = new Point(49, 6);
            mealtypecombo.Name = "mealtypecombo";
            mealtypecombo.Size = new Size(395, 40);
            mealtypecombo.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePicker1.CalendarFont = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.CalendarMonthBackground = Color.RosyBrown;
            dateTimePicker1.CalendarTitleBackColor = Color.IndianRed;
            dateTimePicker1.CalendarTitleForeColor = Color.RosyBrown;
            dateTimePicker1.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(546, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(201, 39);
            dateTimePicker1.TabIndex = 12;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.IndianRed;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(904, 623);
            button2.Name = "button2";
            button2.Size = new Size(112, 46);
            button2.TabIndex = 19;
            button2.Text = "Save Meal";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(457, 317);
            label1.Name = "label1";
            label1.Size = new Size(150, 38);
            label1.TabIndex = 21;
            label1.Text = "Meal Prep";
            // 
            // Sample
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button1);
            Controls.Add(txtGrams);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(mealtypecombo);
            Controls.Add(dateTimePicker1);
            Controls.Add(button2);
            Name = "Sample";
            Size = new Size(1065, 672);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ListView listView1;
        private Button button1;
        private TextBox txtGrams;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private ComboBox mealtypecombo;
        private DateTimePicker dateTimePicker1;
        private Button button2;
        private Label label1;
    }
}
