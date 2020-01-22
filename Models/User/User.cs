using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCServ.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
        public DateTime CreateTime { get; set; }

        [NotMapped]
        public string Token { get; set; }

        private User()
        {

        }

        public User(string firstName, string lastName, string  login, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Role = UserRoleEnum.Client;
            CreateTime = DateTime.Now;
        }
    }
}