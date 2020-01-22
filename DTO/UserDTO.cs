using System;
using PCServ.Models.User;

namespace PCServ.DTO
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Role = user.Role;
            this.Token = user.Token;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRoleEnum Role { get; set; }
        public string Token { get; set; }
    }
}
