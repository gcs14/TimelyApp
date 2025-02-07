using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    public static class CustomerService
    {
        public static BindingList<Customer> customers = [];
        private static int customerCount = 0;

        public static void LoadCustomers()
        {
            ReadCustomerData();
        }

        private static void ReadCustomerData()
        {
            string sql = "SELECT * FROM customer JOIN address ON address.addressId = customer.addressId JOIN city ON city.cityId = address.cityId JOIN country ON country.countryId = city.countryId";
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Customer c = new Customer
                    (
                        rdr.GetInt32("customerID"),
                        rdr.GetString("customerName"),
                        rdr.GetInt32("addressId"),
                        rdr.GetString("address"),
                        rdr.GetString("postalCode"),
                        rdr.GetString("phone"),
                        rdr.GetString("city"),
                        rdr.GetString("country"),
                        rdr.GetBoolean("active")
                    );

                customers.Add(c);
                customerCount++;
            }
            rdr.Close();
        }

        public static int GetNewCustomerID()
        {
            return ++customerCount;
        }
        
        public static void AddCustomer(Customer c)
        {
            //c.CustomerId = GetNewCustomerID();
            customers.Add(c);
        }

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
