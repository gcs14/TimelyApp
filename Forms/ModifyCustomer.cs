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
    public partial class ModifyCustomer : Form
    {
        Customer currentCustomer;
        Customer newCustomer;
        string currentUserName;
        Address currentAddress;
        Address newAddress;
        public ModifyCustomer(string username, Customer customer)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentCustomer = customer;
            currentUserName = username;
            currentAddress = new Address(
                currentCustomer.AddressId,
                currentCustomer.StreetAddress,
                currentCustomer.Address2,
                currentCustomer.PostalCode,
                currentCustomer.Phone,
                currentCustomer.CityId,
                currentCustomer.CityName,
                currentCustomer.CountryName
                );
        }

        private void ModifyCustomer_Load(object sender, EventArgs e)
        {
            customerNameText.Text = currentCustomer.CustomerName;
            addressText.Text = currentCustomer.StreetAddress;
            address2Text.Text = currentCustomer.Address2;
            phoneText.Text = currentCustomer.Phone;
            cityText.Text = currentCustomer.CityName;
            postalText.Text = currentCustomer.PostalCode;
            activeCheckBtn.Checked = currentCustomer.Active;
            countryComboBox.DataSource = ResourceInfo.Countries;
            countryComboBox.Text = currentCustomer.CountryName;
        }
        private bool ChangeAddress()
        {
            if(!currentAddress.StreetAddress.Equals(addressText.Text) 
                || !currentAddress.Address2.Equals(address2Text.Text) 
                || !currentAddress.Phone.Equals(phoneText.Text))
            {
                newAddress = new Address(AddressService.GetNewAddressID(), addressText.Text, 
                    address2Text.Text, postalText.Text, phoneText.Text, CityService.GetCityID(cityText.Text), 
                    cityText.Text, countryComboBox.Text);
                return true;
            }
            return false;
        }

        private void ModifyCustomerSubmitBtn_Click(object sender, EventArgs e)
        {
            if (ChangeAddress())
            {
                newCustomer = new(
                    currentCustomer.CustomerId,
                    customerNameText.Text,
                    newAddress.AddressId,
                    newAddress.StreetAddress,
                    newAddress.Address2,
                    newAddress.PostalCode,
                    newAddress.Phone,
                    newAddress.CityId,
                    newAddress.CityName,
                    newAddress.CountryId,
                    newAddress.CountryName,
                    activeCheckBtn.Checked
                    );
                if (AddressService.DuplicateAddress(newAddress))
                {
                    newAddress.AddressId = newCustomer.AddressId = AddressService.FindByStreetName(
                        newAddress.StreetAddress, newAddress.Address2)
                        .AddressId;
                }
                
                CustomerService.ModifyCustomer(currentCustomer, newCustomer);
                CityService.AddCity(newAddress);
                AddressService.AddAddress(newAddress);
            }
            else if (!ChangeAddress())
            {
                newCustomer = new(
                    currentCustomer.CustomerId,
                    customerNameText.Text,
                    currentCustomer.AddressId,
                    currentCustomer.StreetAddress,
                    currentCustomer.Address2,
                    currentCustomer.PostalCode,
                    currentCustomer.Phone,
                    currentCustomer.CityId,
                    currentCustomer.CityName,
                    currentCustomer.CountryId,
                    currentCustomer.CountryName,
                    activeCheckBtn.Checked
                    );
                CustomerService.ModifyCustomer(currentCustomer, newCustomer);
            }
            this.Close();
        }
    }
}
