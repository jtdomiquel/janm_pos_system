using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace jandm_pos.Forms
{
    public partial class admin_dashboard : Form
    {
        public admin_dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            functions_system showSubPanel = new functions_system();
            showSubPanel.ShowSubMenu(panel5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            functions_system showSubPanel = new functions_system();
            showSubPanel.ShowSubMenu(panel6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            functions_system showFuncPanel = new functions_system();
            showFuncPanel.ShowFuncPanel(panel7);
            showFuncPanel.searchUsers(listView1, "");

        }


        public void clearUserForm()
        {
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            clearUserForm();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string id = listView1.SelectedItems[0].SubItems[0].Text;
                functions_system getUser = new functions_system();
                getUser.getUserDetailsToForm(id, this);
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string userId = label18.Text.Trim();
            string firstname = textBox2.Text.Trim();
            string middlename = textBox4.Text.Trim();
            string lastname = textBox5.Text.Trim();
            string address = textBox3.Text.Trim();
            string contact = textBox6.Text.Trim();
            string role = comboBox2.Text;

            bool isActive = false;

            if (comboBox1.Text == "Activate")
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }


            functions_system updateUser = new functions_system();
            updateUser.updateUserDetails(userId, firstname, middlename, lastname, address, contact, isActive, role);
            updateUser.searchUsers(listView1, "");
            clearUserForm();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            functions_system loadFunctions = new functions_system();
            loadFunctions.searchUsers(listView1, search);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            functions_system showFuncPanel = new functions_system();
            showFuncPanel.ShowFuncPanel(panel9);
            showFuncPanel.displayCategoriesTble(listView2, "");

            button15.Enabled = true;
            button13.Enabled = false;
            button10.Enabled = true;

            button15.BackColor = Color.FromArgb(9, 132, 227);
            button13.BackColor = Color.Gray;

        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                string id = listView2.SelectedItems[0].SubItems[0].Text;
                functions_system getUser = new functions_system();
                getUser.getProductCategoryDetailsToForm(id, this);
            }
            button15.Enabled = false;
            button13.Enabled = true;
            button10.Enabled = true;

            button15.BackColor = Color.Gray;
            button13.BackColor = Color.FromArgb(129, 236, 236);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button15.Enabled = true;
            button13.Enabled = false;
            button10.Enabled = true;

            button15.BackColor = Color.FromArgb(9, 132, 227);
            button13.BackColor = Color.Gray;

            clearCategoryForm();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("⚠️ Fill up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string categoryName = textBox10.Text;
                string description = textBox7.Text;

                functions_system addCategory = new functions_system();
                addCategory.add_new_productCategory(categoryName, description);
                addCategory.displayCategoriesTble(listView2, "");
                clearCategoryForm();
            }

        }

        public void clearCategoryForm()
        {
            label13.Text = "";
            textBox10.Text = "";
            textBox7.Text = "";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string search = textBox12.Text;
            functions_system searchCategory = new functions_system();
            searchCategory.displayCategoriesTble(listView2, search);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" || textBox7.Text == "" || label13.Text == "" || label13.Text == "category_id")
            {
                MessageBox.Show("⚠️ Fill up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string prodId = label13.Text;
                string categoryName = textBox10.Text;
                string description = textBox7.Text;
                functions_system updateProductCategory = new functions_system();
                updateProductCategory.updateProductCategoryDetails(prodId, categoryName, description);

                button15.Enabled = true;
                button13.Enabled = false;
                button10.Enabled = true;

                button15.BackColor = Color.FromArgb(9, 132, 227);
                button13.BackColor = Color.Gray;
                updateProductCategory.displayCategoriesTble(listView2, "");
                clearCategoryForm();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = ofd.FileName;
                pictureBox5.ImageLocation = ofd.FileName; // preview image
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            functions_system showFuncPanel = new functions_system();
            showFuncPanel.ShowFuncPanel(panel11);
            showFuncPanel.getProductCategoryToProductInventoryFormCB(this);
            showFuncPanel.searchProducts(listView3, "");
            textBox14.Focus();

            button16.Enabled = true;
            button18.Enabled = false;
            button17.Enabled = true;

            button18.BackColor = Color.Gray;
            button16.BackColor = Color.FromArgb(9, 132, 227);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "" || comboBox3.Text == "" || textBox15.Text == "" || textBox8.Text == "" || textBox17.Text == "" || textBox16.Text == "" || dateTimePicker1.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("⚠️ Fill up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                functions_system showFuncPanel = new functions_system();
                showFuncPanel.addNewProductInventory(this);
                showFuncPanel.searchProducts(listView3, "");
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            functions_system showFuncPanel = new functions_system();
            showFuncPanel.clearAddNewProductForm(this);

            button16.Enabled = true;
            button18.Enabled = false;
            button17.Enabled = true;

            button18.BackColor = Color.Gray;
            button16.BackColor = Color.FromArgb(9, 132, 227);
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions_system numberOnly = new functions_system();
            numberOnly.ValidateLetters(e);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions_system numberOnly = new functions_system();
            numberOnly.ValidateLetters(e);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            string search = textBox11.Text;
            functions_system searchProductsFunc = new functions_system();
            searchProductsFunc.searchProducts(listView3, search);
        }

        private void listView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                string id = listView3.SelectedItems[0].SubItems[0].Text;
                functions_system getproduct = new functions_system();
                getproduct.getProductDetailsToForm(id, this);
            }
            button16.Enabled = false;
            button18.Enabled = true;
            button17.Enabled = true;

            button16.BackColor = Color.Gray;
            button18.BackColor = Color.FromArgb(129, 236, 236);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "" || comboBox3.Text == "" || textBox15.Text == "" || textBox8.Text == "" || textBox17.Text == "" 
                || textBox16.Text == "" || dateTimePicker1.Value.Date <= DateTime.Now.Date || label15.Text == "" || label15.Text == "product_id")
            {
                MessageBox.Show("⚠️ Fill up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                functions_system updateProductInfo = new functions_system();
                updateProductInfo.updateProductDetails(this);

                button16.Enabled = true;
                button18.Enabled = false;
                button17.Enabled = true;

                button18.BackColor = Color.Gray;
                button16.BackColor = Color.FromArgb(9, 132, 227);

                updateProductInfo.searchProducts(listView3, "");
                updateProductInfo.clearAddNewProductForm(this);
            }
        }
    }
}
