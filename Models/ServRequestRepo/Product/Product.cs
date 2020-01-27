using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.ServRequestRepo
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SerialNo { get; set; }

        private Product()
        {

        }
        public Product(string name, string description, string serialNo)
        {
            Name = name;
            Description = description;
            SerialNo = serialNo;
        }

    }
}
