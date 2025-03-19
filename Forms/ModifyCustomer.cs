using DesktopSchedulingApp.Exceptions;
using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class ModifyCustomer : Form
    {
        public Dictionary<string, string> customerInfo = [];
        private int customerId;

        public ModifyCustomer(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.customerId = id;
        }

        private void ModifyCustomer_Load(object sender, EventArgs e)
        {
            ReadCustomerData(customerId);
        }

        private void ReadCustomerData(int customerId)
        {
            string query = @"SELECT c.customerId, c.customerName, a.addressId, a.address, ct.cityId, ct.city, co.countryId, co.country, a.phone 
                            FROM customer c 
                            JOIN address a ON c.addressId = a.addressId 
                            JOIN city ct ON a.cityId = ct.cityId 
                            JOIN country co ON ct.countryId = co.countryId 
                            WHERE c.customerId = @customerId";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    customerInfo.Add("customerName",customerNameText.Text = reader["customerName"].ToString());
                    customerInfo.Add("address", addressText.Text = reader["address"].ToString());
                    customerInfo.Add("phone", phoneText.Text = reader["phone"].ToString());
                    customerInfo.Add("city", cityText.Text = reader["city"].ToString());
                    countryComboBox.DataSource = ResourceInfo.Countries;
                    customerInfo.Add("country", countryComboBox.Text = reader["country"].ToString());
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
        }

        private void ModifyCustomerSubmitBtn_Click(object sender, EventArgs e)
        {
            CustomerExceptions customerExceptions = new();
            if (customerExceptions.ModifyCustomerExceptions(this))
            {
                CustomerService.ModifyCustomer(this, customerId);
            }
        }

        private void ModifyCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
