﻿using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Service;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Exceptions
{
    internal class AppointmentExceptions
    {
        public bool AddAppointmentExceptions(AddAppointment addAppointment)
        {
            DateTime desiredStartTime = AppointmentService.MergeDateTime(
                addAppointment.monthCalendar.SelectionStart.ToShortDateString(),
                AppointmentService.GetSelectedTime(addAppointment.hoursDGV.CurrentRow.Cells[0].Value.ToString())
                );

            DateTime desiredEndTime = desiredStartTime.AddMinutes(Convert.ToDouble(
                addAppointment.durationComboBox.Text.Substring(0, 2)));

            DateTime closingTime = addAppointment.monthCalendar.SelectionStart.AddHours(17);

            if (desiredStartTime < DateTime.Now)
            {
                MessageBox.Show("ERROR: Cannot choose a date that has already passed.");
                return false;
            }
            if (desiredEndTime > closingTime)
            {
                MessageBox.Show("ERROR: Desired appointment exceeds business hours. Pick a shorter duration or choose another date.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(addAppointment.typeComboBox.Text))
            {
                MessageBox.Show("ERROR: Type can not be blank. Enter a valid appointment type.");
                addAppointment.typeComboBox.Text = "";
                return false;
            }
            return true;
        }

        public bool ModifyAppointmentExceptions(ModifyAppointment modifyAppointment)
        {
            DateTime desiredStartTime = AppointmentService.MergeDateTime(
                modifyAppointment.monthCalendar.SelectionStart.ToShortDateString(),
                AppointmentService.GetSelectedTime(modifyAppointment.hoursDGV.CurrentRow.Cells[0].Value.ToString())
                );

            DateTime desiredEndTime = desiredStartTime.AddMinutes(Convert.ToDouble(
                modifyAppointment.durationComboBox.Text.Substring(0, 2)));

            DateTime closingTime = modifyAppointment.monthCalendar.SelectionStart.AddHours(17);

            if (desiredStartTime < DateTime.Now)
            {
                MessageBox.Show("ERROR: Cannot choose a date that has already passed.");
                return false;
            }
            if (desiredEndTime > closingTime)
            {
                MessageBox.Show("ERROR: Desired appointment exceeds business hours. Pick a shorter duration or choose another date.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(modifyAppointment.typeComboBox.Text))
            {
                MessageBox.Show("ERROR: Type can not be blank. Enter a valid appointment type.");
                modifyAppointment.typeComboBox.Text = "";
                return false;
            }
            return true;
        }
    }
}
