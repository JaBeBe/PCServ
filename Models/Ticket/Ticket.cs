using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.Ticket
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public StatusEnum Status { get; set; }
        public List<TicketStatusChange> Changes { get; set; }
    }
}
