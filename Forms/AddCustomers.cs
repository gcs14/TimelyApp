using DesktopSchedulingApp.Exceptions;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class AddCustomers : Form
    {
        CustomerExceptions customerExceptions = new();
        //string currentUserName;
        public AddCustomers(string n)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //currentUserName = n;
        }

        private void AddCustomers_Load(object sender, EventArgs e)
        {
            countryComboBox.DataSource = ResourceInfo.Countries;
            countryComboBox.Text = "";
        }

        private void AddCustomerSubmitBtn_Click(object sender, EventArgs e)
        {
            // Validate input through exceptions handling
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

                Address address = new(
                    AddressService.GetAddressID(addressText.Text.Trim()),
                    addressText.Text.Trim(),
                    phoneText.Text,
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
