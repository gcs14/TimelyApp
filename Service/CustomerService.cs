using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    internal static class CustomerService
    {
        public static List<Customer> Customers;
        private static int highestID = 0;

        internal static void ReadCustomerData(string sql)
        {
            Customers = [];
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Customer c = new(
                        rdr.GetInt32("customerId"),
                        rdr.GetString("customerName"),
                        rdr.GetInt32("addressId")
                    );
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
            foreach (Customer c in Customers)
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

        public static Customer FindByCustomerName(string customerName, int addressId)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.CustomerName.Equals(customerName)
                    && customer.AddressId == addressId)
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

        public static int GetCustomerID(string customerName, int addressId)
        {
            var x = FindByCustomerName(customerName, addressId);
            if (x != null)
            {
                return FindByCustomerName(customerName, addressId).CustomerId;
            }
            return highestID += 1;
        }

        public static void DecrementHighestId()
        {
            highestID--;
        }

        public static void DeleteCustomer(Customer c)
        {
            DialogResult confirm = MessageBox.Show("Are you sure want to delete this customer?", "WARNING", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (!Customers.Contains(c))
                {
                    MessageBox.Show("This customer does not exisit.");
                }
                else
                {
                    Customers.Remove(c);
                    DBCommands.DeleteCustomerData(c);
                    MessageBox.Show($"Customer \"{c.CustomerName}\" has successfully been deleted.");
                }
            }
        }
    }
}
