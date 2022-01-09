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
    public class UserPlanValidityRepository : RepositoryBase<UserPlanValidity>, IUserPlanValidityRepository
    {
        public UserPlanValidityRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateUserPlanValidity(UserPlanValidity userPlanValidity)
        {
            Create(userPlanValidity);
        }

        public UserPlanValidity GetUserPlanValidity(string UserName, bool trackChanges)
        {
            return FindByCondition(c => c.UserName.Equals(UserName), trackChanges).SingleOrDefault();
        }

        public IEnumerable< UserPlanValidity> GetAllUserPlanValidity(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public void UpdateUserPlanValidity(UserPlanValidity userPlanValidity)
        {
            Update(userPlanValidity);
        }
    }
}
