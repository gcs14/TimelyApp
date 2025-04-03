namespace DesktopSchedulingApp.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int userID, string username, string password)
        {
            UserId = userID;
            Username = username;
            Password = password;
        }
    }
}
