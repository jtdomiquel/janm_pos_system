namespace jandm_pos.Forms
{
    partial class Add_Item
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            Column8 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewImageColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label8 = new Label();
            label19 = new Label();
            label3 = new Label();
            button1 = new Button();
            label11 = new Label();
            button3 = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column8, Column1, Column7, Column3, Column4, Column5 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.Location = new Point(21, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1233, 473);
            dataGridView1.TabIndex = 11;
            // 
            // Column8
            // 
            Column8.HeaderText = "ID";
            Column8.Name = "Column8";
            Column8.Width = 40;
            // 
            // Column1
            // 
            Column1.HeaderText = "Image";
            Column1.ImageLayout = DataGridViewImageCellLayout.Zoom;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            Column1.Width = 350;
            // 
            // Column7
            // 
            dataGridViewCellStyle2.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Column7.DefaultCellStyle = dataGridViewCellStyle2;
            Column7.HeaderText = "Barcode";
            Column7.Name = "Column7";
            Column7.Width = 200;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Column3.DefaultCellStyle = dataGridViewCellStyle3;
            Column3.HeaderText = "Unit";
            Column3.Name = "Column3";
            Column3.Width = 80;
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Column4.DefaultCellStyle = dataGridViewCellStyle4;
            Column4.HeaderText = "Product";
            Column4.Name = "Column4";
            Column4.Width = 320;
            // 
            // Column5
            // 
            dataGridViewCellStyle5.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Column5.DefaultCellStyle = dataGridViewCellStyle5;
            Column5.HeaderText = "Unit Price";
            Column5.Name = "Column5";
            Column5.Width = 200;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(1091, 536);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 12;
            label1.Text = "To Select Table (Ctrl+T)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(1087, 560);
            label2.Name = "label2";
            label2.Size = new Size(167, 20);
            label2.TabIndex = 13;
            label2.Text = "To Search Table (Ctrl+S)";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(922, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(332, 33);
            textBox1.TabIndex = 38;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.LightGreen;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.Location = new Point(805, 28);
            label8.Name = "label8";
            label8.Size = new Size(111, 21);
            label8.TabIndex = 39;
            label8.Text = "SEARCH ITEM";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            label19.Location = new Point(21, 22);
            label19.Name = "label19";
            label19.Size = new Size(142, 37);
            label19.TabIndex = 40;
            label19.Text = "ADD ITEM";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PaleVioletRed;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(783, 560);
            label3.Name = "label3";
            label3.Size = new Size(69, 21);
            label3.TabIndex = 48;
            label3.Text = "CANCEL";
            // 
            // button1
            // 
            button1.BackColor = Color.PaleVioletRed;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(645, 540);
            button1.Name = "button1";
            button1.Size = new Size(332, 59);
            button1.TabIndex = 47;
            button1.Text = "ESC";
            button1.TextAlign = ContentAlignment.TopLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Turquoise;
            label11.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label11.Location = new Point(424, 560);
            label11.Name = "label11";
            label11.Size = new Size(78, 21);
            label11.TabIndex = 46;
            label11.Text = "PROCEED";
            // 
            // button3
            // 
            button3.BackColor = Color.Turquoise;
            button3.Enabled = false;
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(296, 540);
            button3.Name = "button3";
            button3.Size = new Size(332, 59);
            button3.TabIndex = 45;
            button3.Text = "F1";
            button3.TextAlign = ContentAlignment.TopLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1272, 612);
            panel1.TabIndex = 49;
            // 
            // Add_Item
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1277, 617);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label11);
            Controls.Add(button3);
            Controls.Add(label19);
            Controls.Add(label8);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Add_Item";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ADD ITEM";
            Load += Add_Item_Load;
            KeyDown += Add_Item_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewImageColumn Column1;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Label label1;
        private Label label2;
        public TextBox textBox1;
        private Label label8;
        public Label label19;
        private Label label3;
        private Button button1;
        private Label label11;
        private Button button3;
        private Panel panel1;
    }
}