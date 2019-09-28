using System;
using System.Data.SqlClient;

namespace PCServ.Models
{
    public class User
    {
        int id;
        string name;
        string login;
        string password;
        string email;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }

        private User(){}

        public User(string name, string login, string passw, string mail){
            this.Name= name;
            this.Login=login;
            this.Password=passw;
            this.Email=mail;
        }

    }
}