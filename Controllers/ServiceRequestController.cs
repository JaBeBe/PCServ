using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCServ.Models.ServRequestRepo;
using PCServ.Models.User;

namespace PCServ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceRequestController : Controller
    {
        private readonly IServiceRequestRepository _servRepo;

        public ServiceRequestController(IServiceRequestRepository serviceRequest)
        {
            _servRepo = serviceRequest;
        }

        // GET: ServiceRequest/Get/int
        [HttpGet]
        public async Task<ActionResult> Get(int id) => Json(_servRepo.GetServiceRequestAsync(id));


        // GET: ServiceRequest/GetTitle/string
        [HttpGet]
        public async Task<ActionResult> GetTitle(string title) => Json(_servRepo.GetServiceRequestAsync(title));

        // GET: ServiceRequest/GetUser/user
        [HttpGet]
        public async Task<ActionResult> GetUser(User client) => Json(_servRepo.GetServiceRequestAsync(client));

        //GET: ServiceRequet/Browse/string
        public async Task<ActionResult> Browse(string name) => Json(_servRepo.BrowseRequest(name));


        // POST: ServiceRequest/Create/request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromBody]ServiceRequest request)
        {
            if(!await _servRepo.Contains(request))
            {
                await _servRepo.AddServiceRequestAsync(request);
            }
            return Ok();
        }

        //UPDATE: ServiceRequest/Update/request
        [HttpPatch]
        public async Task<ActionResult> Update([FromBody]ServiceRequest request)
        {
            if(! await _servRepo.Contains(request))
            {
                await _servRepo.UpdateServiceRequestAsync(request);
            }
            return Ok();
        }

        //DELETE: ServiceRequest/Delete/int
        public async Task<ActionResult> Delete(int id)
        {
            var request = await _servRepo.GetServiceRequestAsync(id);
            if(await _servRepo.Contains(request))
            {
                await _servRepo.DeleteServiceRequestAsync(request);
            }
            return Ok();
        }
        //DELETE: ServiceRequest/Delete/string
        public async Task<ActionResult> Delete(string title)
        {
            var request = await _servRepo.GetServiceRequestAsync(title);
            if (await _servRepo.Contains(request))
            {
                await _servRepo.DeleteServiceRequestAsync(request);
            }
            return Ok();
        }
    }
}