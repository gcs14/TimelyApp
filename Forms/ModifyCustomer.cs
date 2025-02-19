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
    public partial class ModifyCustomer : Form
    {
        private Customer currentCustomer;
        private Address currentAddress;
        private City currentCity;
        private Country currentCountry;

        private Customer newCustomer;
        private Address newAddress;
        private City newCity;
        private Country newCountry;
        string currentUserName;
        
        public ModifyCustomer(string username, Customer currentCustomer, Address currentAddress, City currentCity, Country currentCountry)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.currentCustomer = currentCustomer;
            this.currentAddress = currentAddress;
            this.currentCity = currentCity;
            this.currentCountry = currentCountry;

            currentUserName = username;
        }

        private void ModifyCustomer_Load(object sender, EventArgs e)
        {
            customerNameText.Text = currentCustomer.CustomerName;
            addressText.Text = currentAddress.StreetAddress;
            phoneText.Text = currentAddress.Phone;
            cityText.Text = currentCity.CityName;
            countryComboBox.DataSource = ResourceInfo.Countries;
            countryComboBox.Text = currentCountry.CountryName;
        }

        // check if county has changed. if so, create new country object and replace current
        private bool CountryChanged(Country newCountry)
        {
            if (newCountry.CountryId != currentCountry.CountryId
                || !newCountry.CountryName.Equals(currentCountry.CountryName))
            {
                return true;
            }
            return false;
        }

        // check if city has changed. if so, create new city object and replace current
        private bool CityChanged(City newCity)
        {
            if (newCity.CityId != currentCity.CityId
                || !newCity.CityName.Equals(currentCity.CityName)
                || newCity.CountryId != currentCity.CountryId)
            {
                return true;
            }
            return false;
        }

        // check if address has changed. if so, create new address object and replace current
        private bool AddressChanged(Address newAddress)
        {
            if (newAddress.AddressId != currentAddress.AddressId
                || !newAddress.StreetAddress.Equals(currentAddress.StreetAddress)
                || newAddress.Phone != currentAddress.Phone
                || newAddress.CityId != currentAddress.CityId)
            {
                return true;
            }
            return false;
        }

        // check if customer name has changed. if so, replace customerName with new name
        private bool CustomerChanged(Customer newCustomer)
        {
            if (newCustomer.CustomerId != currentCustomer.CustomerId
                || newCustomer.CustomerName.Equals(currentCustomer.CustomerName)
                || newCustomer.AddressId != currentCustomer.AddressId)
            {
                return true;
            }
            return false;
        }

        private void ModifyCustomerSubmitBtn_Click(object sender, EventArgs e)
        {
            newCountry = new(
                CountryService.GetCountryID(countryComboBox.Text),
                countryComboBox.Text
                );
            CountryService.AddCountry(newCountry);

            newCity = new(
                CityService.GetCityID(cityText.Text, newCountry.CountryId),
                cityText.Text,
                newCountry.CountryId
                );
            CityService.AddCity(newCity);

            newAddress = new(
                AddressService.GetAddressID(addressText.Text, newCity.CityId),
                addressText.Text,
                phoneText.Text,
                newCity.CityId
                );
            AddressService.AddAddress(newAddress);

            newCustomer = new(
                CustomerService.GetCustomerID(customerNameText.Text),
                customerNameText.Text,
                newAddress.AddressId
                );
            CustomerService.AddCustomer(newCustomer);

            if (CountryChanged(newCountry))
            {
                DBCommands.InsertCountryData(newCountry);
                DBCommands.InsertCityData(newCity);
                DBCommands.InsertAddressData(newAddress);
                DBCommands.UpdateCustomerData(newCustomer, newAddress, newCity, newCountry);
            }
            this.Close();
        }
    }
}
