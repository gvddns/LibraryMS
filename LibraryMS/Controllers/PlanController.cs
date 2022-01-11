using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PlanController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            var plans = await _repository.Plan.GetAllPlansAsync();
            var plansDto = _mapper.Map<IEnumerable<PlanDto>>(plans);
            return Ok(plansDto);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePlan([FromBody] PlanCreateDto plan)
        {
            var planEntity = _mapper.Map<Plan>(plan);
            _repository.Plan.CreatePlan(planEntity);
            await _repository.SaveAsync();
            return Ok("Successully Added");
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            Plan plan = await _repository.Plan.GetPlanAsync(id);
            if (plan == null)
            {
                _logger.LogInfo($"Plan with id: {id} doesn't exist in the database.");
                return NotFound("The Plan record couldn't be found.");
            }
            _repository.Plan.DeletePlan(plan);
            await _repository.SaveAsync();
            return NoContent();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlanCreateDto plan)
        {
            Plan planToUpdate = await _repository.Plan.GetPlanAsync(id);
            if (planToUpdate == null)
            {
                return NotFound("The Plan record couldn't be found.");
            }
            var planEntity = _mapper.Map<Plan>(plan);
            planEntity.Planid = id;
            _repository.Plan.UpdatePlan(planEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
