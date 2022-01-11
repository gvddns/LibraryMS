using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRentRequestRepository
    {
        public void CreateRentRequest(RentRequest bookdate);
        public Task<IEnumerable<RentRequest>> GetAllRentRequestsAsync();
        Task<IEnumerable<RentRequest>> GetRentRequestsAsync(string username);
        public Task<RentRequest> GetRentRequestAsync(int UserId);
        public void UpdateRentRequest(RentRequest rentRequest);
    }
}
