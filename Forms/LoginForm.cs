using jandm_pos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace jandm_pos.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            SignUpForm signUp = new SignUpForm();
            signUp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            functions_system functions_System = new functions_system();
            functions_System.login_user(username, password, this);
            clearForm();
        }

        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
