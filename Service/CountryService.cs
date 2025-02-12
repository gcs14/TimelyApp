using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    internal static class CountryService
    {
        public static List<Country> Countries = [];
        private static int highestID = 0;
        private static int targetId = 0;

        private static void ReadCountryData()
        {
            string sql = "SELECT * FROM country";
            MySqlCommand cmd = new(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Country country = new
                    (
                        rdr.GetInt32("countryId"),
                        rdr.GetString("country")
                    );

                Countries.Add(country);
                if (country.CountryId > highestID)
                {
                    highestID = country.CountryId;
                }
            }
            rdr.Close();
        }

        public static void ViewCountries()
        {
            ReadCountryData();
        }

        private static bool CountryExists(string countryName)
        {
            for (int i = 0; i < Countries.Count; i++)
            {
                if (Countries[i].CountryName.Equals(countryName))
                {
                    targetId = i;
                    return true;
                }
            }
            return false;
        }

        public static Country FindByCountryName(string countryName)
        {
            foreach (Country country in Countries)
            {
                if (country.CountryName.Equals(countryName))
                {
                    return country;
                }
            }
            return null;
        }

        public static bool DuplicateCountry(Country country)
        {
            if (Countries.Contains(country))
            {
                return true;
            }
            foreach (Country c in Countries)
            {
                if (c.CountryId == country.CountryId)
                {
                    return true;
                }
            }
            return false;
        }

        public static int GetCountryID(string countryName)
        {
            if (FindByCountryName(countryName) != null)
            {
                return FindByCountryName(countryName).CountryId;
            }
            return GetNewCountryID();
        }

        private static int GetNewCountryID()
        {
            return highestID += 1;
        }

        public static void AddCountry(Country country)
        {
            if (CountryExists(country.CountryName))
            {
                MessageBox.Show("Error: This country already exists.");
            }
            Countries.Add(country);
        }
    }
}
