using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    internal static class CustomerService
    {
        static TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

        public static void LoadCustomerData(ViewCustomers view)
        {
            string sql = "SELECT customer.customerId, customer.customerName, address.addressId, address.address, " +
                "address.phone, city.cityId, city.city, country.countryId, country.country " +
                "FROM customer " +
                "JOIN address ON address.addressId = customer.addressId " +
                "JOIN city ON city.cityId = address.cityId " +
                "JOIN country ON country.countryId = city.countryId " +
                "ORDER BY customer.customerId";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            view.dataGridView1.DataSource = dt;
        }

        public static void LoadCustomerData(AddAppointment view)
        {
            string sql = "SELECT customerId, customerName, addressId FROM customer";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            view.custNamesDGV.DataSource = dt;
            view.custNamesDGV.Columns["customerId"].Visible = false;
            view.custNamesDGV.Columns["addressId"].Visible = false;
            view.custNamesDGV.Columns["customerName"].HeaderText = "Customer";
        }

        public static void LoadCustomerData(ModifyAppointment view)
        {
            string sql = "SELECT customerId, customerName, addressId FROM customer";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            view.custNamesDGV.DataSource = dt;
            view.custNamesDGV.Columns["customerId"].Visible = false;
            view.custNamesDGV.Columns["addressId"].Visible = false;
            view.custNamesDGV.Columns["customerName"].HeaderText = "Customer";
        }

        public static void AddCustomer(AddCustomer addCustomer)
        {
            try
            {
                if (ValidateCustomer(addCustomer.customerNameText.Text.Trim(), addCustomer.addressText.Text.Trim(), addCustomer.phoneText.Text.Trim()))
                {
                    int countryId = GetOrCreateCountry(DBConnection.conn, ti.ToTitleCase(CheckUpper(addCustomer.countryComboBox.Text.Trim())));
                    int cityId = GetOrCreateCity(DBConnection.conn, ti.ToTitleCase(CheckUpper(addCustomer.cityText.Text.Trim())), countryId);
                    int addressId = GetOrCreateAddress(DBConnection.conn, ti.ToTitleCase(CheckUpper(addCustomer.addressText.Text.Trim())), addCustomer.phoneText.Text.Trim(), cityId);
                    int newCustomerId = GetNextCustomerId(DBConnection.conn);

                    if (!IsDuplicateCustomer(DBConnection.conn, addCustomer.customerNameText.Text.Trim(), addressId))
                    {
                        string query = "INSERT INTO customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                        "VALUES (@customerId, @name, @addressId, @active, @created, @createdBy, @update, @updateBy); SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                        cmd.Parameters.AddWithValue("@customerId", newCustomerId);
                        cmd.Parameters.AddWithValue("@name", ti.ToTitleCase(CheckUpper(addCustomer.customerNameText.Text.Trim())));
                        cmd.Parameters.AddWithValue("@addressId", addressId);
                        cmd.Parameters.AddWithValue("@active", true);
                        cmd.Parameters.AddWithValue("@created", "2000-01-01");
                        cmd.Parameters.AddWithValue("@createdBy", "");
                        cmd.Parameters.AddWithValue("@update", "2000-01-01");
                        cmd.Parameters.AddWithValue("@updateBy", "");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer added successfully.");
                        addCustomer.Close();
                    }
                    else
                    {
                        MessageBox.Show("A customer with the same address and phone number already exists.");
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ModifyCustomer(ModifyCustomer modifyCustomer, int customerId)
        {
            try
            {
                if (ValidateCustomer(modifyCustomer.customerNameText.Text.Trim(), modifyCustomer.addressText.Text.Trim(), modifyCustomer.phoneText.Text.Trim()))
                {
                    int countryId = GetOrCreateCountry(DBConnection.conn, ti.ToTitleCase(CheckUpper(modifyCustomer.countryComboBox.Text.Trim())));
                    int cityId = GetOrCreateCity(DBConnection.conn, ti.ToTitleCase(CheckUpper(modifyCustomer.cityText.Text.Trim())), countryId);
                    int addressId = GetOrCreateAddress(DBConnection.conn, ti.ToTitleCase(CheckUpper(modifyCustomer.addressText.Text.Trim())), modifyCustomer.phoneText.Text.Trim(), cityId);

                    string query = "UPDATE customer SET customerName = @name, addressId = @addressId WHERE customerId = @customerId";
                    MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@name", ti.ToTitleCase(CheckUpper(modifyCustomer.customerNameText.Text.Trim())));
                    cmd.Parameters.AddWithValue("@addressId", addressId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    MessageBox.Show(rowsAffected > 0 ? "Customer updated successfully." : "Customer not found.");
                    modifyCustomer.Close();
                }
                else
                {
                    MessageBox.Show("Invalid customer ID.");
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteCustomer(int customerId)
        {
            try
            {
                if (customerId == -1)
                {
                    MessageBox.Show("Customer not found.");
                    return;
                }
                var confirmResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM customer WHERE customerId = @id;";
                    MySqlCommand cmd = new(deleteQuery, DBConnection.conn);
                    cmd.Parameters.AddWithValue("@id", customerId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    MessageBox.Show(rowsAffected > 0 ? "Customer deleted successfully." : "Customer not found.");
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static int GetOrCreateCountry(MySqlConnection connection, string country)
        {
            string query = "SELECT countryId FROM country WHERE country = @country";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@country", country);
            object result = cmd.ExecuteScalar();
            if (result != null) return Convert.ToInt32(result);

            int newCountryId = GetNextCountryId(DBConnection.conn);
            query = "INSERT INTO country (countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES (@countryId, @country, @created, @createdBy, @update, @updateBy); SELECT LAST_INSERT_ID();";
            cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@countryId", newCountryId);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@created", "2000-01-01");
            cmd.Parameters.AddWithValue("@createdBy", "");
            cmd.Parameters.AddWithValue("@update", "2000-01-01");
            cmd.Parameters.AddWithValue("@updateBy", "");
            cmd.ExecuteNonQuery();
            return newCountryId;
        }

        private static int GetOrCreateCity(MySqlConnection connection, string city, int countryId)
        {
            string query = "SELECT cityId FROM city WHERE city = @city AND countryId = @countryId";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@countryId", countryId);
            object result = cmd.ExecuteScalar();
            if (result != null) return Convert.ToInt32(result);

            int newCityId = GetNextCityId(DBConnection.conn);
            query = "INSERT INTO city (cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES (@cityId, @city, @countryId, @created, @createdBy, @update, @updateBy); SELECT LAST_INSERT_ID();";
            cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@cityId", newCityId);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@countryId", countryId);
            cmd.Parameters.AddWithValue("@created", "2000-01-01");
            cmd.Parameters.AddWithValue("@createdBy", "");
            cmd.Parameters.AddWithValue("@update", "2000-01-01");
            cmd.Parameters.AddWithValue("@updateBy", "");
            cmd.ExecuteNonQuery();
            return newCityId;
        }

        private static int GetOrCreateAddress(MySqlConnection connection, string address, string phone, int cityId)
        {
            string query = "SELECT addressId FROM address WHERE address = @address AND phone = @phone AND cityId = @cityId";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", FormatPhone(phone));
            cmd.Parameters.AddWithValue("@cityId", cityId);
            object result = cmd.ExecuteScalar();
            if (result != null) return Convert.ToInt32(result);

            int newAddressId = GetNextAddressId(DBConnection.conn);
            query = "INSERT INTO address (addressId, address, address2, postalCode, phone, cityId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES (@addressId, @address, @address2, @postalCode, @phone, @cityId, @created, @createdBy, @update, @updateBy); SELECT LAST_INSERT_ID();";
            cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@addressId", newAddressId);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@address2", "");
            cmd.Parameters.AddWithValue("@postalCode", "");
            cmd.Parameters.AddWithValue("@phone", FormatPhone(phone));
            cmd.Parameters.AddWithValue("@cityId", cityId);
            cmd.Parameters.AddWithValue("@created", "2000-01-01");
            cmd.Parameters.AddWithValue("@createdBy", "");
            cmd.Parameters.AddWithValue("@update", "2000-01-01");
            cmd.Parameters.AddWithValue("@updateBy", "");
            cmd.ExecuteNonQuery();
            return newAddressId;
        }

        private static int GetNextCountryId(MySqlConnection connection)
        {
            string query = "SELECT MAX(countryId) FROM country";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            object result = cmd.ExecuteScalar();
            return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
        }

        private static int GetNextCityId(MySqlConnection connection)
        {
            string query = "SELECT MAX(cityId) FROM city";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            object result = cmd.ExecuteScalar();
            return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
        }

        private static int GetNextAddressId(MySqlConnection connection)
        {
            string query = "SELECT MAX(addressId) FROM address";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            object result = cmd.ExecuteScalar();
            return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
        }

        private static int GetNextCustomerId(MySqlConnection connection)
        {
            string query = "SELECT MAX(customerId) FROM customer";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            object result = cmd.ExecuteScalar();
            return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
        }

        private static string FormatPhone(string phone)
        {
            if (!phone.Contains('-'))
            {
                phone = Convert.ToInt64(phone.Trim()).ToString("###-####");
            }
            return phone;
        }

        private static bool IsDuplicateCustomer(MySqlConnection connection, string customerName, int addressId)
        {
            string query = "SELECT COUNT(*) FROM customer WHERE customerName = @customerName AND addressId = @addressId";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@customerName", customerName);
            cmd.Parameters.AddWithValue("@addressId", addressId);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        private static bool ValidateCustomer(string customerName, string address, string phone)
        {
            if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("All fields must be filled.");
                return false;
            }
            if (!Regex.IsMatch(phone, "^[0-9-]+$"))
            {
                MessageBox.Show("Phone number must contain only digits and dashes.");
                return false;
            }
            return true;
        }

        public static string CheckUpper(string str)
        {
            if (str.Equals("US"))
            {
                return str;
            }
            if (str.Equals(str.ToUpper()))
            {
                return str.ToLower();
            }
            return str;
        }
    }
}