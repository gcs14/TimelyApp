using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;

namespace DesktopSchedulingApp.Repository
{
    internal class DBCommands
    {
        public static void InsertCountryData(Country country)
        {
            if (country != null && !CountryService.IsDuplicate(country))
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
            if (city != null && !CityService.IsDuplicate(city))
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
            if (address != null && !AddressService.IsDuplicate(address))
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

        public static void InsertCustomerData(Customer customer)
        {
            if (customer != null && !CustomerService.IsDuplicate(customer))
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

        public static void UpdateCustomerData(Customer customer, Address address, City city, Country country)
        {
            string updateCountryQuery =
                "UPDATE customer SET customerName = @customerName, addressId = @addressId WHERE customerId = @customerId; " +
                "UPDATE address SET address = @address, phone = @phone " +
                "WHERE addressId = @addressId; " +
                "UPDATE city SET city = @city " +
                "WHERE cityId = @cityId; " +
                "UPDATE country SET country = @country " +
                "WHERE countryId = @countryId;";

            MySqlCommand cmd = new MySqlCommand(updateCountryQuery, DBConnection.conn);

            cmd.Parameters.AddWithValue("@customerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@customerName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@address", address.StreetAddress);
            cmd.Parameters.AddWithValue("@addressId", address.AddressId);
            cmd.Parameters.AddWithValue("@phone", address.Phone);
            cmd.Parameters.AddWithValue("@city", city.CityName);
            cmd.Parameters.AddWithValue("@cityId", city.CityId);
            cmd.Parameters.AddWithValue("@country", country.CountryName);
            cmd.Parameters.AddWithValue("@countryId", country.CountryId);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteCustomerData(Customer customer)
        {
            string deleteQuery = "DELETE FROM customer WHERE customerId = @id;";

            MySqlCommand cmd = new MySqlCommand(deleteQuery, DBConnection.conn);
            cmd.Parameters.AddWithValue("@id", customer.CustomerId);
            cmd.ExecuteNonQuery();
        }
    }
}
