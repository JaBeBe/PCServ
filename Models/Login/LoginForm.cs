using System;
using System.ComponentModel.DataAnnotations;

namespace PCServ.Models.Login
{
    public class LoginForm
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
