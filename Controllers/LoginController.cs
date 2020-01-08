using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PCServ.Models.Login;
using PCServ.Services;

namespace PCServ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]LoginForm loginForm)
        {
            var user = _userService.LoginUser(loginForm);

            if (user == null)
                return BadRequest(new { message = "Bad login credentials" });

            return Ok(user);
        }
    }
}
