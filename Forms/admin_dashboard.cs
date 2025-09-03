using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
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
using SysColor = System.Drawing.Color;


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

            button15.BackColor = SysColor.FromArgb(9, 132, 227);
            button13.BackColor = SysColor.Gray;

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

            button15.BackColor = SysColor.Gray;
            button13.BackColor = SysColor.FromArgb(129, 236, 236);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button15.Enabled = true;
            button13.Enabled = false;
            button10.Enabled = true;

            button15.BackColor = SysColor.FromArgb(9, 132, 227);
            button13.BackColor = SysColor.Gray;

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

                button15.BackColor = SysColor.FromArgb(9, 132, 227);
                button13.BackColor = SysColor.Gray;
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
            showFuncPanel.ShowFuncPanel(panel13);
            showFuncPanel.displayUnitTble(listView4, "");

            button22.Enabled = true;
            button24.Enabled = false;
            button23.Enabled = true;

            button22.BackColor = SysColor.FromArgb(9, 132, 227);
            button24.BackColor = SysColor.Gray;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "" || comboBox3.Text == "" || textBox15.Text == "" || textBox8.Text == "" || textBox17.Text == "" || textBox16.Text == "" || dateTimePicker1.Value.Date <= DateTime.Now.Date)
            {
                textBox14.Focus();
                MessageBox.Show("⚠️ Fill up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                functions_system showFuncPanel = new functions_system();
                showFuncPanel.validateProductBarcode(this, textBox14.Text);
                showFuncPanel.searchProducts(listView3, "");
                textBox14.Focus();
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            functions_system showFuncPanel = new functions_system();
            showFuncPanel.clearAddNewProductForm(this);
            textBox14.Focus();

            button16.Enabled = true;
            button18.Enabled = false;
            button17.Enabled = true;

            button18.BackColor = SysColor.Gray;
            button16.BackColor = SysColor.FromArgb(9, 132, 227);
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

            button16.BackColor = SysColor.Gray;
            button18.BackColor = SysColor.FromArgb(129, 236, 236);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "" || comboBox4.Text == "" || textBox15.Text == "" || textBox8.Text == "" || textBox17.Text == ""
                || textBox16.Text == "" || label15.Text == "" || label15.Text == "product_id")
            {
                textBox14.Focus();
                MessageBox.Show("⚠️ Fill up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                functions_system updateProductInfo = new functions_system();
                updateProductInfo.updateProductDetails(this);

                button16.Enabled = true;
                button18.Enabled = false;
                button17.Enabled = true;

                button18.BackColor = SysColor.Gray;
                button16.BackColor = SysColor.FromArgb(9, 132, 227);

                updateProductInfo.searchProducts(listView3, "");
                updateProductInfo.clearAddNewProductForm(this);
                textBox14.Focus();
            }
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

        private void button21_Click(object sender, EventArgs e)
        {
            functions_system showFuncPanel = new functions_system();
            showFuncPanel.ShowFuncPanel(panel11);
            showFuncPanel.getProductCategoryToProductInventoryFormCB(this);
            showFuncPanel.getProductUnitToProductInventoryFormCB(this);
            showFuncPanel.searchProducts(listView3, "");
            textBox14.Focus();

            button16.Enabled = true;
            button18.Enabled = false;
            button17.Enabled = true;

            button18.BackColor = SysColor.Gray;
            button16.BackColor = SysColor.FromArgb(9, 132, 227);
        }

        private void listView4_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                string id = listView4.SelectedItems[0].SubItems[0].Text;
                functions_system getUser = new functions_system();
                getUser.getUnitDetailsToForm(id, this);
            }
            button22.Enabled = false;
            button24.Enabled = true;
            button23.Enabled = true;

            button22.BackColor = SysColor.Gray;
            button24.BackColor = SysColor.FromArgb(129, 236, 236);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            clearUnitForm();
            button22.Enabled = true;
            button24.Enabled = false;
            button23.Enabled = true;

            button22.BackColor = SysColor.FromArgb(9, 132, 227);
            button24.BackColor = SysColor.Gray;
        }

        public void clearUnitForm()
        {
            label37.Text = "";
            textBox19.Text = "";
            textBox18.Text = "";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox19.Text == "")
            {
                MessageBox.Show("⚠️ Fill up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string unitName = textBox19.Text;
                string description = textBox18.Text;

                functions_system addCategory = new functions_system();
                addCategory.add_new_productUnit(unitName, description);
                addCategory.displayUnitTble(listView4, "");
                clearUnitForm();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (textBox19.Text == "" || textBox18.Text == "" || label37.Text == "" || label37.Text == "unit_id")
            {
                MessageBox.Show("⚠️ Fill up the form properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string unitId = label37.Text;
                string unitName = textBox19.Text;
                string description = textBox18.Text;
                functions_system updateProductUnit = new functions_system();
                updateProductUnit.updateProductUnitDetails(unitId, unitName, description);

                button22.Enabled = true;
                button24.Enabled = false;
                button23.Enabled = true;

                button22.BackColor = SysColor.FromArgb(9, 132, 227);
                button24.BackColor = SysColor.Gray;
                updateProductUnit.displayUnitTble(listView4, "");
                clearUnitForm();
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            string search = textBox20.Text;
            functions_system searchUnit = new functions_system();
            searchUnit.displayUnitTble(listView4, search);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string search = textBox11.Text;
            functions_system searchProductsFunc = new functions_system();
            searchProductsFunc.searchProducts(listView3, search);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            functions_system showFuncPanel = new functions_system();
            showFuncPanel.ShowFuncPanel(panel15);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var fn = new functions_system();

            DateTime startDate = dateTimePicker3.Value;
            DateTime endDate = dateTimePicker2.Value;

            var reportData = fn.GetSalesReport(startDate, endDate);

            // ✅ Check here before generating
            if (reportData.Count == 0)
            {
                MessageBox.Show("No records found for the selected date range.");
                return;
            }

            var report = new SalesReportDocument(reportData, startDate, endDate);


            // 🔽 Use SaveFileDialog instead of hardcoding the filename
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"JANMPOS_SalesReport_{DateTime.Now:yyyyMMddHHmm}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    report.GeneratePdf(saveFileDialog.FileName);
                    MessageBox.Show("Report saved: " + saveFileDialog.FileName);
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker3.Value;
            DateTime endDate = dateTimePicker2.Value;
            functions_system showFuncPanel = new functions_system();
            showFuncPanel.filterSales(listView5, startDate, endDate);
        }
    }
}
