using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models
{
    public class LoginModel
    {
        public string Login  { get; set; }
        public string Password  { get; set; }

        public LoginModel(string login, string passw)
        {
            this.Login = login;
            this.Password = passw;
        }
    }
}
