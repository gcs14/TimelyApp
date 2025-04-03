using DesktopSchedulingApp.Exceptions;
using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class ModifyAppointment : Form
    {
        int appointmentId;
        int userId;
        string customerName;
        string type;
        DateTime start;
        DateTime end;
        TimeSpan duration;

        public ModifyAppointment(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            appointmentId = id;
            ReadAppointmentData(appointmentId);
        }

        private void ModifyAppointment_Load(object sender, EventArgs e)
        {
            monthCalendar.SelectionStart = start;
            AppointmentService.GetSelectedDate(monthCalendar.SelectionRange.Start.ToShortDateString());
            duration = end - start;
            durationComboBox.Text = duration.TotalMinutes.ToString() + " Mins";
            AppointmentService.SetAvailableHours(this, TimeOnly.FromDateTime(start), Convert.ToInt32(duration.TotalMinutes));
            typeComboBox.Text = type;
            TimeZoneLabel.Text = TimeZoneInfo.Local.StandardName;
            CustomerService.LoadCustomerData(this);
            foreach (DataGridViewRow row in custNamesDGV.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(customerName))
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void ReadAppointmentData(int appointmentId)
        {
            string query = "SELECT appointment.appointmentId AS 'Id', appointment.userId, user.userName AS 'User', " +
                "appointment.customerId, customer.customerName AS 'Customer', appointment.type AS 'Type', " +
                "appointment.start, appointment.end " +
                "FROM appointment " +
                "JOIN user ON user.userId = appointment.userId " +
                "JOIN customer ON customer.customerId = appointment.customerId " +
                "WHERE appointment.appointmentId = @appointmentId;";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    appointmentId = Convert.ToInt32(reader["Id"].ToString());
                    userId = Convert.ToInt32(reader["userId"].ToString());
                    customerName = reader["Customer"].ToString();
                    type = reader["Type"].ToString();
                    start = Convert.ToDateTime(reader["start"]);
                    end = Convert.ToDateTime(reader["end"]);
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (hoursDGV.Columns.Contains("Time"))
            {
                hoursDGV.Columns.Remove("Time");
            }
            AppointmentService.GetSelectedDate(monthCalendar.SelectionRange.Start.ToShortDateString());
            AppointmentService.SetAvailableHours(this, TimeOnly.FromDateTime(start), Convert.ToInt32(duration.TotalMinutes)); ;
        }

        private void NewCustomer_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
            CustomerService.LoadCustomerData(this);
        }

        private void ModifyAppointmentBtn_Click(object sender, EventArgs e)
        {
            AppointmentExceptions appointmentExceptions = new();
            if (appointmentExceptions.ModifyAppointmentExceptions(this))
            {
                AppointmentService.ModifyAppointment(this, appointmentId, userId);
            }
        }

        private void ModifyCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
