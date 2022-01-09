using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryMS.Interface;
using LibraryMS.Services;
using Microsoft.AspNetCore.Authorization;

namespace LibraryMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly IMailService _mailService;
        private readonly IPlanValidity _planValidity;
        private readonly IGetUserData _getUserData;

        public AuthenticationController(ILoggerManager logger, IMapper mapper, IRepositoryManager repository,
            UserManager<User> userManager, IAuthenticationManager authManager, IMailService mailService,
            IPlanValidity planValidity, IGetUserData getUserData)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
            _authManager = authManager;
            _mailService = mailService;
            _planValidity = planValidity;
            _getUserData = getUserData;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost] 
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded) 
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description); 
                } return BadRequest(ModelState);
            }
            await _userManager.AddToRoleAsync(user, "Admin");

            return Ok("Admin Created"); 
        }


        [HttpPost("UserRegistration")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            user.PlanDate = DateTime.Today.AddDays(-1).Date;
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRoleAsync(user, "User");
            CreateMail createMail = new CreateMail(_repository, _logger, _mailService, _getUserData);
            createMail.NewRegistrationMail(user.UserName, user.Email);
            //_planValidity.CreateValidity(userForRegistration.UserName);
            return Ok("User Created");
            
        }

        [HttpPost("login")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user) 
        {
            if (!await _authManager.ValidateUser(user)) 
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() });
        }

        //[Authorize(Roles = "User")]
        [HttpGet("Role")]
        //[Route("GetRole")]
        public async Task<IActionResult> GetUserRole(string Username)
        {
            var role = await _getUserData.GetRoles(Username);
            return Ok(role);
        }

        [HttpGet("Email")]
        //[Route("GetRole")]
        public async Task<IActionResult> GetUserEmail(string Username)
        {
            var role = await _getUserData.GetEmail(Username);
            return Ok(role);
        }
    }
}
