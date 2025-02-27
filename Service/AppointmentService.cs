using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DesktopSchedulingApp.Service
{
    internal class AppointmentService
    {
        public static List<Appointment> Appointments;
        private static int highestID = 0;

        internal static void ReadAppointmentData(string sql)
        {
            Appointments = [];
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Appointment appointment = new
                    (
                        rdr.GetInt32("Id"),
                        rdr.GetInt32("userId"),
                        rdr.GetInt32("customerId"),
                        rdr.GetString("Type"),
                        rdr.GetDateTime("Start Date"),
                        rdr.GetDateTime("End Date")
                    );
                Appointments.Add(appointment);
                if (appointment.AppointmentId > highestID)
                {
                    highestID = appointment.AppointmentId;
                }
            }
            rdr.Close();
        }

        //public static bool AppointmentOverlap()
        //{
            
        //}
    }
}
