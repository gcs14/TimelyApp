using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Repository
{
    internal class DBCommands
    {
        public static void LoadCustomerData(ViewCustomers view)
        {
            string sql = "SELECT customer.customerId, customer.customerName, address.addressId, address.address, " +
                "address.phone, city.cityId, city.city, country.countryId, country.country " +
                "FROM customer " +
                "JOIN address ON address.addressId = customer.addressId " +
                "JOIN city ON city.cityId = address.cityId " +
                "JOIN country ON country.countryId = city.countryId " +
                "ORDER BY customer.customerId";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            view.dataGridView1.DataSource = dt;
            CustomerService.ReadCustomerData(sql);
        }

        public static void LoadCustomerData(AddAppointment view)
        {
            string sql = "SELECT customer.customerId, customer.customerName, customer.addressId FROM customer ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            view.custNamesDGV.DataSource = dt;
            view.custNamesDGV.Columns["customerId"].Visible = false;
            view.custNamesDGV.Columns["addressId"].Visible = false;
            view.custNamesDGV.Columns["customerName"].HeaderText = "Customer";

            CustomerService.ReadCustomerData(sql);
        }

        

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

        public static void LoadAppointmentData(ViewAppointments view)
        {
            string sql = "SELECT appointment.appointmentId AS 'Id', appointment.userId, user.userName AS 'User', " +
                "appointment.customerId, customer.customerName AS 'Customer', appointment.type AS 'Type', " +
                "appointment.start AS 'Start Date', appointment.end AS 'End Date', " +
                "TIME(appointment.start) AS 'Start Time', TIME(appointment.end) AS 'End Time' " +
                "FROM appointment " +
                "JOIN user ON user.userId = appointment.userId " +
                "JOIN customer ON customer.customerId = appointment.customerId " +
                "ORDER BY appointment.appointmentId;";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            view.dataGridView1.DataSource = dt;
            AppointmentService.ReadAppointmentData(sql);
        }

        public static void InsertAppointmentData(Appointment appointment)
        {
            string insertAppointmentQuery = "INSERT INTO Appointment (appointmentId, customerId, userId, title, " +
                "description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@appointmentId, @customerId, @userId, @title, @description, @location, @contact, @type, " +
                "@url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

            MySqlCommand cmd = new MySqlCommand(insertAppointmentQuery, DBConnection.conn);
            cmd.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);
            cmd.Parameters.AddWithValue("@customerId", appointment.CustomerId);
            cmd.Parameters.AddWithValue("@userId", appointment.UserId);
            cmd.Parameters.AddWithValue("@title", "");
            cmd.Parameters.AddWithValue("@description", "");
            cmd.Parameters.AddWithValue("@location", "");
            cmd.Parameters.AddWithValue("@contact", "");
            cmd.Parameters.AddWithValue("@type", appointment.Type);
            cmd.Parameters.AddWithValue("@url", "");
            cmd.Parameters.AddWithValue("@start", appointment.StartTime);
            cmd.Parameters.AddWithValue("@end", appointment.EndTime);
            cmd.Parameters.AddWithValue("@createDate", "2000-01-01");
            cmd.Parameters.AddWithValue("@createdBy", "");
            cmd.Parameters.AddWithValue("@lastUpdate", "2000-01-01");
            cmd.Parameters.AddWithValue("@lastUpdateBy", "");
            cmd.ExecuteNonQuery();
        }
    }
}
