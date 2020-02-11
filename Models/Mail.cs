using System;
namespace PCServ.Models
{
    public class Mail
    {
        public string ToName { get; set; }
        public string ToMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
