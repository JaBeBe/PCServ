using PCServ.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCServ.Models.ServRequestRepo
{
    public class RequestHistoryRepository : IRequestHistoryRepository
    {
        private readonly AppDbContext _ctx;

        public RequestHistoryRepository(AppDbContext context)
        {
            _ctx = context;
        }

        public List<RequestHistory> Histories => _ctx.ReqHistory.ToList();
        public async Task<RequestHistory> GetRequestHistoryAsync(int id) => await Task.FromResult(_ctx.ReqHistory.SingleOrDefault(x => x.Id == id));

        public async Task<RequestHistory> GetRequestHistoryAsync(User.User client) => await Task.FromResult(_ctx.ReqHistory.SingleOrDefault(x => x.Client == client));
        public async Task AddRequestHistoryAsync(RequestHistory request)
        {
            _ctx.ReqHistory.Add(request);
            await Task.CompletedTask;
        }

        public async Task DeleteServiceRequestAsync(RequestHistory request)
        {
            _ctx.ReqHistory.Remove(request);
            await Task.CompletedTask;
        }

        Task<IEnumerable<RequestHistory>> IRequestHistoryRepository.Histories(ServiceRequest request)
        {
            var reqHistorties = _ctx.ReqHistory.AsEnumerable();
            if (request != null)
            {
                reqHistorties = reqHistorties.Where(x => x.Request == request).OrderBy(x=>x.CreateAt);
            }
            return Task.FromResult(reqHistorties);
        }

        public async Task<bool> Contains(RequestHistory request) => await Task.FromResult(_ctx.ReqHistory.Contains(request));
    }
}
