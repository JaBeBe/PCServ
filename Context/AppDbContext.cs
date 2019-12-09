using Microsoft.EntityFrameworkCore;
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

        public AppDbContext( DbContextOptions options): base(options)
        {

        }
    }
}
