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
    public partial class Add_Item : Form
    {
        private cashier_dashboard _cashierForm;
        public Add_Item(cashier_dashboard form)
        {
            InitializeComponent();
            this.KeyPreview = true;
            textBox1.Focus();
            _cashierForm = form;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            functions_system searchItem = new functions_system();
            searchItem.search_products_cashier(dataGridView1, textBox1.Text);
        }

        private void Add_Item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                textBox1.Focus();
            }

            if (e.Control && e.KeyCode == Keys.T)
            {
                dataGridView1.Focus();
            }

            if (e.KeyCode == Keys.F1)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string barcode = row.Cells["Column7"].Value.ToString();

                if (row.Cells["Column7"].Value == "")
                {
                    MessageBox.Show("⚠️ Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string quantity = "1";

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

            if (e.KeyCode == Keys.Escape)
            {
                textBox1.Focus();
                this.Close();
            }
        }

        private void Add_Item_Load(object sender, EventArgs e)
        {
            functions_system searchItem = new functions_system();
            searchItem.search_products_cashier(dataGridView1, "");
            textBox1.Focus();
        }
    }
}
