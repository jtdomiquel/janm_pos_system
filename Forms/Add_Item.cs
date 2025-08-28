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
    public partial class Add_Item : Form
    {
        public Add_Item()
        {
            InitializeComponent();
            this.KeyPreview = true;
            textBox1.Focus();
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


            }

            if (e.KeyCode == Keys.Escape)
            {
                textBox1.Focus();
                this.Close();
            }
        }

        private void Add_Item_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
