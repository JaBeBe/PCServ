using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PCServ.Helpers;
using PCServ.Models;
using PCServ.Models.Contexts;

namespace PCServ.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IConfiguration configuration;
        private AuthContext authContext;
        public AuthController(IConfiguration configuration, AuthContext authContext)
        {
            this.configuration = configuration;
            this.authContext = authContext;
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            if (loginModel == null)
            {
                return BadRequest("Invalid arguments");
            }

            User userDb = authContext.Users.Where(u => u.Login == loginModel.Login).FirstOrDefault<User>();

            if (userDb == null)
            {
                return Unauthorized("User not found");
            }
    
            if (!PasswordHelper.Check(userDb.Password, loginModel.Password, (this.configuration["PasswordHelper:Salt"]+userDb.Login)))
            {
                return Unauthorized("Invalid password");
            }

            List<Claim> claims = new List<Claim>() {
                new Claim("Id", userDb.Id.ToString()),
                new Claim("FirstName", userDb.FirstName),
                new Claim("LastName", userDb.LastName),
                new Claim("Email", userDb.Email),
                new Claim(ClaimTypes.Role, userDb.Role)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JWT:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: this.configuration["JWT:Issuer"],
                audience: this.configuration["JWT:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }
    }
}