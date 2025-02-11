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
        public static BindingList<Address> Addresses = [];
        public static List<int> IdList = [];
        //public static Dictionary<int, Address> addressDict = new Dictionary<int, Address>();
        private static int highestID = 0;
        private static int targetId = 0;

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
                        rdr.GetString("phone"),
                        rdr.GetInt32("cityId")
                    );

                Addresses.Add(address);
                IdList.Add(address.AddressId);
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

        // Questionable if this is need or relevant
        public static bool AddressIdExisits(int id)
        {
            foreach (Address address in Addresses)
            {
                if (address.AddressId == id)
                {
                    return true;
                }
            }
            GetNewAddressID();
            return false;
        }

        private static bool AddressExists(Address address)
        {
            Boolean exists = false;
            for (int i = 0; i < Addresses.Count; i++)
            {
                if (Addresses[i].AddressId != address.AddressId)
                {
                    if (Addresses[i].StreetAddress == address.StreetAddress
                        && Addresses[i].Phone == address.Phone
                        && Addresses[i].CityId == address.CityId
                        && AddressIdExisits(address.AddressId))
                    {
                        exists = true;
                    }
                }
            }
            return exists;
        }
        
        public static bool DuplicateAddress(Address address)
        {
            //if (IdList.Contains(address.AddressId))
            //{
            //    return true;
            //}
            if (Addresses.Contains(address))
            {
                return true;
            }
            foreach (Address a in Addresses)
            {
                if (a.StreetAddress.Equals(address.StreetAddress)
                    && a.Phone.Equals(address.Phone))
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

        public static int GetAddressID(string streetName)
        {
            if (FindByStreetName(streetName) != null)
            {
                return FindByStreetName(streetName).AddressId;
            }
            return GetNewAddressID();
        }

        private static int GetNewAddressID()
        {
            return highestID += 1;
        }

        public static void AddAddress(Address address)
        {
            if (AddressExists(address))
            {
                MessageBox.Show("Error: This address already exists.");
            }
            Addresses.Add(address);
        }
    }
}
