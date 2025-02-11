using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    internal static class CustomerService
    {
        public static BindingList<Customer> customers = [];
        private static int customerCount = 0;

        public static void LoadCustomerData(ViewCustomers view)
        {
            string sql = "SELECT customer.customerId, customer.customerName, address.addressId, address.address, " +
                "address.phone, city.cityId, city.city, country.countryId, country.country " +
                "FROM customer " +
                "JOIN address ON address.addressId = customer.addressId " +
                "JOIN city ON city.cityId = address.cityId " +
                "JOIN country ON country.countryId = city.countryId";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            view.dataGridView1.DataSource = dt;
            ReadCustomerData(sql);
        }

        private static void ReadCustomerData(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                Customer c = new Customer
                    (
                        rdr.GetInt32("customerId"),
                        rdr.GetString("customerName"),
                        rdr.GetInt32("addressId"),
                        rdr.GetString("address"),
                        rdr.GetString("phone"),
                        rdr.GetInt32("cityId"),
                        rdr.GetString("city"),
                        rdr.GetInt32("countryId"),
                        rdr.GetString("country")
                    );
                customers.Add(c);
                customerCount++;
            }
            rdr.Close();
        }

        //private static void ReadCustomerData()
        //{
        //    string sql = "SELECT customer.customerId, customer.customerName, customer.active, address.addressId, address.address, " +
        //        "address.address2, address.postalCode, address.phone, city.cityId, city.city, country.countryId, country.country " +
        //        "FROM customer " +
        //        "JOIN address ON address.addressId = customer.addressId " +
        //        "JOIN city ON city.cityId = address.cityId " +
        //        "JOIN country ON country.countryId = city.countryId";

            //    //MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            //    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            //    DataTable dt = new DataTable();
            //    adapter.Fill(dt);
            //    dataGridView1.DataSource = dt;


            //    while (rdr.Read())
            //    {
            //        Customer c = new Customer
            //            (
            //                rdr.GetInt32("customerId"),
            //                rdr.GetString("customerName"),
            //                rdr.GetInt32("addressId"),
            //                rdr.GetString("address"),
            //                rdr.GetString("address2"),
            //                rdr.GetString("postalCode"),
            //                rdr.GetString("phone"),
            //                rdr.GetInt32("cityId"),
            //                rdr.GetString("city"),
            //                rdr.GetInt32("countryId"),
            //                rdr.GetString("country"),
            //                rdr.GetBoolean("active")
            //            );
            //        customers.Add(c);
            //        customerCount++;
            //    }
            //    rdr.Close();

            //    Customer cust = new Customer();
            //    string sql = "SELECT customer.customerId, customer.customerName, customer.active, address.addressId, address.address, " +
            //        "address.address2, address.postalCode, address.phone, city.cityId, city.city, country.countryId, country.country " +
            //        "FROM customer " +
            //        "JOIN address ON address.addressId = customer.addressId " +
            //        "JOIN city ON city.cityId = address.cityId " +
            //        "JOIN country ON country.countryId = city.countryId";
            //    MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            //    MySqlDataReader rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        Customer c = new Customer
            //            (
            //                rdr.GetInt32("customerId"),
            //                rdr.GetString("customerName"),
            //                rdr.GetInt32("addressId"),
            //                rdr.GetString("address"),
            //                rdr.GetString("address2"),
            //                rdr.GetString("postalCode"),
            //                rdr.GetString("phone"),
            //                rdr.GetInt32("cityId"),
            //                rdr.GetString("city"),
            //                rdr.GetInt32("countryId"),
            //                rdr.GetString("country"),
            //                rdr.GetBoolean("active")
            //            );
            //        customers.Add(c);
            //        customerCount++;
            //    }
            //    rdr.Close();
            //}

        public static int GetNewCustomerID()
        {
            return ++customerCount;
        }

        //public static void CreateCustomer(string name, int addressId, int active, DateTime time, string username)
        //{
        //    MySqlTransaction transaction = DBConnection.conn.BeginTransaction();

        //    string query = $"INSERT into customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy)" +
        //        $"VALUES ('{name}', '{addressId}', {active}, CURRENT_TIMESTAMP, '{username}', '{username}')";

        //    MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
        //    cmd.Transaction = transaction;
        //    cmd.ExecuteNonQuery();
        //    transaction.Commit();
        //    //conn.Close();
        //}

        //This is correct but create a Country first then a City then an Address before making a new Customer
        public static void AddCustomerData(Customer c)
        {
            string insertCustomerQuery = "INSERT INTO Customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@custId, @custName, @addressId, @active, @created, @createdBy, @update, @updateBy)";

            MySqlCommand cmd = new MySqlCommand(insertCustomerQuery, DBConnection.conn);
            cmd.Parameters.AddWithValue("@custId", c.CustomerId);
            cmd.Parameters.AddWithValue("@custName", c.CustomerName);
            cmd.Parameters.AddWithValue("@addressId", 3);
            cmd.Parameters.AddWithValue("@active", false);
            cmd.Parameters.AddWithValue("@created", "2000-01-01");
            cmd.Parameters.AddWithValue("@createdBy", "nobody");
            cmd.Parameters.AddWithValue("@update", "2000-01-01");
            cmd.Parameters.AddWithValue("@updateBy", "nobody");

            cmd.ExecuteNonQuery();
        }

        //public static void AddCustomer(Customer c)
        //{
        //    //customers.Add(c);
        //}

        public static void ModifyCustomer(Customer current, Customer modified)
        {
            if (current.CustomerId == modified.CustomerId)
            {
                customers[customers.IndexOf(current)] = modified;
            }
        }

        public static void DeleteCustomer(Customer c)
        {
            DialogResult confirm = MessageBox.Show("Are you sure want to delete this customer?", "WARNING", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (!customers.Contains(c))
                {
                    MessageBox.Show("This customer does not exisit.");
                }
                customers.Remove(c);
                MessageBox.Show($"Customer \"{c.CustomerName}\" has successfully been deleted.");
            }
        }
    }
}
