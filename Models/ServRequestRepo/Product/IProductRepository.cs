﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.ServRequestRepo
{
    interface IProductRepository
    {
        Task<Product> GetProduct(int id);
        Task<Product> GetProduct(string serialNo);
        Task<IEnumerable<Product>> BrowseProduct(string name = "");


        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
