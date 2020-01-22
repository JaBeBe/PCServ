using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.ServRequestRepo
{
    interface IServiceRequestRepository
    {
        Task<ServiceRequest> GetServiceRequestAsync(int id);
        Task<ServiceRequest> GetServiceRequestAsync(string title);
        Task<ServiceRequest> GetServiceRequestAsync(User.User client);

        Task<ServiceRequest> AddServiceRequestAsync(ServiceRequest request);
        Task<ServiceRequest> UpdateServiceRequestAsync(ServiceRequest request);
        Task<ServiceRequest> DeleteServiceRequestAsync(ServiceRequest request);
    }
}
