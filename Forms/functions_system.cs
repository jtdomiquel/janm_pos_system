using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
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



        public void HideSubMenu()
        {
            admin_dashboard admin_Dashboard = new admin_dashboard();
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

       
        public void HideFuncPanel()
        {
            admin_dashboard admin_Dashboard = new admin_dashboard();

            if (admin_Dashboard.panel3.Visible)
            {
                admin_Dashboard.panel3.Visible = false;
            }

            if (admin_Dashboard.panel7.Visible)
            {
                admin_Dashboard.panel7.Visible = false;
            }
            
            if (admin_Dashboard.panel9.Visible)
            {
                admin_Dashboard.panel9.Visible = false;
            }
        }

        public void ShowFuncPanel(Panel submenu)
        {
            if (!submenu.Visible)
            {
                HideFuncPanel();
                submenu.Visible = true;
                submenu.BringToFront();
            }
            else
            {
                submenu.Visible = false;
            }
        }

        
        public void searchUsers(ListView targetListView, string search)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM users"+
                    " WHERE users.`firstname` LIKE '" + search + "%' "+
                    " OR users.`middlename` LIKE '" + search + "%' "+
                    " OR users.`lastname` LIKE '" + search + "%' "+
                    " OR users.`role` LIKE '" + search + "%' ";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                targetListView.Items.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(row[0]));
                    item.SubItems.Add(Convert.ToString(row[3]));
                    item.SubItems.Add(Convert.ToString(row[4]));
                    item.SubItems.Add(Convert.ToString(row[5]));
                    item.SubItems.Add(Convert.ToString(row[6]));
                    item.SubItems.Add(Convert.ToString(row[7]));

                    if (Convert.ToBoolean(row[8]))
                    {
                        item.SubItems.Add("Active");
                    }
                    else
                    {
                        item.SubItems.Add("Disable");
                    }

                    item.SubItems.Add(Convert.ToString(row[10]));
                    item.SubItems.Add(Convert.ToString(row[9]));

                    targetListView.Items.Add(item);
                }
            }
        }

        public void updateUserDetails(string userId, string firstname, string middlename, string lastname, string address, string contact_no, 
            bool is_active, string role)
        {
            
            using (var conn = Database.GetConnection())
            {
                string sql = @"UPDATE users 
                       SET firstname = @firstname, 
                           middlename = @middlename, 
                           lastname = @lastname, 
                           address = @address, 
                           contact_no = @contact_no, 
                           is_active = @is_active, 
                           role = @role 
                       WHERE user_id = @userId";

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstname", firstname);
                        cmd.Parameters.AddWithValue("@middlename", middlename);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@contact_no", contact_no);
                        cmd.Parameters.AddWithValue("@is_active", is_active);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User Account Update Successfully.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void getUserDetailsToForm(string userId, admin_dashboard userForm)
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"
                SELECT * FROM `users`
                WHERE users.`user_id` = @userId";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@userId", userId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                   
                    userForm.label18.Text = dt.Rows[0][0].ToString();
                    userForm.textBox2.Text = dt.Rows[0][3].ToString();
                    userForm.textBox4.Text = dt.Rows[0][4].ToString();
                    userForm.textBox5.Text = dt.Rows[0][5].ToString();
                    userForm.textBox3.Text = dt.Rows[0][6].ToString();
                    userForm.textBox6.Text = dt.Rows[0][7].ToString();
               

                    if (Convert.ToBoolean(dt.Rows[0][8]))
                    {
                        userForm.comboBox1.Text = "Activate";
                    }
                    else 
                    {
                        userForm.comboBox1.Text = "Deactivate";
                    }
                    userForm.comboBox2.Text = dt.Rows[0][10].ToString();
                
                }
            }
        }

        public void add_new_productCategory(string categoryName, string description)
        {

            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
       

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO product_category 
                                (category_name, description, date_save) 
                                VALUES (@category_name, @description, @date_save)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@category_name", categoryName);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@date_save", DateTime.Now);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product category added successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

        }

        public void displayCategoriesTble(ListView targetListView, string search)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM product_category"+
                    " WHERE `category_name` LIKE '" + search + "%' " +
                    " OR `description` LIKE '" + search + "%' ";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                targetListView.Items.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(row[0]));
                    item.SubItems.Add(Convert.ToString(row[1]));
                    item.SubItems.Add(Convert.ToString(row[2]));
                    item.SubItems.Add(Convert.ToString(row[3]));

                    targetListView.Items.Add(item);
                }
            }
        }

        public void getProductCategoryDetailsToForm(string categoryId, admin_dashboard userForm)
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"
                SELECT * FROM `product_category`
                WHERE product_category.`id` = @prodId";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@prodId", categoryId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    userForm.label13.Text = dt.Rows[0][0].ToString();
                    userForm.textBox10.Text = dt.Rows[0][1].ToString();
                    userForm.textBox7.Text = dt.Rows[0][2].ToString();

                }
            }
        }

        public void updateProductCategoryDetails(string prodId, string categoryName, string description)
        {

            using (var conn = Database.GetConnection())
            {
                string sql = @"UPDATE product_category 
                       SET category_name = @category_name, 
                           description = @description
                       WHERE id = @prodId";

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@category_name", categoryName);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@prodId", prodId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product category updated successfully.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
