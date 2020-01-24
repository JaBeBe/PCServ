using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.User
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string Login);
        Task<bool> Contains(User user);

        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
