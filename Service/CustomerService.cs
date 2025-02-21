using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    internal static class CustomerService
    {
        public static List<Customer> Customers;
        public static List<Customer> DBCustomers;
        private static int highestID = 0;

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
            ReadCustomerData(sql);
        }

        private static void ReadCustomerData(string sql)
        {
            Customers = [];
            DBCustomers = [];
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Customer c = new(
                        rdr.GetInt32("customerId"),
                        rdr.GetString("customerName"),
                        rdr.GetInt32("addressId")
                    );
                DBCustomers.Add(c);
                Customers.Add(c);
                if (c.CustomerId > highestID)
                {
                    highestID = c.CustomerId;
                }
            }
            rdr.Close();
        }

        public static bool IsDuplicate(Customer customer)
        {
            foreach (Customer c in DBCustomers)
            {
                if (c.CustomerId == customer.CustomerId)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CustomerExistsByName(string customerName)
        {
            foreach (Customer c in Customers)
            {
                if (c.CustomerName.Equals(customerName))
                {
                    return true;
                }
            }
            return false; 
        }

        public static Customer FindByCustomerName(string customerName)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.CustomerName.Equals(customerName))
                {
                    return customer;
                }
            }
            return null;
        }

        public static Customer FindByCustomerId(int customerId)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.CustomerId == customerId)
                {
                    return customer;
                }
            }
            return null;
        }

        public static int GetCustomerID(string customerName)
        {
            if (CustomerExistsByName(customerName))
            {
                return FindByCustomerName(customerName).CustomerId;
            }
            return highestID += 1;
        }

        public static void AddCustomer(Customer customer)
        {
            if (!CustomerExistsByName(customer.CustomerName))
            {
                Customers.Add(customer);
            }
        }

        //public static void ModifyCustomer(Customer current, Customer modified)
        //{
        //    if (current.CustomerId == modified.CustomerId)
        //    {
        //        Customers[Customers.IndexOf(current)] = modified;
        //    }
        //}

        public static void DeleteCustomer(Customer c)
        {
            DialogResult confirm = MessageBox.Show("Are you sure want to delete this customer?", "WARNING", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (!Customers.Contains(c))
                {
                    MessageBox.Show("This customer does not exisit.");
                }
                Customers.Remove(c);
                MessageBox.Show($"Customer \"{c.CustomerName}\" has successfully been deleted.");
            }
        }
    }
}
