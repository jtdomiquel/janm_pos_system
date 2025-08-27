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

        public void clearForm() {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
