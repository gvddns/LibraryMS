using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPlanRepository
    {
        public IEnumerable<Plan> GetAllPlans(bool trackChanges);
        void CreatePlan(Plan plan);
        public void DeletePlan(Plan plan);
        public void UpdatePlan(Plan plan);
        Plan GetPlan(int id, bool v);
    }
}