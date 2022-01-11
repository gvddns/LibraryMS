using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserPlanValidityRepository
    {
        void CreateUserPlanValidity(UserPlanValidity userPlanValidity);
        void UpdateUserPlanValidity(UserPlanValidity userPlanValidity);
        UserPlanValidity GetUserPlanValidity(string UserName);
        public IEnumerable<UserPlanValidity> GetAllUserPlanValidity();
    }
}
