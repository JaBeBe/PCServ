using PCServ.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.ServRequestRepo
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly AppDbContext _ctx;

        public ServiceRequestRepository(AppDbContext context)
        {
            _ctx = context;
        }

        public async Task<ServiceRequest> GetServiceRequestAsync(int id) => await Task.FromResult(_ctx.ServReqs.SingleOrDefault(x => x.Id == id));

        public async Task<ServiceRequest> GetServiceRequestAsync(string title) => await Task.FromResult(_ctx.ServReqs.SingleOrDefault(x => x.Title.ToLowerInvariant() == title.ToLowerInvariant()));

        public async Task<ServiceRequest> GetServiceRequestAsync(User.User client) => await Task.FromResult(_ctx.ServReqs.SingleOrDefault(x => x.Client == client));

        public async Task<IEnumerable<ServiceRequest>> BrowseRequest(string title = "")
        {
            var servs = _ctx.ServReqs.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(title))
            {
                servs = servs.Where(x => x.Title.ToLowerInvariant().Contains(title.ToLowerInvariant())).ToList();
            }
            return await Task.FromResult(servs);
        }

        public async Task AddServiceRequestAsync(ServiceRequest request)
        {
            _ctx.ServReqs.Add(request);
            await Task.CompletedTask;
        }
      
        public async Task UpdateServiceRequestAsync(ServiceRequest request)
        {
            _ctx.ServReqs.Update(request);
            await Task.CompletedTask;
        }

        public async Task DeleteServiceRequestAsync(ServiceRequest request)
        {
            _ctx.ServReqs.Remove(request);
            await Task.CompletedTask;
        }

        public async Task<bool> Contains(ServiceRequest request) => await Task.FromResult(_ctx.ServReqs.Contains(request));

    }
}
