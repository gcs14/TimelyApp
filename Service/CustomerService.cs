using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    internal static class CustomerService
    {
        public static BindingList<Customer> Customers = [];
        private static int customerCount = 0;
        private static int targetId = 0;

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
                Customer c = new(
                        rdr.GetInt32("customerId"),
                        rdr.GetString("customerName"),
                        rdr.GetInt32("addressId")
                    );
                Customers.Add(c);
                customerCount++;
            }
            rdr.Close();
        }

        public static bool CustomerExists(string customerName)
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].CustomerName.Equals(customerName))
                {
                    targetId = i;
                    return true;
                }
            }
            return false; 
        }

        public static int GetCustomerID(string customerName)
        {
            if (CustomerExists(customerName))
            {
                return targetId;
            }
            return GetNewCustomerID();
        }

        public static int GetNewCustomerID()
        {
            return ++customerCount;
        }

        public static void AddCustomer(Customer customer)
        {
            if (CustomerExists(customer.CustomerName))
            {
                MessageBox.Show("Error: This country already exists.");
            }
            Customers.Add(customer);
        }


        //This is correct but create a Country first then a City then an Address before making a new Customer
        public static void InsertCustomerData(Customer customer)
        {
            string insertCustomerQuery = "INSERT INTO Customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@custId, @custName, @addressId, @active, @created, @createdBy, @update, @updateBy)";

            MySqlCommand cmd = new MySqlCommand(insertCustomerQuery, DBConnection.conn);
            cmd.Parameters.AddWithValue("@custId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@custName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@addressId", customer.AddressId);
            cmd.Parameters.AddWithValue("@active", false);
            cmd.Parameters.AddWithValue("@created", "2000-01-01");
            cmd.Parameters.AddWithValue("@createdBy", "nobody");
            cmd.Parameters.AddWithValue("@update", "2000-01-01");
            cmd.Parameters.AddWithValue("@updateBy", "nobody");

            cmd.ExecuteNonQuery();
        }

        public static void InsertCountryData(Country country)
        {
            if (!CountryService.DuplicateCountry(country))
            {
                string insertCountryQuery = "INSERT INTO Country (countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@countryId, @country, @created, @createdBy, @update, @updateBy)";

                MySqlCommand cmd = new MySqlCommand(insertCountryQuery, DBConnection.conn);
                cmd.Parameters.AddWithValue("@countryId", country.CountryId);
                cmd.Parameters.AddWithValue("@country", country.CountryName);
                cmd.Parameters.AddWithValue("@created", "2000-01-01");
                cmd.Parameters.AddWithValue("@createdBy", "nobody");
                cmd.Parameters.AddWithValue("@update", "2000-01-01");
                cmd.Parameters.AddWithValue("@updateBy", "nobody");
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertCityData(City city)
        {
            string insertCityQuery = "INSERT INTO City (cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@cityId, @city, @countryId, @created, @createdBy, @update, @updateBy)";

            MySqlCommand cmd = new MySqlCommand(insertCityQuery, DBConnection.conn);
            cmd.Parameters.AddWithValue("@cityId", city.CityId);
            cmd.Parameters.AddWithValue("@city", city.CityName);
            cmd.Parameters.AddWithValue("@countryId", city.CountryId);
            cmd.Parameters.AddWithValue("@created", "2000-01-01");
            cmd.Parameters.AddWithValue("@createdBy", "nobody");
            cmd.Parameters.AddWithValue("@update", "2000-01-01");
            cmd.Parameters.AddWithValue("@updateBy", "nobody");
            cmd.ExecuteNonQuery();
        }

        public static void InsertAddressData(Address address)
        {
            string insertAddressQuery = "INSERT INTO Address (addressId, address, address2, postalCode, phone, cityId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@addressId, @address, @address2, @postalCode, @phone, @cityId, @created, @createdBy, @update, @updateBy)";

            MySqlCommand cmd = new MySqlCommand(insertAddressQuery, DBConnection.conn);
            cmd.Parameters.AddWithValue("@addressId", address.AddressId);
            cmd.Parameters.AddWithValue("@address", address.StreetAddress);
            cmd.Parameters.AddWithValue("@address2", "blank");
            cmd.Parameters.AddWithValue("@postalCode", "blank");
            cmd.Parameters.AddWithValue("@phone", address.Phone);
            cmd.Parameters.AddWithValue("@cityId", address.CityId);
            cmd.Parameters.AddWithValue("@created", "2000-01-01");
            cmd.Parameters.AddWithValue("@createdBy", "nobody");
            cmd.Parameters.AddWithValue("@update", "2000-01-01");
            cmd.Parameters.AddWithValue("@updateBy", "nobody");
            cmd.ExecuteNonQuery();
        }

        
        public static void ModifyCustomer(Customer current, Customer modified)
        {
            if (current.CustomerId == modified.CustomerId)
            {
                Customers[Customers.IndexOf(current)] = modified;
            }
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
                Customers.Remove(c);
                MessageBox.Show($"Customer \"{c.CustomerName}\" has successfully been deleted.");
            }
        }
    }
}
