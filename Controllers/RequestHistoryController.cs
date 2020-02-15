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
    public class RequestHistoryController : Controller
    {
        private readonly IRequestHistoryRepository _reqHisRepo;

        public RequestHistoryController(IRequestHistoryRepository repository)
        {
            _reqHisRepo = repository;
        }

        //GET RequestHistory/Get/id:int
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult> Get(int id) => Json(await _reqHisRepo.GetRequestHistoryAsync(id));

        //GET: RequestHistory/GetByClient/client
        [HttpGet]
        public async Task<ActionResult> GetByClient(User user) => Json(await _reqHisRepo.GetRequestHistoryAsync(user));

        //GET: RequestHistory/BrowseHistory/servRequest
        [HttpGet]
        public async Task<ActionResult> BrowseHistory(ServiceRequest request) => Json(await _reqHisRepo.Histories(request));

        //POST: RequestHistory/Create + json z request history
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult>Create(RequestHistory request)
        {
            if(! await _reqHisRepo.Contains(request))
            {
                await _reqHisRepo.AddRequestHistoryAsync(request);
            }
            return Ok();
        }

        //DELETE: RequestHistory/Delete/id:int
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var request = await _reqHisRepo.GetRequestHistoryAsync(id);
            if( await _reqHisRepo.Contains(request))
            {
                await _reqHisRepo.DeleteServiceRequestAsync(request);
            }
            return Ok();
        }

    }
}