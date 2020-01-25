using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using PCServ.Models.User;

namespace PCServ.Authorization
{
    public class AuthorizeRoles : AuthorizeAttribute
    {
        public AuthorizeRoles(params UserRoleEnum[] roles)
        {
            var rolesToString = roles.Select(r => r.ToString());
            base.Roles = String.Join(",", rolesToString);
        }
    }
}
