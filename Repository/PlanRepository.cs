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

        public async Task<IEnumerable<Plan>> GetAllPlansAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Plan> GetPlanAsync(int id)
        {
            return await FindByCondition(c => c.Planid.Equals(id)).SingleOrDefaultAsync();
        }

        public void UpdatePlan(Plan plan)
        {
            Update(plan);
        }
    }
}
