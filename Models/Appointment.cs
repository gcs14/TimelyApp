using System;

namespace DesktopSchedulingApp.Models
{
    internal class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Appointment(int appointmentId, int customerId, int userId, string type, DateTime startTime, DateTime endTime)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            UserId = userId;
            Type = type;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
