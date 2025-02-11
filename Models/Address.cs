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
        public string Phone {  get; set; }

        public Address() { }

        public Address(int addressId, string address, string phone, int cityId)
        {
            this.AddressId = addressId;
            this.StreetAddress = address;
            this.Phone = phone;
            this.CityId = cityId;
        }
    }
}
