using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using static jandm_pos.Forms.cashier_dashboard;
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

        public void login_user(string username, string password, LoginForm loginForm)
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
                SELECT user_id, role, is_active, firstname, middlename, lastname 
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
                                loginForm.Hide();
                                admin_dashboard admin = new admin_dashboard();
                                admin.label34.Text = reader["user_id"].ToString();
                                admin.label4.Text = reader["firstname"].ToString();
                                admin.label1.Text = reader["lastname"].ToString();
                                admin.label2.Text = reader["role"].ToString();
                                admin.Show();
                                
                            }
                            else if (role == "Cashier")
                            {
                                loginForm.Hide();
                                cashier_dashboard cashier = new cashier_dashboard();
                                cashier.label34.Text = reader["user_id"].ToString();
                                cashier.label4.Text = reader["firstname"].ToString();
                                cashier.label1.Text = reader["lastname"].ToString();
                                cashier.label2.Text = reader["role"].ToString();

                                cashier.Show();
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

            if (admin_Dashboard.panel11.Visible)
            {
                admin_Dashboard.panel11.Visible = false;
            }

            if (admin_Dashboard.panel13.Visible)
            {
                admin_Dashboard.panel13.Visible = false;
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


        public void HideFuncPanelCashier()
        {
            cashier_dashboard cashier_Dashboard = new cashier_dashboard();

            if (cashier_Dashboard.panel11.Visible)
            {
                cashier_Dashboard.panel11.Visible = false;
            }
        }


        public void ShowFuncPanelCashier(Panel submenu)
        {
            if (!submenu.Visible)
            {
                HideFuncPanelCashier();
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
                MessageBox.Show("⚠️ Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void add_new_productUnit(string unitName, string description)
        {

            if (string.IsNullOrEmpty(unitName))
            {
                MessageBox.Show("⚠️ Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO product_unit 
                                (unit, description, date_save) 
                                VALUES (@unit_name, @description, @date_save)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@unit_name", unitName);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@date_save", DateTime.Now);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Product Unit added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void displayUnitTble(ListView targetListView, string search)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM product_unit" +
                    " WHERE `unit` LIKE '" + search + "%' " +
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

        public void getUnitDetailsToForm(string unitId, admin_dashboard userForm)
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"
                SELECT * FROM `product_unit`
                WHERE product_unit.`id` = @unitId";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@unitId", unitId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    userForm.label37.Text = dt.Rows[0][0].ToString();
                    userForm.textBox19.Text = dt.Rows[0][1].ToString();
                    userForm.textBox18.Text = dt.Rows[0][2].ToString();

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

        public void updateProductUnitDetails(string unitId, string unitName, string description)
        {

            using (var conn = Database.GetConnection())
            {
                string sql = @"UPDATE product_unit 
                       SET unit = @unit_name, 
                           description = @description
                       WHERE id = @unitId";

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@unit_name", unitName);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@unitId", unitId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Product unit updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void getProductCategoryToProductInventoryFormCB(admin_dashboard userForm)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, category_name FROM product_category";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                // bind DataTable directly to ComboBox
                userForm.comboBox3.DataSource = dt;
                userForm.comboBox3.DisplayMember = "category_name"; // show category name
                userForm.comboBox3.ValueMember = "id";     // save category ID
                
            }
        }

        public void getProductUnitToProductInventoryFormCB(admin_dashboard userForm)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, unit FROM product_unit";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                // bind DataTable directly to ComboBox
                userForm.comboBox4.DataSource = dt;
                userForm.comboBox4.DisplayMember = "unit"; // show category name
                userForm.comboBox4.ValueMember = "id";     // save category ID

            }
        }




        private string GenerateUniqueBarcode()
        {
            return "P" + DateTime.Now.ToString("yyyyMMddHHmmssfff"); // e.g., P20250816121030123
        }

        public void addNewProductInventory(admin_dashboard userForm)
        {
            string barcodeFolder = Path.Combine(Application.StartupPath, "barcodes");

            string imgPath = userForm.textBox13.Text.Trim();
            int productCategoryId = (int)userForm.comboBox3.SelectedValue;
            int productUnitId = (int)userForm.comboBox4.SelectedValue;
            string barcode = userForm.textBox14.Text.Trim();

            if (string.IsNullOrEmpty(barcode))
            {
                barcode = GenerateUniqueBarcode();
            }

            string productName = userForm.textBox15.Text.Trim();
            string descriptions = userForm.textBox8.Text.Trim();
            decimal price = decimal.Parse(userForm.textBox17.Text);
            decimal stockQuantity = decimal.Parse(userForm.textBox16.Text);
            DateTime expiryDate = userForm.dateTimePicker1.Value;


            using (var conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO products
                            (name, barcode, price, category_id, unit_id, description, 
                             stock_quantity, expiry_date, img_path, date_save)
                            VALUES (@name, @barcode, @price, @categoryId, @unitId, @description, 
                                    @stockQuantity, @expiryDate, @imgPath, @dateSave)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", productName);
                        cmd.Parameters.AddWithValue("@barcode", barcode);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@categoryId", productCategoryId);
                        cmd.Parameters.AddWithValue("@unitId", productUnitId);
                        cmd.Parameters.AddWithValue("@description", descriptions);
                        cmd.Parameters.AddWithValue("@stockQuantity", stockQuantity);
                        cmd.Parameters.AddWithValue("@expiryDate", expiryDate);
                        cmd.Parameters.AddWithValue("@imgPath", imgPath);
                        cmd.Parameters.AddWithValue("@dateSave", DateTime.Now);  // ✅ Direct DateTime

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearAddNewProductForm(userForm);
                        }
                        else
                        {
                            MessageBox.Show("⚠️ Failed to add product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error: " + ex.Message);
                }
            }
        }

        public void clearAddNewProductForm(admin_dashboard userForm)
        {
            using (var conn = Database.GetConnection())
            {
                userForm.label15.Text = "";
                userForm.textBox13.Text = "";
                userForm.comboBox3.SelectedValue = "1";
                userForm.textBox14.Text = "";
                userForm.textBox15.Text = "";
                userForm.textBox8.Text = "";
                userForm.textBox17.Text = "";
                userForm.textBox16.Text = "";
                userForm.dateTimePicker1.Value = DateTime.Now;
                userForm.pictureBox5.Image = Properties.Resources.no_image;


            }
        }


        public void ValidateLetters(KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void searchProducts(ListView targetListView, string search)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM products" +
                    " INNER JOIN product_category ON products.`category_id` = product_category.`id` " +
                    " INNER JOIN product_unit ON products.`unit_id` = product_unit.`id` " +
                    " WHERE products.`barcode` LIKE '" + search + "%' " +
                    " OR products.`name` LIKE '" + search + "%' " +
                    " OR products.`description` LIKE '" + search + "%' " +
                    " OR products.`price` LIKE '" + search + "%' " +
                    " OR product_unit.`unit` LIKE '" + search + "%' " +
                    " OR product_category.`category_name` LIKE '" + search + "%' ";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                targetListView.Items.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(row[0]));
                    item.SubItems.Add(Convert.ToString(row[3]));
                    item.SubItems.Add(Convert.ToString(row[4]));
                    item.SubItems.Add(Convert.ToString(row[13]));
                    item.SubItems.Add(Convert.ToString(row[18]));
                    item.SubItems.Add(Convert.ToString(row[6]));
                    item.SubItems.Add(Convert.ToString(row[7]));
                    item.SubItems.Add(Convert.ToString(row[5]));
                    item.SubItems.Add(Convert.ToString(row[8]));
                    item.SubItems.Add(Convert.ToString(row[10]));

                    targetListView.Items.Add(item);
                }
            }
        }

        public void getProductDetailsToForm(string productId, admin_dashboard userForm)
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"
                   SELECT 
                        products.product_id,
                        products.name,
                        products.barcode,
                        products.description AS product_description,
                        products.price,
                        products.stock_quantity,
                        products.expiry_date,
                        products.img_path,
                        product_category.id AS category_id,
                        product_category.category_name AS category_name,
                        product_unit.id AS unit_id,
                        product_unit.unit AS unit
                    FROM products
                    INNER JOIN product_category 
                        ON products.category_id = product_category.id
                    INNER JOIN product_unit 
                        ON products.unit_id = product_unit.id
                    WHERE products.`product_id` = @prodId";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@prodId", productId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    userForm.label15.Text = dt.Rows[0]["product_id"].ToString();

                    if (!string.IsNullOrEmpty(dt.Rows[0]["img_path"].ToString()))
                    {
                        userForm.pictureBox5.Image = Image.FromFile(dt.Rows[0]["img_path"].ToString());
                    }
                    else
                    {
                        userForm.pictureBox5.Image = Properties.Resources.no_image;
                    }

                    userForm.comboBox3.Text = dt.Rows[0]["category_name"].ToString();
                    userForm.comboBox4.Text = dt.Rows[0]["unit"].ToString();
                    userForm.textBox14.Text = dt.Rows[0]["barcode"].ToString();
                    userForm.textBox15.Text = dt.Rows[0]["name"].ToString();
                    userForm.textBox8.Text = dt.Rows[0]["product_description"].ToString();
                    userForm.textBox17.Text = dt.Rows[0]["price"].ToString();
                    userForm.textBox16.Text = dt.Rows[0]["stock_quantity"].ToString();
                    userForm.dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0]["expiry_date"]);
                    userForm.textBox13.Text = dt.Rows[0]["img_path"].ToString();

                }
            }
        }

        public void updateProductDetails(admin_dashboard userForm)
        {
            string productId = userForm.label15.Text.Trim();
            string barcodeFolder = Path.Combine(Application.StartupPath, "barcodes");

            string imgPath = userForm.textBox13.Text.Trim();
            int productCategoryId = (int)userForm.comboBox3.SelectedValue;
            int productUnitId = (int)userForm.comboBox4.SelectedValue;
            string barcode = userForm.textBox14.Text.Trim();

            if (string.IsNullOrEmpty(barcode))
            {
                barcode = GenerateUniqueBarcode();
            }

            string productName = userForm.textBox15.Text.Trim();
            string descriptions = userForm.textBox8.Text.Trim();
            decimal price = decimal.Parse(userForm.textBox17.Text);
            decimal stockQuantity = decimal.Parse(userForm.textBox16.Text);
            DateTime expiryDate = userForm.dateTimePicker1.Value;

            using (var conn = Database.GetConnection())
            {
                string sql = @"UPDATE products 
                       SET category_id = @category_id,
                           unit_id = @unit_id,
                           barcode = @barcode, 
                           name = @name, 
                           description = @description, 
                           price = @price, 
                           stock_quantity = @stock_quantity, 
                           expiry_date = @expiry_date, 
                           img_path = @img_path
                       WHERE product_id = @prodId";

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@category_id", productCategoryId);
                        cmd.Parameters.AddWithValue("@unit_id", productUnitId);
                        cmd.Parameters.AddWithValue("@barcode", barcode);
                        cmd.Parameters.AddWithValue("@name", productName);
                        cmd.Parameters.AddWithValue("@description", descriptions);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@stock_quantity", stockQuantity);
                        cmd.Parameters.AddWithValue("@expiry_date", expiryDate);
                        cmd.Parameters.AddWithValue("@img_path", imgPath);
                        cmd.Parameters.AddWithValue("@prodId", productId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Product Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearAddNewProductForm(userForm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void logOutUser(string userId, Form currentForm)
        {
            // Close or hide the current form
            currentForm.Hide();   // or currentForm.Close();

            // Show login form again
            LoginForm login = new LoginForm();
            login.Show();
        }


        public void add_new_productInPendingTransaction(int userId, string barcode, decimal quantity, decimal price)
        {

            if (string.IsNullOrEmpty(barcode))
            {
                MessageBox.Show("⚠️ Barcode required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalPrice = quantity * price;

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO pending_transactions 
                                (user_id, barcode, quantity, price, total_price, date_save) 
                                VALUES (@userId, @barcode, @quantity, @price, @totalPrice, @dateSave)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                    cmd.Parameters.AddWithValue("@dateSave", DateTime.Now);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

        }

        public void display_pending_transactions_cashier(DataGridView dgv)
        {
            using (var conn = Database.GetConnection()) 
            {
                string query = @"
                           SELECT 
                             pending_transactions.id,
                             pending_transactions.barcode,
                             pending_transactions.quantity,
                             pending_transactions.price as transaction_price,
                             pending_transactions.total_price,
                             pending_transactions.date_save as transaction_data_save,
                             products.name,
                             products.price,
                             products.stock_quantity,
                             products.expiry_date,
                             products.img_path,
                             product_unit.unit
                         FROM pending_transactions
                         INNER JOIN products 
                             ON pending_transactions.barcode = products.barcode
                         INNER JOIN product_unit ON products.`unit_id` = product_unit.`id`
                          ORDER BY pending_transactions.id DESC";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    Image img = null;
                    string imgPath = row["img_path"].ToString();

                    if (File.Exists(imgPath))
                    {
                        img = Image.FromFile(imgPath);
                    }

                    dgv.Rows.Add(
                        row["id"].ToString(),
                        img,
                        row["barcode"].ToString(),
                        row["quantity"].ToString(),
                        row["unit"].ToString(),
                        row["name"].ToString(),
                        row["transaction_price"].ToString(),
                        row["total_price"].ToString()

                    );
                }

            }
        }


        public void getProductDetailsToFormCashier(string barcode, cashier_dashboard userForm)
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"
                   SELECT 
                        products.product_id,
                        products.name,
                        products.barcode,
                        products.price,
                        products.img_path,
                        product_category.id AS category_id,
                        product_category.category_name AS category_name,
                        product_unit.id AS unit_id,
                        product_unit.unit AS unit
                    FROM products
                    INNER JOIN product_category 
                        ON products.category_id = product_category.id
                    INNER JOIN product_unit 
                        ON products.unit_id = product_unit.id
                    WHERE products.`barcode` = @barcode";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@barcode", barcode);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    decimal price;
                    if (Convert.IsDBNull(dt.Rows[0]["price"]))
                    {
                        price = 0; // Or whatever default you want
                    }
                    else
                    {
                        price = (decimal)dt.Rows[0]["price"];
                    }

                    userForm.label7.Text = dt.Rows[0]["name"].ToString();
                    userForm.label17.Text = price.ToString("N2");
                    if (!string.IsNullOrEmpty(dt.Rows[0]["img_path"].ToString()))
                    {
                        userForm.pictureBox5.Image = Image.FromFile(dt.Rows[0]["img_path"].ToString());
                    }
                    else
                    {
                        userForm.pictureBox5.Image = Properties.Resources.no_image;
                    }


                }
            }
        }

        public void getTotalAmountPendingTransactionCashier(cashier_dashboard userForm)
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"
                   SELECT SUM(total_price) as totalAmount, SUM(quantity) as totalItem FROM pending_transactions";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    decimal totalamount;
                    if (Convert.IsDBNull(dt.Rows[0]["totalAmount"]))
                    {
                        totalamount = 0; // Or whatever default you want
                    }
                    else
                    {
                        totalamount = (decimal)dt.Rows[0]["totalAmount"];
                    }

                    decimal totalItem;
                    if (Convert.IsDBNull(dt.Rows[0]["totalItem"]))
                    {
                        totalItem = 0; // Or whatever default you want
                    }
                    else
                    {
                        totalItem = (decimal)dt.Rows[0]["totalItem"];
                    }
                    userForm.textBox2.Text = totalamount.ToString("N2");
                    userForm.textBox3.Text = totalamount.ToString("N2");
                    userForm.textBox4.Text = totalItem.ToString("N0");

                }
            }
        }

        public void clearCashierFormTransaction(cashier_dashboard useForm) 
        {
            useForm.label7.Text = "Product Name";
            useForm.label17.Text = "0";
            useForm.pictureBox5.Image = Properties.Resources.no_image;
            useForm.textBox1.Clear();
            useForm.textBox1.Focus();
        }

        public void deletePendingTransaction(string userId)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM pending_transactions WHERE user_id = @user_id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("✅ Pending Transaction successfully canceled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("⚠️ Transaction not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void deleteItemPendingTransaction(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM pending_transactions WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("✅ Pending Transaction successfully canceled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("⚠️ Transaction not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void search_products_cashier(DataGridView dgv, string search)
        {
            using (var conn = Database.GetConnection())
            {
                string query = " SELECT * FROM products"+
                    " INNER JOIN product_unit ON products.unit_id = product_unit.id"+
                    " WHERE products.`barcode` LIKE '" + search + "%' " +
                    " OR products.`name` LIKE '" + search + "%' " +
                    " OR products.`description` LIKE '" + search + "%' " +
                    " OR products.`price` LIKE '" + search + "%' ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    Image img = null;
                    string imgPath = row["img_path"].ToString();

                    if (File.Exists(imgPath))
                    {
                        img = Image.FromFile(imgPath);
                    }

                    dgv.Rows.Add(
                        row["product_id"].ToString(),
                        img,
                        row["barcode"].ToString(),
                        row["unit"].ToString(),
                        row["name"].ToString(),
                        row["price"].ToString()

                    );
                }

            }
        }


    }
}
