using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Data_BusinessLogic.Services
{
    public interface IRequestRepository
    {
        Task<List<Requests>> GetAllRequestsAsync();
        Task<Requests> GetRequestAsync(int requestID);
        Task<Requests> UpdateRequestAsync(Requests request);
        Task DeleteRequestAsync(int requestID);
        Task<Requests> AddRequestsAsync(Requests request);
    }
    public class RequestRepository : IRequestRepository
    {
        private readonly RepairDBEntities _dbcon = RepairDBEntities._context;
        public async Task<Requests> AddRequestsAsync(Requests request)
        {
            _dbcon.Requests.Add(request);
            await _dbcon.SaveChangesAsync();
            return request;
        }

        public async Task DeleteRequestAsync(int requestID)
        {
            var customer = _dbcon.Requests
                .FirstOrDefault(x => x.ID == requestID);
            if (customer != null)
            {
                _dbcon.Requests.Remove(customer);
            }
            await _dbcon.SaveChangesAsync();
        }

        public Task<List<Requests>> GetAllRequestsAsync()
        {
            return _dbcon.Requests.ToListAsync();
        }

        public Task<Requests> GetRequestAsync(int requestID)
        {
            return _dbcon.Requests.FirstOrDefaultAsync(x => x.ID == requestID);
        }

        public async Task<Requests> UpdateRequestAsync(Requests request)
        {
            if (!_dbcon.Requests.Local.Any(x => x.ID == request.ID))
            {
                _dbcon.Requests.Attach(request);
            }
            _dbcon.Entry(request).State = EntityState.Modified;
            await _dbcon.SaveChangesAsync();
            return request;
        }
    }
}
