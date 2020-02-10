using System;
namespace PCServ.Helpers
{
    public class MailConfigHelper
    {
        public string FromName { get; set; }
        public string FromMail { get; set; }
        public string SmtpAddr { get; set; }
        public int SmtpPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
