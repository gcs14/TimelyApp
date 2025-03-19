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
    internal class UserService
    {
        public static List<User> Users;
        private static int highestID = 0;

        public static void LoadUserData()
        {
            string sql = "SELECT user.userId, user.userName, user.password FROM user";
            //UserService.ReadUserData(sql);
        }

        //internal static void ReadUserData(string sql)
        //{
        //    Users = [];
        //    MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
        //    MySqlDataReader rdr = cmd.ExecuteReader();

        //    while (rdr.Read())
        //    {
        //        User user = new(
        //                rdr.GetInt32("userId"),
        //                rdr.GetString("userName"),
        //                rdr.GetString("password")
        //            );
        //        Users.Add(user);
        //        if (user.UserId > highestID)
        //        {
        //            highestID = user.UserId;
        //        }
        //    }
        //    rdr.Close();
        //}

        //public static User FindByUserName(string userName)
        //{
        //    foreach (User user in Users) 
        //    {
        //        if (user.Username == userName)
        //        {
        //            return user;
        //        }
        //    }
        //    return null;
        //}

        //public static int GetUserId(string userName)
        //{
        //    if (FindByUserName(userName) != null)
        //    {
        //        return FindByUserName(userName).UserId;
        //    }
        //    return highestID++;
        //}
    }
}
