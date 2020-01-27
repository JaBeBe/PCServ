using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.ServRequestRepo
{
    public interface IServiceRequestRepository
    {
        Task<ServiceRequest> GetServiceRequestAsync(int id);
        Task<ServiceRequest> GetServiceRequestAsync(string title);
        Task<ServiceRequest> GetServiceRequestAsync(User.User client);
        Task<IEnumerable<ServiceRequest>> BrowseRequest(string name = "");
        Task<bool> Contains(ServiceRequest request);

        Task AddServiceRequestAsync(ServiceRequest request);
        Task UpdateServiceRequestAsync(ServiceRequest request);
        Task DeleteServiceRequestAsync(ServiceRequest request);
    }
}
