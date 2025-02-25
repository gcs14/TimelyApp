using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DesktopSchedulingApp.Service
{
    internal static class CityService
    {
        public static List<City> Cities;
        private static int highestID = 0;

        private static void ReadCityData()
        {
            Cities = [];
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

        public static bool IsDuplicate(City city)
        {
            foreach (City c in Cities)
            {
                if (c.CityId == city.CityId
                    || (c.CityName.Equals(city.CityName)
                        && c.CountryId == city.CountryId))
                {
                    return true;
                }
            }
            return false;
        }

        public static City FindByCityName(string cityName, int countryId)
        {
            foreach (City city in Cities)
            {
                if (city.CityName.Equals(cityName)
                    && city.CountryId == countryId)
                {
                    return city;
                }
            }
            return null;
        }

        public static City FindByCityId(int cityId)
        {
            foreach (City city in Cities)
            {
                if (city.CityId == cityId)
                {
                    return city;
                }
            }
            return null;
        }

        public static int GetCityID(string cityName, int countryId)
        {
            var x = FindByCityName(cityName, countryId);
            if (x != null)
            {
                return FindByCityName(cityName, countryId).CityId;
            }
            return highestID += 1;
        }
    }
}
