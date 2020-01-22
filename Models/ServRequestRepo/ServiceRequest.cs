using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCServ.Models.ServRequestRepo;
using PCServ.Models.User;

namespace PCServ.Models.ServRequestRepo
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public Product Stuff { get; set; }
        public User.User Client { get; set; }
        public List<IEnumerable<RequestHistory>> History;

        private ServiceRequest()
        {

        }
        public ServiceRequest(string title, string description, Product product, User.User client)
        {
            Title = title;
            Description = description;
            Stuff = product;
            Client = client;
            CreateAt = DateTime.Now;
            History = new List<IEnumerable<RequestHistory>>();
            
        }
    }
}
