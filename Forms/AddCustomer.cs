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
        //string currentUserName;
        public AddCustomer(string n)
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
                CountryService.AddCountry(country);

                City city = new(
                    CityService.GetCityID(cityText.Text.Trim()),
                    cityText.Text.Trim(),
                    country.CountryId
                    );
                CityService.AddCity(city);

                string phone = AddressService.FormatPhone(phoneText.Text);
                Address address = new(
                    AddressService.GetAddressID(addressText.Text.Trim(), city.CityId, phone),
                    addressText.Text.Trim(),
                    phone,
                    city.CityId
                    );
                AddressService.AddAddress(address);

                Customer customer = new(
                    CustomerService.GetCustomerID(customerNameText.Text.Trim()),
                    customerNameText.Text.Trim(),
                    address.AddressId
                    );
                CustomerService.AddCustomer(customer);
                #endregion

                #region -- calling database commands to insert data in specified tables --
                DBCommands.InsertCountryData(country);
                DBCommands.InsertCityData(city);
                DBCommands.InsertAddressData(address);
                DBCommands.InsertCustomerData(customer);
                this.Close();
                #endregion
            }
        }
    }
}
