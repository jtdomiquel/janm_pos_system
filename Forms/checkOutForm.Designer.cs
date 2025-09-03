namespace jandm_pos.Forms
{
    partial class checkOutForm
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
            panel3 = new Panel();
            label6 = new Label();
            label7 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            button1 = new Button();
            label11 = new Label();
            button3 = new Button();
            label1 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label10 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(392, 637);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(28, 405);
            panel3.Name = "panel3";
            panel3.Size = new Size(333, 59);
            panel3.TabIndex = 54;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(159, 17);
            label6.Name = "label6";
            label6.Size = new Size(19, 21);
            label6.TabIndex = 50;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(13, 17);
            label7.Name = "label7";
            label7.Size = new Size(63, 21);
            label7.TabIndex = 49;
            label7.Text = "Change";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(28, 340);
            panel2.Name = "panel2";
            panel2.Size = new Size(333, 59);
            panel2.TabIndex = 53;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label5.Location = new Point(159, 17);
            label5.Name = "label5";
            label5.Size = new Size(23, 25);
            label5.TabIndex = 50;
            label5.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label4.Location = new Point(13, 17);
            label4.Name = "label4";
            label4.Size = new Size(53, 25);
            label4.TabIndex = 49;
            label4.Text = "Total";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PaleVioletRed;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(161, 575);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 52;
            label2.Text = "CANCEL";
            // 
            // button1
            // 
            button1.BackColor = Color.PaleVioletRed;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(31, 558);
            button1.Name = "button1";
            button1.Size = new Size(332, 59);
            button1.TabIndex = 51;
            button1.Text = "ESC";
            button1.TextAlign = ContentAlignment.TopLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Turquoise;
            label11.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label11.Location = new Point(159, 513);
            label11.Name = "label11";
            label11.Size = new Size(78, 21);
            label11.TabIndex = 50;
            label11.Text = "PROCEED";
            // 
            // button3
            // 
            button3.BackColor = Color.Turquoise;
            button3.Enabled = false;
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(31, 493);
            button3.Name = "button3";
            button3.Size = new Size(332, 59);
            button3.TabIndex = 49;
            button3.Text = "F1";
            button3.TextAlign = ContentAlignment.TopLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 267);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 48;
            label1.Text = "Amount *";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(29, 291);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(332, 33);
            textBox2.TabIndex = 47;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 198);
            label3.Name = "label3";
            label3.Size = new Size(139, 21);
            label3.TabIndex = 46;
            label3.Text = "Customer Name *";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(29, 222);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(332, 33);
            textBox1.TabIndex = 45;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(159, 162);
            label10.Name = "label10";
            label10.Size = new Size(79, 21);
            label10.TabIndex = 39;
            label10.Text = "Checkout";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.checkout;
            pictureBox1.Location = new Point(134, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(132, 135);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // checkOutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(418, 661);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "checkOutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "checkOutForm";
            Load += checkOutForm_Load;
            KeyDown += checkOutForm_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label10;
        private Label label2;
        private Button button1;
        private Label label11;
        private Button button3;
        private Label label1;
        public TextBox textBox2;
        private Label label3;
        public TextBox textBox1;
        private Panel panel2;
        private Panel panel3;
        private Label label6;
        private Label label7;
        private Label label5;
        private Label label4;
    }
}