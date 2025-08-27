using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static jandm_pos.Forms.cashier_dashboard;

namespace jandm_pos.Forms
{
    public partial class quantity : Form
    {
        private cashier_dashboard _cashierForm;
        public quantity(cashier_dashboard form)
        {
            InitializeComponent();
            this.KeyPreview = true;
            _cashierForm = form;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions_system validateLetters = new functions_system();
            validateLetters.ValidateLetters(e);
        }

        private void quantity_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

        }

        private void quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (textBox1.Text == "" && (textBox2.Text == "0" || textBox2.Text == ""))
                {
                    MessageBox.Show("⚠️ Fill up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string barcode = textBox1.Text.Trim();
                    string quantity = textBox2.Text.Trim();

                    functions_system addPendingTransaction = new functions_system();
                    addPendingTransaction.getProductDetailsToFormCashier(barcode, _cashierForm);

                    int userId = int.Parse(_cashierForm.label34.Text);
                    decimal quantity_dec = decimal.Parse(quantity);
                    decimal price = decimal.Parse(_cashierForm.label17.Text);

                    addPendingTransaction.add_new_productInPendingTransaction(userId, barcode, quantity_dec, price);
                    addPendingTransaction.display_pending_transactions_cashier(_cashierForm.dataGridView1);
                    addPendingTransaction.getTotalAmountPendingTransactionCashier(_cashierForm);
                    addPendingTransaction.clearCashierFormTransaction(_cashierForm);
                    _cashierForm.textBox1.Focus();
                    this.Close();
                }
                
            }

            if (e.KeyCode == Keys.Escape) // Example: press F1
            {
                textBox1.Text = "";
                textBox2.Text = "";
                _cashierForm.textBox1.Focus();
                this.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // when scanner sends Enter
            {
                textBox2.Focus();
            }

        }

        
    }
}
