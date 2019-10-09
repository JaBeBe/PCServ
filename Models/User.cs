using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace PCServ.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login  { get; set; }
        public string Password  { get; set; }
        public string Email  { get; set; }
        public string Role { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        private User() { }

        public User(string firstName, string lastName, string login, string passw, string mail, string role)
        {
            // zaimplemetować autoinkrementowany ID z bazy danych 
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Login = login;
            this.Password = passw;
            this.Email = mail;
            this.Role = role;
            this.CreationDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
        }

    }
}