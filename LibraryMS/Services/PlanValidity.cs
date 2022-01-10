using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LibraryMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Services
{
    public class PlanValidity : IPlanValidity
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PlanValidity(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> AddValidityAsync(string username, int planid)
        {
            var userplan = _repository.UserPlanValidity.GetUserPlanValidity(username, false);
            var plan = _repository.Plan.GetPlan(planid, false);
            //var userplanDto = _mapper.Map<UserPlanValidityDto>(userplan);
            //_repository.UserPlanValidity.CreateUserPlanValidity();
            if (DateTime.Compare(userplan.planEnddate, DateTime.Today.Date) <= 0)
            {
                userplan.planEnddate = DateTime.Today.AddDays(plan.Duration).Date;
            }
            else
            {
                userplan.planEnddate = userplan.planEnddate.AddDays(plan.Duration).Date;
            }
            _repository.UserPlanValidity.UpdateUserPlanValidity(userplan);
            await _repository.SaveAsync();
            return 1;

        }

        public async void CreateValidity(string username)
        {
            UserPlanValidityDto userplan = new UserPlanValidityDto();
            userplan.UserName = username;
            userplan.planEnddate = DateTime.Today.AddDays(-1).Date;
            var userplanEntity = _mapper.Map<UserPlanValidity>(userplan);
            _repository.UserPlanValidity.CreateUserPlanValidity(userplanEntity);
            await _repository.SaveAsync();
        }
    }
}
