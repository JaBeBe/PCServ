using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCServ.Authorization;
using PCServ.DTO;
using PCServ.Models.User;

namespace PCServ.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        // GET: User/id
        [HttpGet("{id}")]
        [AuthorizeRoles(UserRoleEnum.Administrator, UserRoleEnum.Technician)]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _userRepo.GetUserAsync(id);
            var userDTO = new UserDTO(user);
            return Json(userDTO);
        }

        // GET: User/login
        //[HttpGet]
        //public async Task<ActionResult> Get(string login)
        //{
        //    var user = await _userRepo.GetUserAsync(login);
        //    var userDTO = new UserDTO(user);
        //    return Json(userDTO);
        //}

        // POST: User/Create/user
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]User user)
        {
            if (! await _userRepo.Contains(user))
            {
                await _userRepo.AddUser(user);
            }
            return Ok();
        }
     
        // PATCH: User/Edit/user
        [HttpPatch]
        public async Task<ActionResult> Edit([FromBody]User user)
        {
            if (!await _userRepo.Contains(user))
            {
                await _userRepo.UpdateUser(user);
            }
            return Ok();
        }
       
        // DELETE: User/Delete/login
        [HttpDelete]
        public async Task<ActionResult> Delete(string login)
        {
            var user = await _userRepo.GetUserAsync(login);
            if (!await _userRepo.Contains(user))
            {
                await _userRepo.DeleteUser(user);
            }
            return Ok();
        }

        // DELETE: User/Delete/id
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userRepo.GetUserAsync(id);
            if (!await _userRepo.Contains(user))
            {
                await _userRepo.DeleteUser(user);
            }
            return Ok();
        }
    }
}