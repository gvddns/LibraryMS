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
    public class RentRequestsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly IAddBookDate _addBookDate;
        private readonly IGetUserData _getUserData;

        public RentRequestsController(IRepositoryManager repository, ILoggerManager logger, 
            IMapper mapper, IMailService mailService, IAddBookDate addBookDate, IGetUserData getUserData)
        {
            _repository = repository;
            _logger = logger;
            _mailService = mailService;
            _mapper = mapper;
            _addBookDate = addBookDate;
            _getUserData = getUserData;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetRentRequests()
        {
            var rentrequest = await _repository.RentRequest.GetAllRentRequestsAsync();
            var rentrequestDto = _mapper.Map<IEnumerable<RentRequestDto>>(rentrequest);
            return Ok(rentrequestDto);
        }

        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "Admin")]
        [HttpGet("username")]
        public async Task<IActionResult> GetRentrequests(string username)
        {
            var rentrequests = await _repository.RentRequest.GetRentRequestsAsync(username);
            var rentrequestDto = _mapper.Map<IEnumerable<RentRequestDto>>(rentrequests);
            return Ok(rentrequestDto);
        }

        //[Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> CreateRentRequest([FromBody] RentRequestCreateDto rentrequests)
        {
            if (rentrequests == null)
            {
                _logger.LogError("rentrequests sent from client is null.");
                return BadRequest("rentrequests object is null");
            }
            var userid = await _getUserData.GetUserId(rentrequests.username);
            if(userid==null)
            {
                _logger.LogError("User for user name does not exist");
                return BadRequest("Username does not exist");
            }
            string validity = await _getUserData.CheckDates(rentrequests.username,rentrequests.startdate,rentrequests.enddate);
            if (validity !=null)
            {
                _logger.LogError(validity);
                return BadRequest(validity);
            }
            var book = _repository.Book.GetBook(rentrequests.BookId);
            if(book==null)
            {
                _logger.LogError("Book does not exist");
                return BadRequest("Book does not exist");
            }
            var rentrequestsEntity = _mapper.Map<RentRequest>(rentrequests);
            rentrequestsEntity.totalrent = book.rent;//Math.Max(book.rent//, 
                //(rentrequestsEntity.startdate.Date - rentrequestsEntity.enddate.Date).Days * book.rent);

            rentrequestsEntity.approval = "Pending";
            _repository.RentRequest.CreateRentRequest(rentrequestsEntity);
            _repository.Save();
            return Ok();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> RentRequestUpdate([FromBody] RentRequestUpdateDto rentRequest)
        {
            RentRequest rentRequestToUpdate = await _repository.RentRequest.GetRentRequestAsync(rentRequest.rid);
            if (rentRequestToUpdate == null)
            {
                return NotFound("The RentRequest record couldn't be found.");
            }
            string approval = rentRequestToUpdate.approval;
            rentRequestToUpdate.approval = rentRequest.approval;
            rentRequestToUpdate.approvaldate = DateTime.Today.Date;
            _repository.Save();

            CreateMail createMail = new CreateMail(_repository,_logger,_mailService, _getUserData, _addBookDate);
            if (rentRequest.approval == "Approved" &&  approval=="Pending")
                await createMail.NewMail(rentRequestToUpdate);

            
            return Ok("Request Processed");
        }
    }
}
