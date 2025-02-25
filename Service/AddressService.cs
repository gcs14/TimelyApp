using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopSchedulingApp.Service
{
    internal static class AddressService
    {
        public static List<Address> Addresses;
        private static int highestID = 0;

        private static void ReadAddressData()
        {
            Addresses = [];
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
            foreach (Address address in Addresses)
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
            foreach (Address a in Addresses)
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

        public static Address FindByStreetName(string streetName, int cityId, string phone)
        {
            foreach (Address address in Addresses)
            {
                if (address.StreetAddress.Equals(streetName)
                    && address.CityId == cityId
                    && address.Phone.Equals(phone))
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

        public static int GetAddressID(string streetName, int cityId, string phone)
        {
            var x = FindByStreetName(streetName, cityId, phone);
            if (x != null)
            {
                return FindByStreetName(streetName, cityId, phone).AddressId;
            }
            return highestID += 1;
        }

        public static void DecrementHighestId()
        {
            highestID--;
        }

        public static string FormatPhone(string phone)
        {
            if (!phone.Contains('-'))
            {
                phone = Convert.ToInt64(phone.Trim()).ToString("###-####");
            }
            return phone;
        }
    }
}
