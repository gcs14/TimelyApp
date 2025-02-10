using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    internal static class AddressService
    {
        public static BindingList<Address> addresses = [];
        //public static Dictionary<int, Address> addressDict = new Dictionary<int, Address>();
        private static int highestID = -1;

        private static void ReadAddressData()
        {
            string sql = "SELECT * FROM Address";
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Address address = new
                    (
                        rdr.GetInt32("addressId"),
                        rdr.GetString("address"),
                        rdr.GetString("address2"),
                        rdr.GetInt32("cityId"),
                        rdr.GetString("postalCode"),
                        rdr.GetString("phone")
                    );

                addresses.Add(address);
                if (address.AddressId > highestID)
                {
                    highestID = address.AddressId;
                }
            }
            rdr.Close();
        }

        public static void ViewAddresses()
        {
            ReadAddressData();
        }

        public static bool AddressIdExisits(int id)
        {
            foreach (Address address in addresses)
            {
                if (address.AddressId == id)
                {
                    return true;
                }
            }
            GetNewAddressID();
            return false;
        }
        
        public static bool DuplicateAddress(Address address)
        {
            if (addresses.Contains(address))
            {
                return true;
            }
            foreach (Address a in addresses)
            {
                if (a.StreetAddress.Equals(address.StreetAddress)
                    && a.Address2.Equals(address.Address2)
                    && a.Phone.Equals(address.Phone))
                {
                    return true;
                }
            }
            return false;
        }

        public static Address FindByStreetName(string streetName, string address2)
        {
            foreach (Address address in addresses)
            {
                if (address.StreetAddress.Equals(streetName) && address.Address2.Equals(address2))
                {
                    return address;
                }
            }
            return null;
        }

        public static int GetNewAddressID()
        {
            return ++highestID;
        }

        public static void AddAddress(Address address)
        {
            for (int i = 0; i < addresses.Count; i++)
            {
                if (addresses[i].AddressId != address.AddressId)
                {
                    if (!(addresses[i].StreetAddress ==  address.StreetAddress
                        && addresses[i].PostalCode == address.PostalCode
                        && addresses[i].CityName == address.CityName
                        && addresses[i].CountryName == address.CountryName))
                    {
                        addresses.Add(address);
                    }
                }
            }
        }
    }
}
