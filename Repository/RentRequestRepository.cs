using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class RentRequestRepository : RepositoryBase<RentRequest>,IRentRequestRepository
    {
        public RentRequestRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateRentRequest(RentRequest rentrequest)
        {
            Create(rentrequest);
        }

        public async Task< RentRequest> GetRentRequestAsync(int id)
        {
            return await FindByCondition(c => c.rid.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdateRentRequest(RentRequest rentRequest)
        {
            Update(rentRequest);
        }

        async Task<IEnumerable<RentRequest>> IRentRequestRepository.GetAllRentRequestsAsync()
        {
            return await FindAll().OrderBy(b => b.rid).ToListAsync();
        }

        async Task<IEnumerable<RentRequest>> IRentRequestRepository.GetRentRequestsAsync(string username)
        {
            return await FindByCondition(b => b.username.Equals(username)).ToListAsync();
        }
    }
}
