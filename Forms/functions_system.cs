using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace jandm_pos.Forms
{
    internal class functions_system
    {
        public void add_new_user(string firstname, string middlename, string lastname, string address, 
            string contact, string username, string password, string confirmPassword, string role) {

            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (confirmPassword != password)
            {
                MessageBox.Show("Password and Confirm Password not match.");
                return;
            }

            string passwordHash = HashPassword(password);

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO users 
                                (firstname, middlename, lastname, address, contact_no, username, password_hash, is_active, role) 
                                VALUES (@firstname, @middlename, @lastname, @address, @contact, @username, @password_hash, 0, @role)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@middlename", middlename);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", passwordHash);
                    cmd.Parameters.AddWithValue("@role", role);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account created successfully! Waiting for admin activation.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public void login_user(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT role, is_active 
                FROM users 
                WHERE username = @username 
                AND password_hash = SHA2(@password, 256)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isActive = Convert.ToBoolean(reader["is_active"]);
                            string role = reader["role"].ToString();

                            if (!isActive)
                            {
                                MessageBox.Show("Your account is not active. Please contact the admin.");
                                return;
                            }

                            if (role == "Admin")
                            {
                                
                                admin_dashboard admin = new admin_dashboard();
                                admin.Show();
                                
                            }
                            else if (role == "Cashier")
                            {
                                MessageBox.Show("Cashier Dashboard!!");
                            }
                            else
                            {
                                MessageBox.Show($"Welcome, {role}!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
            }
        }

        admin_dashboard admin_Dashboard = new admin_dashboard();
        
        public void HideSubMenu()
        {
            if (admin_Dashboard.panel5.Visible)
            {
                admin_Dashboard.panel5.Visible = false;
            }
            if (admin_Dashboard.panel6.Visible)
            {
                admin_Dashboard.panel6.Visible = false;
            }
        }

        public void ShowSubMenu(Panel submenu)
        {
            if (!submenu.Visible)
            {
                HideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

    }
}
