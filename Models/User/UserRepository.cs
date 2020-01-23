using PCServ.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _ctx;
        
        public UserRepository(AppDbContext context)
        {
            _ctx = context;
        }

        public IEnumerable<User> Users => _ctx.Users;
        public async Task<User> GetUserAsync(int id) => await Task.FromResult(_ctx.Users.SingleOrDefault(x => x.Id == id));
        public async Task<User> GetUserAsync(string Login) => await Task.FromResult(_ctx.Users.SingleOrDefault(x => x.Login == Login));

        public async Task AddUser(User user)
        {
            _ctx.Users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateUser(User user)
        {
            _ctx.Users.Update(user);
            await Task.CompletedTask;
        }

        public async Task DeleteUser(User user)
        {
           _ctx.Users.Remove(user);
            await Task.CompletedTask;
        }

    }
}
