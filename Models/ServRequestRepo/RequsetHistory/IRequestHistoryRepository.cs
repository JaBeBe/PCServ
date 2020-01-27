using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.ServRequestRepo
{
    public interface IRequestHistoryRepository
    {
        Task<RequestHistory> GetRequestHistoryAsync(int id);
        Task<RequestHistory> GetRequestHistoryAsync(User.User client);
        Task<IEnumerable<RequestHistory>> Histories(ServiceRequest request);
        Task<bool> Contains(RequestHistory request);


        Task AddRequestHistoryAsync(RequestHistory request);
        Task DeleteServiceRequestAsync(RequestHistory request);

    }
}
