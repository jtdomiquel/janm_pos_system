namespace jandm_pos.Forms
{
    partial class quantity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(quantity));
            pictureBox5 = new PictureBox();
            label10 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label11 = new Label();
            button3 = new Button();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox5
            // 
            pictureBox5.BorderStyle = BorderStyle.FixedSingle;
            pictureBox5.Image = Properties.Resources.jan_m_logo_removebg_preview;
            pictureBox5.Location = new Point(124, 28);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(191, 197);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 34;
            pictureBox5.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(46, 248);
            label10.Name = "label10";
            label10.Size = new Size(71, 21);
            label10.TabIndex = 38;
            label10.Text = "Barcode";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(46, 272);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(332, 33);
            textBox1.TabIndex = 37;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 327);
            label1.Name = "label1";
            label1.Size = new Size(72, 21);
            label1.TabIndex = 40;
            label1.Text = "Quantity";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(46, 351);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(332, 33);
            textBox2.TabIndex = 39;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Turquoise;
            label11.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label11.Location = new Point(174, 430);
            label11.Name = "label11";
            label11.Size = new Size(78, 21);
            label11.TabIndex = 42;
            label11.Text = "PROCEED";
            // 
            // button3
            // 
            button3.BackColor = Color.Turquoise;
            button3.Enabled = false;
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(46, 410);
            button3.Name = "button3";
            button3.Size = new Size(332, 59);
            button3.TabIndex = 41;
            button3.Text = "F1";
            button3.TextAlign = ContentAlignment.TopLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PaleVioletRed;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(176, 492);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 44;
            label2.Text = "CANCEL";
            // 
            // button1
            // 
            button1.BackColor = Color.PaleVioletRed;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(46, 475);
            button1.Name = "button1";
            button1.Size = new Size(332, 59);
            button1.TabIndex = 43;
            button1.Text = "ESC";
            button1.TextAlign = ContentAlignment.TopLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // quantity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(438, 581);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label11);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(label10);
            Controls.Add(textBox1);
            Controls.Add(pictureBox5);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "quantity";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quantity";
            Load += quantity_Load;
            KeyDown += quantity_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public PictureBox pictureBox5;
        private Label label10;
        public TextBox textBox1;
        private Label label1;
        public TextBox textBox2;
        private Label label11;
        private Button button3;
        private Label label2;
        private Button button1;
    }
}