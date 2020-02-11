using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PCServ.DTO;
using PCServ.Helpers;
using PCServ.Models;
using PCServ.Models.Login;
using PCServ.Models.ResetPassword;
using PCServ.Models.User;
using PCServ.Services;

namespace PCServ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResetPasswordController : ControllerBase
    {
        private IUserService _userService;
        private IMailService _mailService;
        private IUserRepository _userRepository;
        public ResetPasswordController(IUserService userService, IMailService mailService, IUserRepository userRepository)
        {
            _userService = userService;
            _mailService = mailService;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RequestReset([FromBody]RequestResetForm requestResetForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Validation Failed" });
            }

            var token = await _userService.GeneratePasswordResetToken(requestResetForm);

            if (token == null)
                return BadRequest(new { message = "Unable to request password reset" });

            var user = await _userRepository.GetUserByEmailAsync(requestResetForm.EMail);

            var mail = new Mail()
            {
                ToMail = requestResetForm.EMail,
                ToName = user.FirstName + " " + user.LastName,
                Subject = "PCServ Password Reset",
                Body = "Click <here> to reset password"
            };

            var sentStatus = _mailService.Send(mail);

            if(sentStatus == false)
                return BadRequest(new { message = "Unable to send password reset link" });

            return Ok(new { message = "Reset link was send to email" });
        }

        // Use in guard
        [AllowAnonymous]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CheckIfCanReset([FromQuery(Name = "resetToken")] string resetToken, [FromQuery(Name = "userId")] int userId)
        {
            var canReset = await _userService.CheckIfCanResetPassword(userId, resetToken);

            if (canReset)
            {
                return Ok();
            }

            return BadRequest(new { message = "Unable to reset password" });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> NewPassword([FromQuery(Name = "resetToken")] string resetToken, [FromQuery(Name = "userId")] int userId, [FromBody] NewPasswordForm newPasswordForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Validation Failed" });
            }

            var user = await _userRepository.GetUserAsync(userId);

            if(user == null)
            {
                return BadRequest(new { message = "Invalid user" });
            }

            if(user.PasswordResetToken != resetToken)
            {
                return BadRequest(new { message = "Invalid reset token" });
            }

            user.Password = PasswordHelper.Hash(newPasswordForm.Password);
            user.PasswordResetToken = null;
            await _userRepository.UpdateUser(user);

            return Ok();
        }

    }
}
