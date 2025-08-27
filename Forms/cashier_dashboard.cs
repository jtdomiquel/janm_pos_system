using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace jandm_pos.Forms
{
    public partial class cashier_dashboard : Form
    {
        public cashier_dashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to LOGOUT ??",
                    "DONE",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string userId = label34.Text;
                functions_system logOutUser = new functions_system();
                logOutUser.logOutUser(userId, this);
            }
        }

        private void cashier_dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) // Example: press F1
            {
                MessageBox.Show("F1 was pressed!");
                // Execute your command here
            }

            if (e.KeyCode == Keys.F2) // Example: press F1
            {
                var showForm = new quantity(this);
                showForm.Show();
            }

            if (e.KeyCode == Keys.F8) // Example: press F1
            {
                textBox1.Focus();
            }

            if (e.Control && e.KeyCode == Keys.D)  // Ctrl + D
            {
                functions_system showDashboard = new functions_system();
                showDashboard.ShowFuncPanelCashier(panel11);
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            functions_system showDashboard = new functions_system();
            showDashboard.ShowFuncPanelCashier(panel11);
            textBox1.Focus();
        }

        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // when scanner sends Enter
            {

                string barcode = textBox1.Text.Trim();

                if (!string.IsNullOrEmpty(barcode))
                {
                    functions_system addPendingTransaction = new functions_system();
                    addPendingTransaction.getProductDetailsToFormCashier(barcode, this);

                    int userId = int.Parse(label34.Text.Trim());
                    decimal quantity = 1;
                    decimal price = decimal.Parse(label17.Text);

                    addPendingTransaction.add_new_productInPendingTransaction(userId, barcode, quantity, price);
                    addPendingTransaction.display_pending_transactions_cashier(dataGridView1);
                    addPendingTransaction.getTotalAmountPendingTransactionCashier(this);
                    addPendingTransaction.clearCashierFormTransaction(this);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            quantity quanForm = new quantity(this);
            if (quanForm.Visible == false)
            {
                var showForm = new quantity(this);
                showForm.Show();
            }

        }
        
    }
}
