using DesktopSchedulingApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopSchedulingApp.Models
{
    public class Customer : Address
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool Active { get; set; }

        public Customer(){ }

        // AddCustomer constructor
        public Customer(string customerName, string address, string postalCode, string phone, string city, string country, bool active)
        {
            CustomerId = CustomerService.GetNewCustomerID();
            CustomerName = customerName;
            AddressId = AddressService.GetNewAddressID();
            StreetAddress = address;
            PostalCode = postalCode;
            Phone = phone;
            CityName = city;
            CountryName = country;
            Active = active;
        }

        //customerID, name, active, address, postal code, phone, city, county
        public Customer(int customerId, string customerName, int addressId, string address, string address2, string postalCode, string phone, int cityId, string city, int countryId, string country, bool active)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            AddressId = addressId;
            StreetAddress = address;
            Address2 = address2;
            PostalCode = postalCode;
            Phone = phone;
            CityId = cityId;
            CityName = city;
            CountryId = countryId;
            CountryName = country;
            Active = active;
        }

        public Customer(string customerName, string address, string address2, string postalCode, string phone, string city, string country, bool active)
        {
            CustomerName = customerName;
            StreetAddress = address;
            Address2 = address2;
            PostalCode = postalCode;
            Phone = phone;
            CityName = city;
            CountryName = country;
            Active = active;
        }

        public Customer(int customerId, string customerName, string address, string address2, string postalCode, string phone, string city, string country)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            StreetAddress = address;
            Address2 = address2;
            PostalCode = postalCode;
            Phone = phone;
            CityName = city;
            CountryName = country;
        }
    }
}
