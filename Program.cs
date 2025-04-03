using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Repository;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBConnection.CloseConnection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBConnection.StartConnection();
            Application.Run(new Login());
            DBConnection.CloseConnection();
        }
    }
}
