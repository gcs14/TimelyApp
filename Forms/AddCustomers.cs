using DesktopSchedulingApp.Models;
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
        //string currentUserName;
        public AddCustomers(string n)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //currentUserName = n;
        }

        private void AddCustomerSubmitBtn_Click(object sender, EventArgs e)
        {
            // Validate input through exceptions handling
            

            // Take care of country info first
            Country country = new(
                CountryService.GetCountryID(countryComboBox.Text),
                countryComboBox.Text
                );
            CountryService.AddCountry(country);

            // Next city info
            City city = new(
                CityService.GetCityID(cityText.Text, country.CountryId),
                cityText.Text,
                country.CountryId
                );
            CityService.AddCity(city);

            // Next address info
            Address address = new(
                AddressService.GetAddressID(addressText.Text),
                addressText.Text,
                phoneText.Text,
                city.CityId
                );
            AddressService.AddAddress(address);

            // Finally customer info
            Customer customer = new(
                CustomerService.GetCustomerID(customerNameText.Text),
                customerNameText.Text,
                address.AddressId
                );
            CustomerService.AddCustomer(customer);

            CustomerService.InsertCountryData(country);
            CustomerService.InsertCityData(city);
            CustomerService.InsertAddressData(address);
            CustomerService.InsertCustomerData(customer);


            this.Close();
        }
    }
}
