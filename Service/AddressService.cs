using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web;

namespace DesktopSchedulingApp.Service
{
    internal static class AddressService
    {
        public static List<Address> Addresses;
        private static List<Address> DBAddresses;
        private static int highestID = 0;

        private static void ReadAddressData()
        {
            Addresses = [];
            DBAddresses = [];
            string sql = "SELECT * FROM Address";
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Address address = new
                    (
                        rdr.GetInt32("addressId"),
                        rdr.GetString("address"),
                        rdr.GetString("phone"),
                        rdr.GetInt32("cityId")
                    );
                DBAddresses.Add(address);
                Addresses.Add(address);
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

        public static bool AddressExistsById(int id)
        {
            foreach (Address address in DBAddresses)
            {
                if (address.AddressId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsDuplicate(Address address)
        {
            foreach (Address a in DBAddresses)
            {
                if (a.AddressId == address.AddressId
                    || (a.StreetAddress.Equals(address.StreetAddress)
                        && a.Phone.Equals(address.Phone)
                        && a.CityId == address.CityId))
                {
                    return true;
                }
            }
            return false;
        }

        public static Address FindByStreetName(string streetName)
        {
            foreach (Address address in Addresses)
            {
                if (address.StreetAddress.Equals(streetName))
                {
                    return address;
                }
            }
            return null;
        }

        public static Address FindByAddressId(int addressId)
        {
            foreach (Address address in Addresses)
            {
                if (address.AddressId == addressId)
                {
                    return address;
                }
            }
            return null;
        }

        public static int GetAddressID(string streetName)
        {
            if (FindByStreetName(streetName) != null)
            {
                return FindByStreetName(streetName).AddressId;
            }
            return highestID += 1;
        }


        public static int GetAddressID(string streetName, int cityId, string phone)
        {
            var x = FindByStreetName(streetName);
            if (x != null)
            {
                if (x.CityId == cityId && x.Phone == phone)
                {
                    return FindByStreetName(streetName).AddressId;
                }
            }
            return highestID += 1;
        }

        public static string FormatPhone(string phone)
        {
            if (!phone.Contains('-'))
            {
                phone = Convert.ToInt64(phone.Trim()).ToString("###-####");
            }
            return phone;
        }

        public static void AddAddress(Address address)
        {
            if (!IsDuplicate(address))
            {
                Addresses.Add(address);
            }
        }
    }
}
