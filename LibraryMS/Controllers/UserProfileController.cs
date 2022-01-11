using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LibraryMS.Interface;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly IGetUserData _getUserData;


        public UserProfileController(ILoggerManager logger, IMapper mapper, IRepositoryManager repository,
            UserManager<User> userManager, IAuthenticationManager authManager, IGetUserData getUserData)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
            _authManager = authManager;
            _getUserData = getUserData;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProfile()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            var user = _mapper.Map<IEnumerable<UserProfileDto>>(users);
            return Ok(user);
        }

        [HttpGet("Username")]
        public async Task<IActionResult> GetProfile(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var userEntity = _mapper.Map<UserProfileDto>(user);
            return Ok(userEntity);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UserProfileEditDto userProfile)
        {
            string username = userProfile.UserName;
            var user= await _userManager.FindByNameAsync(username);
            user.Address = userProfile.Address;
            user.LastName = userProfile.LastName;
            user.FirstName = userProfile.FirstName;
            user.PhoneNumber = userProfile.PhoneNumber;
            
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok("User Profile Updated");
        }

        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "Admin")]
        [HttpGet("PlanExtension")]
        public async Task<IActionResult> ExtendUserPlan(string username, int id)
        {
            var user = await _userManager.FindByNameAsync(username);
            var plan = await _repository.Plan.GetPlanAsync(id);
            if (DateTime.Compare(DateTime.Today.Date, user.PlanDate) >= 1)
                user.PlanDate = DateTime.Today.AddDays(plan.Duration).Date;
            else
                user.PlanDate = user.PlanDate.AddDays(plan.Duration).Date;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok("New plan added");
        }
    }
}
