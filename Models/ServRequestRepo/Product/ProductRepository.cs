using PCServ.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.ServRequestRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _ctx;

        public ProductRepository(AppDbContext context)
        {
            _ctx = context;
        }
        public async Task<Product> GetProduct(int id) => await Task.FromResult(_ctx.Stuffs.SingleOrDefault(x => x.Id == id));

        public async Task<Product> GetProduct(string serialNo) => await Task.FromResult(_ctx.Stuffs.SingleOrDefault(x => x.SerialNo == serialNo));      

        public async Task<IEnumerable<Product>> BrowseProduct(string name = "")
        {
            var products = _ctx.Stuffs.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                products = products.Where(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant()).OrderBy(x => x.Id);
            }
            return await Task.FromResult(products);
        }

        public async Task AddProduct(Product product)
        {
            _ctx.Stuffs.Add(product);
            _ctx.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task UpdateProduct(Product product)
        {
            _ctx.Stuffs.Update(product);
            _ctx.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task DeleteProduct(Product product)
        {
            _ctx.Stuffs.Remove(product);
            _ctx.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task<bool> Contains(Product product) => await Task.FromResult(_ctx.Stuffs.Contains(product));
    }
}
