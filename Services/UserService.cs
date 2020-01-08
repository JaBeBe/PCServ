using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PCServ.Context;
using PCServ.Helpers;
using PCServ.Models.Login;
using PCServ.Models.User;

namespace PCServ.Services
{
    public interface IUserService
    {
        Task<User> LoginUser(LoginForm loginForm);
    }

    public class UserService : IUserService
    {

        private AppDbContext _appDbContext;
        private AppSettingsHelper _appSettingsHelper;
        public UserService(AppDbContext appDbContext, IOptions<AppSettingsHelper> appSettingsHelper)
        {
            _appDbContext = appDbContext;
            _appSettingsHelper = appSettingsHelper.Value;
        }

        public async Task<User> LoginUser(LoginForm loginForm)
        {
            var user =  await _appDbContext.Users.Where(u => u.Login == loginForm.Login && u.Password == loginForm.Password).FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            user.Password = null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettingsHelper.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
    }
}
