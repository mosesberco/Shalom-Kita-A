using System;

namespace final_project
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ID { get; private set; }
        public string Email { get; set; }
        public string Gender { get; private set; }
        public int Balance { get; set; }

        // Add a constructor that allows setting all properties
        public User(string username, string password, string id, string email, string gender, int balance)
        {
            Username = username;
            Password = password;
            ID = id;
            Email = email;
            Gender = gender;
            Balance = balance;
        }

        public void UpdateUsername(Database database, string newUsername)
        {
            database.SetUsername(int.Parse(ID), newUsername);
            Username = newUsername;
        }

        public void UpdatePassword(Database database, string newPassword)
        {
            database.SetPassword(int.Parse(ID), newPassword);
            Password = newPassword;
        }

        public void UpdateBalance(Database database, int newBalance)
        {
            database.SetBalance(int.Parse(ID), newBalance);
            Balance = newBalance;
        }
    }
}