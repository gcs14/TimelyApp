using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DesktopSchedulingApp.Service
{
    internal static class CityService
    {
        public static List<City> Cities;
        private static List<City> DBCities;
        private static int highestID = 0;

        private static void ReadCityData()
        {
            Cities = [];
            DBCities = [];
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

                DBCities.Add(city);
                if (city.CityId > highestID)
                {
                    highestID = city.CityId;
                }
            }
            Cities = DBCities;
            rdr.Close();
        }

        public static void ViewCities()
        {
            ReadCityData();
        }

        public static bool CityExistsById(int cityId)
        {
            foreach (City city in DBCities)
            {
                if (city.CityId == cityId)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CityExistsByName(string cityName)
        {
            for (int i = 0; i < Cities.Count; i++)
            {
                if (Cities[i].CityName.Equals(cityName))
                {
                    return true;
                }
            }
            return false;
        }

        public static City FindByCityName(string cityName)
        {
            foreach (City city in Cities)
            {
                if (city.CityName.Equals(cityName))
                {
                    return city;
                }
            }
            return null;
        }

        public static int GetCityID(string cityName)
        {
            if (CityExistsByName(cityName))
            {
                return FindByCityName(cityName).CityId;
            }
            return NewCityID();
        }

        private static int NewCityID()
        {
            return highestID += 1;
        }

        public static void AddCity(City city)
        {
            if (!CityExistsByName(city.CityName))
            {
                Cities.Add(city);
            }
        }
    }
}
