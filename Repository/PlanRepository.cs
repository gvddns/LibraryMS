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
    public class PlanRepository : RepositoryBase<Plan>,IPlanRepository
    {
        public PlanRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public void CreatePlan(Plan plan)
        {
            Create(plan);
        }

        public void DeletePlan(Plan plan)
        {
            Delete(plan);
        }

        public IEnumerable<Plan> GetAllPlans(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public Plan GetPlan(int id, bool trackChanges)
        {
            return FindByCondition(c => c.Planid.Equals(id), trackChanges).SingleOrDefault();
        }

        public void UpdatePlan(Plan plan)
        {
            Update(plan);
        }
    }
}
