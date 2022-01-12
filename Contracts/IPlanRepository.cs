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
        public Task<IEnumerable<Plan>> GetAllPlansAsync();
        void CreatePlan(Plan plan);
        public void DeletePlan(Plan plan);
        public void UpdatePlanAsync(Plan plan);
        Task<Plan> GetPlanAsync(int id);
        Plan GetPlan(int id);
    }
}