using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopSchedulingApp.Service
{
    internal class AppointmentService
    {
        public static List<Appointment> Appointments;
        private static List<Appointment> DBAppointments;
        private static int highestID = 0;

        internal static void ReadAppointmentData(string sql)
        {
            Appointments = [];
            DBAppointments = [];
            //string sql = "SELECT * FROM Appointment";
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
                        rdr.GetDateTime("start"),
                        rdr.GetDateTime("end")
                    );
                DBAppointments.Add(appointment);
                Appointments.Add(appointment);
                if (appointment.AppointmentId > highestID)
                {
                    highestID = appointment.AppointmentId;
                }
            }
            rdr.Close();
        }

        //public static void ViewAppointments()
        //{
        //    ReadAppointmentData();
        //}
    }
}
