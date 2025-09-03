using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jandm_pos.Forms
{
    public partial class checkOutForm : Form
    {
        private cashier_dashboard _cashierForm;
        public checkOutForm(cashier_dashboard form)
        {
            InitializeComponent();
            this.KeyPreview = true;
            _cashierForm = form;
        }

        private void checkOutForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            decimal totalAmount = decimal.Parse(_cashierForm.textBox2.Text);
            label5.Text = totalAmount.ToString("N2");
        }

        private void checkOutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (textBox2.Text == "0" || textBox2.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("⚠️ Please fill-up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int userId = int.Parse(_cashierForm.label34.Text);
                decimal totalAmount = decimal.Parse(label5.Text);
                decimal totalChange = decimal.Parse(label6.Text);
                decimal totalCash = decimal.Parse(textBox2.Text);
                string customerName = textBox1.Text;

                if (totalChange < 0)
                {
                    MessageBox.Show("⚠️ Insufficient Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string cashierName = _cashierForm.label1.Text + ", " + _cashierForm.label4.Text;
                functions_system checkOutItems = new functions_system();
                checkOutItems.CheckoutTransaction(this, userId, cashierName, totalCash, customerName);
                checkOutItems.display_pending_transactions_cashier(_cashierForm.dataGridView1);
                checkOutItems.getTotalAmountPendingTransactionCashier(_cashierForm);
                _cashierForm.textBox1.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions_system validateLetters = new functions_system();
            validateLetters.ValidateLetters(e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            decimal totalCash = 0;
            if (textBox2.Text=="") 
            {
                totalCash = 0;
            }
            else
            {
                totalCash = decimal.Parse(textBox2.Text);
            }
            decimal totalAmount = decimal.Parse(_cashierForm.textBox2.Text);
            decimal totalChange = totalCash - totalAmount;

            label6.Text = totalChange.ToString("N2");
        }
    }
}
