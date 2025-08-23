namespace jandm_pos.Forms
{
    partial class cashier_dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cashier_dashboard));
            panel1 = new Panel();
            panel6 = new Panel();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            panel5 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            panel4 = new Panel();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(6, 64, 43);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(208, 920);
            panel1.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(button6);
            panel6.Controls.Add(button7);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 528);
            panel6.Name = "panel6";
            panel6.Size = new Size(206, 110);
            panel6.TabIndex = 5;
            panel6.Visible = false;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Top;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = SystemColors.Control;
            button6.Image = Properties.Resources.cashier_sales;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(0, 50);
            button6.Name = "button6";
            button6.Padding = new Padding(40, 0, 0, 0);
            button6.Size = new Size(206, 50);
            button6.TabIndex = 1;
            button6.Text = "         Sales per Cashier";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Top;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = SystemColors.Control;
            button7.Image = Properties.Resources.sales_summary;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(0, 0);
            button7.Name = "button7";
            button7.Padding = new Padding(40, 0, 0, 0);
            button7.Size = new Size(206, 50);
            button7.TabIndex = 0;
            button7.Text = "         Sales Summaries";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Dock = DockStyle.Top;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.ForeColor = SystemColors.Control;
            button8.Image = Properties.Resources.sales_report;
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Location = new Point(0, 477);
            button8.Name = "button8";
            button8.Size = new Size(206, 51);
            button8.TabIndex = 4;
            button8.TabStop = false;
            button8.Tag = "";
            button8.Text = "Sales and\r\nTransaction Reports";
            button8.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(button5);
            panel5.Controls.Add(button4);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 368);
            panel5.Name = "panel5";
            panel5.Size = new Size(206, 109);
            panel5.TabIndex = 3;
            panel5.Visible = false;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Top;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.Control;
            button5.Image = Properties.Resources.product_management;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(0, 50);
            button5.Name = "button5";
            button5.Padding = new Padding(40, 0, 0, 0);
            button5.Size = new Size(206, 50);
            button5.TabIndex = 1;
            button5.Text = "Product\r\nInventories";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Top;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.Control;
            button4.Image = Properties.Resources.product_categories;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(0, 0);
            button4.Name = "button4";
            button4.Padding = new Padding(40, 0, 0, 0);
            button4.Size = new Size(206, 50);
            button4.TabIndex = 0;
            button4.Text = "         Product Categories";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.Control;
            button3.Image = Properties.Resources.product;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 305);
            button3.Name = "button3";
            button3.Size = new Size(206, 63);
            button3.TabIndex = 2;
            button3.TabStop = false;
            button3.Tag = "";
            button3.Text = "Product and Inventory\r\nManagement";
            button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Transparent;
            button1.Image = Properties.Resources.user_account;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 254);
            button1.Name = "button1";
            button1.Size = new Size(206, 51);
            button1.TabIndex = 1;
            button1.TabStop = false;
            button1.Tag = "";
            button1.Text = "User Management";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(pictureBox1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(206, 254);
            panel4.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 227);
            label2.Name = "label2";
            label2.Size = new Size(54, 17);
            label2.TabIndex = 8;
            label2.Text = "Position";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 206);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 7;
            label1.Text = "LastName";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 185);
            label4.Name = "label4";
            label4.Size = new Size(82, 21);
            label4.TabIndex = 6;
            label4.Text = "FirstName";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.jan_m_logo;
            pictureBox1.Location = new Point(3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(197, 180);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // cashier_dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1470, 920);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "cashier_dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cashier";
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        public Panel panel6;
        private Button button6;
        private Button button7;
        private Button button8;
        public Panel panel5;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button1;
        private Panel panel4;
        private Label label2;
        private Label label1;
        private Label label4;
        private PictureBox pictureBox1;
    }
}