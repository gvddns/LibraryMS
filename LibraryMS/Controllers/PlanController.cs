using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LoggerService;
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
        public IActionResult GetPlans()
        {
            var plans = _repository.Plan.GetAllPlans(trackChanges: false);
            var plansDto = _mapper.Map<IEnumerable<PlanDto>>(plans);
            return Ok(plansDto);
        }

        [HttpPost]
        public IActionResult CreatePlan([FromBody] PlanCreateDto plan)
        {
            if (plan == null)
            {
                _logger.LogError("Plan sent from client is null.");
                return BadRequest("Plan object is null");
            }
            var planEntity = _mapper.Map<Plan>(plan);
            _repository.Plan.CreatePlan(planEntity);
            _repository.Save();
            return Ok("Successully Added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlan(int id)
        {
            Plan plan = _repository.Plan.GetPlan(id, false);
            if (plan == null)
            {
                _logger.LogInfo($"Plan with id: {id} doesn't exist in the database.");
                return NotFound("The Plan record couldn't be found.");
            }
            _repository.Plan.DeletePlan(plan);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PlanCreateDto plan)
        {
            if (plan == null)
            {
                return BadRequest("Plan is null.");
            }
            Plan planToUpdate = _repository.Plan.GetPlan(id, false);
            if (planToUpdate == null)
            {
                return NotFound("The Plan record couldn't be found.");
            }
            var planEntity = _mapper.Map<Plan>(plan);
            planEntity.Planid = id;
            _repository.Plan.UpdatePlan(planEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
