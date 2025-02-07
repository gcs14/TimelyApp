using DesktopSchedulingApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopSchedulingApp.Models
{
    public class Address : City
    {
        public int AddressId {  get; set; }
        public string StreetAddress {  get; set; }
        public string Address2 { get; set; }
        public string PostalCode {  get; set; }
        public string Phone {  get; set; }

        public Address() { }

        public Address(int addressId, string address, string address2, int cityId, string postalCode, string phone)
        {
            this.AddressId = addressId;
            this.StreetAddress = address;
            this.Address2 = address2;
            this.CityId = cityId;
            this.PostalCode = postalCode;
            this.Phone = phone;
        }

        public Address(int addressId, string address, string postalCode, string phone, string city, string country)
        {
            this.AddressId = addressId;
            StreetAddress = address;
            PostalCode = postalCode;
            Phone = phone;
            CityName = city;
            CountryName = country;
        }

        public Address(string address, string postalCode, string phone, string city, string country)
        {
            AddressId = AddressService.GetNewAddressID();
            StreetAddress = address;
            PostalCode = postalCode;
            Phone = phone;
            CityName = city;
            CountryName = country;
        }
    }
}
