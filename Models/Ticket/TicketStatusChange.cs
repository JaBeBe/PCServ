using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.Ticket
{
    public class TicketStatusChange
    {
        public int Id { get; set; }
        public string Comment {get; set; }
        public User.User UserTechnician { get; set; }
        public DateTime UpdateTime { get; set; }
        public StatusEnum Status{ get; set; }
    }
}
