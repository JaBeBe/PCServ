using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCServ.Context;
using PCServ.Models.User;

namespace PCServ.Services
{
    public class UserService
    {
        private AppDbContext _appDbContext;
        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> GetUser(string login)
        {
            return await _appDbContext.Users.Where(u => u.Login == login).FirstOrDefaultAsync();
        }
    }
}
