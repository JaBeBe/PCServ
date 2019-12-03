using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext( DbContextOptions options): base(options)
        {

        }
    }
}
