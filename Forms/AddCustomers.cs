﻿using DesktopSchedulingApp.Models;
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
            Customer newCustomer = new
                (
                CustomerService.GetNewCustomerID(),
                customerNameText.Text,
                AddressService.GetNewAddressID(),
                addressText.Text,
                address2Text.Text,
                postalText.Text,
                phoneText.Text,
                CityService.GetCityID(cityText.Text),
                cityText.Text,
                3,
                countryComboBox.Text,
                activeCheckBtn.Checked
                );
            CustomerService.AddCustomer(newCustomer);

            AddressService.AddAddress(new Address(
                newCustomer.AddressId,
                address2Text.Text,
                postalText.Text,
                phoneText.Text,
                cityText.Text,
                countryComboBox.Text
                )
            );

            this.Close();
        }
    }
}
