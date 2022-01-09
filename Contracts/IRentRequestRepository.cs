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
        public IEnumerable<RentRequest> GetAllRentRequests(bool trackChanges);
        IEnumerable<RentRequest> GetRentRequests(string username, bool trackChanges);
        public RentRequest GetRentRequest(int UserId, bool trackChanges);
        public void UpdateRentRequest(RentRequest rentRequest);
    }
}
