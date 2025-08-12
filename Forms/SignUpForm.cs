using System;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace jandm_pos.Forms
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstname = textBox1.Text.Trim();
            string middlename = textBox2.Text.Trim();
            string lastname = textBox3.Text.Trim();
            string address = textBox4.Text.Trim();
            string contact = textBox5.Text.Trim();
            string username = textBox6.Text.Trim();
            string password = textBox7.Text;
            string confirmPassword = textBox8.Text;
            string role = comboBox1.Text;

            functions_system addUser = new functions_system();

            addUser.add_new_user(firstname, middlename, lastname, address, contact, username, password, confirmPassword, role);
            clearForm();
        }

        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
        }
    }
}
