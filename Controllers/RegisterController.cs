using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCServ.DTO;
using PCServ.Models.Register;
using PCServ.Services;

namespace PCServ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        public IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> NewAccount([FromBody]RegisterForm registerForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Validation Failed" });
            }

            var userCreated = await _userService.RegisterUser(registerForm);

            if(userCreated > 0)
            {
                return Ok();
            }

            return BadRequest(new { message = "Adding to database failed" });
        }
    }
}
