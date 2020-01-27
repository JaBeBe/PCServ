using Microsoft.EntityFrameworkCore;
using PCServ.Models.ServRequestRepo;
using PCServ.Models.Ticket;
using PCServ.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ServiceRequest> ServReqs { get; set; }
        public DbSet<RequestHistory> ReqHistory{ get; set; }
        public DbSet<Product> Stuffs { get; set; }

        public AppDbContext( DbContextOptions options): base(options)
        {

        }
    }
}
