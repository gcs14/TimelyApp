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
    internal static class CityService
    {
        public static List<City> Cities = [];
        private static int highestID = 0;
        private static int targetId = 0;

        private static void ReadCityData()
        {
            string sql = "SELECT * FROM city";
            MySqlCommand cmd = new(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                City city = new
                    (
                        rdr.GetInt32("cityId"),
                        rdr.GetString("city"),
                        rdr.GetInt32("countryId")
                    );

                Cities.Add(city);
                if (city.CityId > highestID)
                {
                    highestID = city.CityId;
                }
            }
            rdr.Close();
        }

        public static void ViewCities()
        {
            ReadCityData();
        }

        private static bool CityExists(string cityName)
        {
            for (int i = 0; i < Cities.Count; i++)
            {
                if (Cities[i].CityName.Equals(cityName))
                {
                    targetId = i;
                    return true;
                }
            }
            return false;
        }

        public static bool DuplicateCity(City city)
        {
            if (Cities.Contains(city))
            {
                return true;
            }
            foreach (City c in Cities)
            {
                if (c.CityId == city.CityId)
                {
                    return true;
                }
            }
            return false;
        }

        public static int GetCityID(string cityName, int countryId)
        {
            if (CityExists(cityName))
            {
                return targetId;
            }
            return GetNewCityID();
        }

        private static int GetNewCityID()
        {
            return highestID += 1;
        }

        public static void AddCity(City city)
        {
            if (CityExists(city.CityName))
            {
                MessageBox.Show("Error: This city already exists.");
            }
            Cities.Add(city);
        }
    }
}
