using DesktopSchedulingApp.Exceptions;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class AddCustomer : Form
    {
        CustomerExceptions customerExceptions = new();
        public AddCustomer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddCustomers_Load(object sender, EventArgs e)
        {
            countryComboBox.DataSource = ResourceInfo.Countries;
            countryComboBox.Text = "";
        }

        private void AddCustomerSubmitBtn_Click(object sender, EventArgs e)
        {
            if (customerExceptions.AddCustomerExceptions(this))
            {
                #region -- creating new objects for Country, City, Address, and Customer tables --
                Country country = new(
                    CountryService.GetCountryID(countryComboBox.Text.Trim()),
                    countryComboBox.Text.Trim()
                    );

                City city = new(
                    CityService.GetCityID(cityText.Text.Trim(), country.CountryId),
                    cityText.Text.Trim(),
                    country.CountryId
                    );

                string phone = AddressService.FormatPhone(phoneText.Text);
                Address address = new(
                    AddressService.GetAddressID(addressText.Text.Trim(), city.CityId, phone),
                    addressText.Text.Trim(),
                    phone,
                    city.CityId
                    );

                Customer customer = new(
                    CustomerService.GetCustomerID(customerNameText.Text.Trim(), address.AddressId),
                    customerNameText.Text.Trim(),
                    address.AddressId
                    );
                #endregion

                #region -- calling database commands to insert data in specified tables --
                DBCommands.InsertCountryData(country);
                DBCommands.InsertCityData(city);
                DBCommands.InsertAddressData(address);
                try
                {
                    DBCommands.InsertCustomerData(customer);
                    this.Close();
                }
                catch (Exception ex)
                {
                    //CustomerService.DecrementHighestId();
                    //AddressService.DecrementHighestId();
                    MessageBox.Show("ERROR: This customer already exists.");
                }
                #endregion
            }
        }
    }
}
