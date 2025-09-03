namespace jandm_pos.Forms
{
    partial class POSReportApp
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
            label40 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            button24 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button24);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label40);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 646);
            panel1.TabIndex = 0;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.FlatStyle = FlatStyle.Flat;
            label40.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label40.ForeColor = Color.Black;
            label40.Location = new Point(3, 0);
            label40.Name = "label40";
            label40.Size = new Size(145, 21);
            label40.TabIndex = 10;
            label40.Text = "SALES REPORTING";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 12F);
            dateTimePicker1.Location = new Point(3, 46);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(256, 29);
            dateTimePicker1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 31);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 12;
            label1.Text = "Start Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 31);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 14;
            label2.Text = "End Date";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Font = new Font("Segoe UI", 12F);
            dateTimePicker2.Location = new Point(266, 46);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(256, 29);
            dateTimePicker2.TabIndex = 13;
            // 
            // button24
            // 
            button24.BackColor = Color.FromArgb(129, 236, 236);
            button24.FlatStyle = FlatStyle.Flat;
            button24.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button24.Location = new Point(528, 46);
            button24.Name = "button24";
            button24.Size = new Size(243, 29);
            button24.TabIndex = 31;
            button24.Text = "Filter";
            button24.UseVisualStyleBackColor = false;
            // 
            // POSReportApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(800, 670);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "POSReportApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POSReportApp";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label40;
        private Button button24;
    }
}