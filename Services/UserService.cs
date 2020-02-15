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
using PCServ.Models.Register;
using PCServ.Models.ResetPassword;
using PCServ.Models.User;

namespace PCServ.Services
{
    public interface IUserService
    {
        Task<User> LoginUser(LoginForm loginForm);
        Task<int> RegisterUser(RegisterForm registerForm);
        Task<bool> CheckIfCanResetPassword(int userId, string resetToken);
        Task<string> GeneratePasswordResetToken(RequestResetForm requestResetForm);
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
            var user =  await _appDbContext.Users.Where(u => u.Login == loginForm.Login).FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            if(!PasswordHelper.Verify(loginForm.Password, user.Password))
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
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public async Task<int> RegisterUser(RegisterForm registerForm)
        {

            await _appDbContext.Users.AddAsync(registerForm.CreateUser());

            return await _appDbContext.SaveChangesAsync();

        }

        public async Task<bool> CheckIfCanResetPassword(int userId, string resetToken)
        {
            return await _appDbContext.Users.Where(u => u.Id == userId && u.PasswordResetToken == resetToken).AnyAsync();
        }

        public async Task<string> GeneratePasswordResetToken(RequestResetForm requestResetForm)
        {
            var token = TokenHelper.Generate(5, 100);

            var user = await _appDbContext.Users.Where(u => u.EMail == requestResetForm.EMail).FirstOrDefaultAsync();


            if(user == null)
            {
                return null;
            }

            user.PasswordResetToken = token;

            _appDbContext.Users.Update(user);

            await _appDbContext.SaveChangesAsync();

            return token;
        }
    }
}
