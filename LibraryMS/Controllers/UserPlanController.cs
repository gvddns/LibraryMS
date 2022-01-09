using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LibraryMS.Interface;
using LibraryMS.Services;
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
    public class UserPlanController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly IPlanValidity _planValidity;

        public UserPlanController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IMailService mailService, IPlanValidity planValidity)
        {
            _repository = repository;
            _logger = logger;
            _mailService = mailService;
            _mapper = mapper;
            _planValidity = planValidity;
        }

        //[Authorize(Roles = "Admin")]
        //[HttpGet]
        //public IActionResult GetAllUserPlans()
        //{
        //    var UserPlans = _repository.UserPlanValidity.GetAllUserPlanValidity(trackChanges: false);
        //    return Ok(UserPlans);
        //}

        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "Admin")]
        //[HttpGet("Username")]
        //public IActionResult GetUserPlan(string username)
        //{
        //    var UserPlan = _repository.UserPlanValidity.GetUserPlanValidity(username,trackChanges: false);
        //    return Ok(UserPlan);
        //}

        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "Admin")]
        //[HttpGet("PlanExtension")]
        //public IActionResult ExtendUserPlan(string username, int id)
        //{

        //    //int response =_planValidity.AddValidity(username, id);
        //    //if(response==1)
        //    //return Ok("Successfully Updated");
        //    //else
        //    //    return Ok("Add Correct Data");
        //}
    }
}
