using System;
using System.ComponentModel.DataAnnotations;
using PCServ.Helpers;
using PCServ.Validation;

namespace PCServ.Models.Register
{
    public class RegisterForm
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string EMail { get; set; }

        [Required]
        [UniqueLogin]
        [StringLength(50, MinimumLength = 3)]
        public string Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public User.User CreateUser()
        {
            //return new User.User(FirstName, LastName, Login, PasswordHelper.Hash(Password), EMail);
            return new User.User()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Login = this.Login,
                Password = PasswordHelper.Hash(this.Password),
                EMail = this.EMail
            };
        }
    }

}
