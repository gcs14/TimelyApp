using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;

namespace DesktopSchedulingApp.Repository
{
    internal class DBCommands
    {
        public static void InsertCustomerData(Customer customer)
        {
            if (CustomerService.CustomerExistsById(customer.CustomerId) == false)
            {
                string insertCustomerQuery = "INSERT INTO Customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@custId, @custName, @addressId, @active, @created, @createdBy, @update, @updateBy)";

                MySqlCommand cmd = new MySqlCommand(insertCustomerQuery, DBConnection.conn);
                cmd.Parameters.AddWithValue("@custId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@custName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@addressId", customer.AddressId);
                cmd.Parameters.AddWithValue("@active", false);
                cmd.Parameters.AddWithValue("@created", "2000-01-01");
                cmd.Parameters.AddWithValue("@createdBy", "");
                cmd.Parameters.AddWithValue("@update", "2000-01-01");
                cmd.Parameters.AddWithValue("@updateBy", "");
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertCountryData(Country country)
        {
            if (CountryService.CountryExistsByID(country.CountryId) == false)
            {
                string insertCountryQuery = "INSERT INTO Country (countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@countryId, @country, @created, @createdBy, @update, @updateBy)";

                MySqlCommand cmd = new MySqlCommand(insertCountryQuery, DBConnection.conn);
                cmd.Parameters.AddWithValue("@countryId", country.CountryId);
                cmd.Parameters.AddWithValue("@country", country.CountryName);
                cmd.Parameters.AddWithValue("@created", "2000-01-01");
                cmd.Parameters.AddWithValue("@createdBy", "");
                cmd.Parameters.AddWithValue("@update", "2000-01-01");
                cmd.Parameters.AddWithValue("@updateBy", "");
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertCityData(City city)
        {
            if (CityService.CityExistsById(city.CityId) == false)
            {
                string insertCityQuery = "INSERT INTO City (cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@cityId, @city, @countryId, @created, @createdBy, @update, @updateBy)";

                MySqlCommand cmd = new MySqlCommand(insertCityQuery, DBConnection.conn);
                cmd.Parameters.AddWithValue("@cityId", city.CityId);
                cmd.Parameters.AddWithValue("@city", city.CityName);
                cmd.Parameters.AddWithValue("@countryId", city.CountryId);
                cmd.Parameters.AddWithValue("@created", "2000-01-01");
                cmd.Parameters.AddWithValue("@createdBy", "");
                cmd.Parameters.AddWithValue("@update", "2000-01-01");
                cmd.Parameters.AddWithValue("@updateBy", "");
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertAddressData(Address address)
        {
            if (AddressService.AddressExistsById(address.AddressId) == false)
            {
                string insertAddressQuery = "INSERT INTO Address (addressId, address, address2, postalCode, phone, cityId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@addressId, @address, @address2, @postalCode, @phone, @cityId, @created, @createdBy, @update, @updateBy)";

                MySqlCommand cmd = new MySqlCommand(insertAddressQuery, DBConnection.conn);
                cmd.Parameters.AddWithValue("@addressId", address.AddressId);
                cmd.Parameters.AddWithValue("@address", address.StreetAddress);
                cmd.Parameters.AddWithValue("@address2", "");
                cmd.Parameters.AddWithValue("@postalCode", "");
                cmd.Parameters.AddWithValue("@phone", address.Phone);
                cmd.Parameters.AddWithValue("@cityId", address.CityId);
                cmd.Parameters.AddWithValue("@created", "2000-01-01");
                cmd.Parameters.AddWithValue("@createdBy", "");
                cmd.Parameters.AddWithValue("@update", "2000-01-01");
                cmd.Parameters.AddWithValue("@updateBy", "");
                cmd.ExecuteNonQuery();
            }
        }
    }
}
