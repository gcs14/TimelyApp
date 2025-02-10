using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class ViewCustomers : Form
    {
        Customer selectedCustomer;
        BindingList<Customer> customers = CustomerService.customers;
        string username;

        public ViewCustomers(string currentUserName)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            AddressService.ViewAddresses();
            CityService.ViewCities();
            PopulateCustomerTable();
            username = currentUserName;
        }

        private void PopulateCustomerTable()
        {
            //string sql = "SELECT customer.customerId, customer.customerName, customer.active, address.addressId, address.address, " +
            //    "address.address2, address.postalCode, address.phone, city.cityId, city.city, country.countryId, country.country " +
            //    "FROM customer " +
            //    "JOIN address ON address.addressId = customer.addressId " +
            //    "JOIN city ON city.cityId = address.cityId " +
            //    "JOIN country ON country.countryId = city.countryId";
            //MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //dataGridView1.DataSource = dt;

            CustomerService.LoadCustomers(this);

            //dataGridView1.DataSource = customers;
            dataGridView1.Columns["customerID"].HeaderText = "ID";
            dataGridView1.Columns["customerName"].HeaderText = "Name";
            dataGridView1.Columns["addressId"].HeaderText = "Address ID";
            //dataGridView1.Columns["streetAddress"].HeaderText = "Address";
            dataGridView1.Columns["address2"].HeaderText = "Address 2";
            dataGridView1.Columns["postalCode"].HeaderText = "Zip";
            //dataGridView1.Columns["cityName"].HeaderText = "City";
            //dataGridView1.Columns["countryName"].HeaderText = "Country";
            //dataGridView1.Columns["active"].Visible = false;
            //dataGridView1.Columns["addressId"].Visible = false;
            //dataGridView1.Columns["address2"].Visible = false;
            //dataGridView1.Columns["cityId"].Visible = false;
            //dataGridView1.Columns["countryId"].Visible = false;
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
            CustomerService.DeleteCustomer(selectedCustomer);
        }

        //private void CustomerSelection (object sender, EventArgs e)
        //{
        //    selectedCustomer = (Customer)dataGridView1.CurrentRow.DataBoundItem;
        //}
    }
}
