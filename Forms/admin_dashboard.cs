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
        }

        private void admin_dashboard_Load(object sender, EventArgs e)
        {
            functions_system loadFunctions = new functions_system();
            loadFunctions.displayUsers(listView1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            functions_system loadFunctions = new functions_system();
            loadFunctions.searchUsers(listView1, search);
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
            updateUser.displayUsers(listView1);
            clearUserForm();
        }
    }
}
