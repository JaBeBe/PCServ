﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PCServ.DTO;
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
        public async Task<IActionResult> Authenticate([FromBody]LoginForm loginForm)
        {
            var user = await _userService.LoginUser(loginForm);

            if (user == null)
                return BadRequest(new { message = "Bad login credentials" });

            var userDTO = new UserDTO(user);

            return Ok(userDTO);
        }
    }
}
