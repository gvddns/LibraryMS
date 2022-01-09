using Contracts;
using Entities;
using Entities.Models;
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

        public RentRequest GetRentRequest(int id, bool trackChanges)
        {
            return FindByCondition(c => c.id.Equals(id), trackChanges).SingleOrDefault();
        }

        public void UpdateRentRequest(RentRequest rentRequest)
        {
            Update(rentRequest);
        }

        IEnumerable<RentRequest> IRentRequestRepository.GetAllRentRequests(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(b => b.id).ToList();
        }

        IEnumerable<RentRequest> IRentRequestRepository.GetRentRequests(string username, bool trackChanges)
        {
            return FindByCondition(b => b.username.Equals(username), trackChanges).ToList();
        }
    }
}
