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
        public static List<City> Cities = new List<City>();
        private static int highestID = 0;

        private static void ReadCityData()
        {
            string sql = "SELECT * FROM city";
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
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
                if (Cities[i].CityName == cityName)
                {
                    return true;
                }
            }
            return false;
        }

        public static int GetCityID(string cityName)
        {
            for (int i = 0; i < Cities.Count; i++)
            {
                if (Cities[i].CityName == cityName)
                {
                    return Cities[i].CityId;
                }
            }
            return GetNewCityID();
        }

        private static int GetNewCityID()
        {
            return ++highestID;
        }

        public static void AddCity(Address address)
        {
            if (!CityExists(address.CityName))
            {
                Cities.Add(new City(
                    GetNewCityID(),
                    address.CityName,
                    address.CountryId
                    ));
            }
        }
    }
}
