using DesktopSchedulingApp.Exceptions;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class ModifyCustomer : Form
    {
        CustomerExceptions customerExceptions = new();
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

        private bool CountryChanged(Country newCountry)
        {
            if (newCountry.CountryId != currentCountry.CountryId
                || !newCountry.CountryName.Equals(currentCountry.CountryName))
            {
                return true;
            }
            return false;
        }

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

        private bool CustomerNameChanged(Customer newCustomer)
        {
            if (newCustomer.CustomerId == currentCustomer.CustomerId
                && newCustomer.AddressId == currentCustomer.AddressId
                && !newCustomer.CustomerName.Equals(currentCustomer.CustomerName))
            {
                return true;
            }
            return false;
        }

        private void ModifyCustomerSubmitBtn_Click(object sender, EventArgs e)
        {
            if (customerExceptions.ModifyCustomerExceptions(this, currentCountry, currentCity, currentAddress, currentCustomer))
            {
                //if ()
                newCountry = new(
                CountryService.GetCountryID(countryComboBox.Text),
                countryComboBox.Text.Trim()
                );
                CountryService.AddCountry(newCountry);

                newCity = new(
                    CityService.GetCityID(cityText.Text, newCountry.CountryId),
                    cityText.Text.Trim(),
                    newCountry.CountryId
                    );
                CityService.AddCity(newCity);

                string newPhone = AddressService.FormatPhone(phoneText.Text);
                newAddress = new(
                    AddressService.GetAddressID(addressText.Text, newCity.CityId, newPhone),
                    addressText.Text.Trim(),
                    newPhone,
                    newCity.CityId
                    );
                AddressService.AddAddress(newAddress);

                newCustomer = new(
                    currentCustomer.CustomerId,
                    customerNameText.Text.Trim(),
                    newAddress.AddressId
                    );
                CustomerService.AddCustomer(newCustomer);

                if (CountryChanged(newCountry) || CityChanged(newCity) || AddressChanged(newAddress) || CustomerNameChanged(newCustomer))
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
}
