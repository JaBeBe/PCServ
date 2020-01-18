using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.ServRequestRepo
{
    public class RequestHistory
    {
        public int id { get; set; }
        public ServiceRequest Request { get; set; }
        public User.User ServiceMan { get; set; }
        public User.User Client { get; set; }
        public string Description { get; set; }
        public DateTime CtreateAt { get; set; }
    }
}
