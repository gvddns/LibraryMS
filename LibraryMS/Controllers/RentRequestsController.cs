using Contracts;
using Entities.Models;
using LibraryMS.Interface;
using LibraryMS.Services;
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
    public class RentRequestsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMailService _mailService;

        public RentRequestsController(IRepositoryManager repository, ILoggerManager logger, IMailService mailService)
        {
            _repository = repository;
            _logger = logger;
            _mailService = mailService;
        }

        [HttpGet]
        public IActionResult GetAllRentRequests()
        {
            var bookdates = _repository.RentRequest.GetAllRentRequests(trackChanges: false);
            return Ok(bookdates);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetRentrequests(int id)
        //{
        //    var rentrequests = _repository.RentRequest.GetRentRequests(id, trackChanges: false);
        //    if (rentrequests == null)
        //    {
        //        _logger.LogInfo($"rentrequests with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(rentrequests);
        //    }
        //}

        [HttpPost]
        public IActionResult CreateBookDate([FromBody] RentRequest rentrequests)
        {
            if (rentrequests == null)
            {
                _logger.LogError("rentrequests sent from client is null.");
                return BadRequest("rentrequests object is null");
            }
            _repository.RentRequest.CreateRentRequest(rentrequests);
            _repository.Save();
            return Ok(rentrequests);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RentRequest rentRequest)
        {
            if (rentRequest == null)
            {
                return BadRequest("RentRequest is null.");
            }
            RentRequest rentRequestToUpdate = _repository.RentRequest.GetRentRequest(id, false);
            if (rentRequestToUpdate == null)
            {
                return NotFound("The RentRequest record couldn't be found.");
            }
            rentRequest.id = id;
            _repository.RentRequest.UpdateRentRequest(rentRequest);
            _repository.Save();
            CreateMail createMail = new CreateMail(_repository,_logger,_mailService);
            if (rentRequest.approval == "Approved")
                createMail.NewMail(rentRequest);
            return NoContent();
        }
    }
}
