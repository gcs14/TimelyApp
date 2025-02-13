using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class ViewCustomers : Form
    {
        Customer selectedCustomer;
        string username;

        public ViewCustomers(string currentUserName)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            AddressService.ViewAddresses();
            CityService.ViewCities();
            CountryService.ViewCountries();
            PopulateCustomerTable();
            username = currentUserName;
        }

        private void PopulateCustomerTable()
        {
            CustomerService.LoadCustomerData(this);
            dataGridView1.CurrentCell = null;
        }

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            new AddCustomers(username).ShowDialog();
            PopulateCustomerTable();
        }

        private void ModifyCustomerBtn_Click(object sender, EventArgs e)
        {
            new ModifyCustomer(username, selectedCustomer).ShowDialog();
            PopulateCustomerTable();
        }

        private void DeleteCustomerBtn_Click(object sender, EventArgs e)
        {
            //CustomerService.DeleteCustomer(selectedCustomer);

            string deleteQuery = "DELETE FROM your_table WHERE id = @id";

            MySqlConnection conn = new MySqlConnection(deleteQuery);
            MySqlCommand cmd = new MySqlCommand(deleteQuery, DBConnection.conn);
            cmd.Parameters.AddWithValue("@id", 1);
            cmd.ExecuteNonQuery();
        }

        //private void CustomerSelection (object sender, EventArgs e)
        //{
        //    selectedCustomer = (Customer)dataGridView1.CurrentRow.DataBoundItem;
        //}
    }
}
