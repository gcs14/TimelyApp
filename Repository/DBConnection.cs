using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Repository
{
    public class DBConnection
    {
        public static MySqlConnection conn { get; set; }

        public static void StartConnection()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                conn = new MySqlConnection(constr);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
                conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
