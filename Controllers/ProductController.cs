using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCServ.Models.ServRequestRepo;

namespace PCServ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository product)
        {
            _productRepo = product;
        }

        
        // GET: Product/Get/id:int
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult> Get(int id) => await Task.FromResult(Json(_productRepo.GetProduct(id)));

        //GET: Product/Search/serialNo:string
        [HttpGet]
        [Route("[action]/{serialNo}")]
        public async Task<ActionResult> Search(string serialNo) => await Task.FromResult(Json(_productRepo.GetProduct(serialNo)));

        //GET: Product/Browse/name:string
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<ActionResult> Browse(string name) => await Task.FromResult(Json(_productRepo.BrowseProduct(name)));

        // POST: Product/Create + json z product
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create([FromBody]Product product)
        {
           if(!await _productRepo.Contains(product))
            {
                 await _productRepo.AddProduct(product);
            }
            return Ok();
        }

        // POST: Product/Edit + json z product
        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Edit([FromBody]Product product)
        {
            if(!await _productRepo.Contains(product))
            {
                await _productRepo.UpdateProduct(product);
            }
            return Ok();
        }

        // DELETE: Product/Delet/id:int
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productRepo.GetProduct(id);
            if(await _productRepo.Contains(product))
            {
                await _productRepo.DeleteProduct(product);
            }
            return Ok();
        }
        // DELETE: Product/Delete/serialNo:string
        [HttpDelete]
        [Route("[action]/{serialNo}")]
        public async Task<ActionResult> Delete(string serialNo)
        {
            var product = await _productRepo.GetProduct(serialNo);
            if (await _productRepo.Contains(product))
            {
                await _productRepo.DeleteProduct(product);
            }
            return Ok();
        }
    }
}