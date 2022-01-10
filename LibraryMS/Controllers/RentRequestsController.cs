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
        public IActionResult GetRentRequests()
        {
            var rentrequest = _repository.RentRequest.GetAllRentRequests(trackChanges: false);
            var rentrequestDto = _mapper.Map<IEnumerable<RentRequestDto>>(rentrequest);
            return Ok(rentrequestDto);
        }

        [HttpGet("username")]
        public IActionResult GetRentrequests(string username)
        {
            var rentrequests = _repository.RentRequest.GetRentRequests(username, trackChanges: false);
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
            var rentrequestsEntity = _mapper.Map<RentRequest>(rentrequests);
            rentrequestsEntity.approval = "Pending";
            var book = _repository.Book.GetBook(rentrequestsEntity.BookId, false);

            rentrequestsEntity.totalrent = Math.Max(book.rent,(rentrequestsEntity.startdate.Date - rentrequestsEntity.enddate.Date).Days*book.rent);
            _repository.RentRequest.CreateRentRequest(rentrequestsEntity);
            await _repository.SaveAsync();
            return Ok(rentrequests);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> RentRequestUpdate([FromBody] RentRequestUpdateDto rentRequest)
        {
            RentRequest rentRequestToUpdate = _repository.RentRequest.GetRentRequest(rentRequest.rid, false);
            if (rentRequestToUpdate == null)
            {
                return NotFound("The RentRequest record couldn't be found.");
            }
            string approval = rentRequestToUpdate.approval;
            rentRequestToUpdate.approval = rentRequest.approval;
            rentRequestToUpdate.approvaldate = DateTime.Today.Date;
            _repository.RentRequest.UpdateRentRequest(rentRequestToUpdate);
            _repository.Save();

            CreateMail createMail = new CreateMail(_repository,_logger,_mailService, _getUserData, _addBookDate);
            if (rentRequest.approval == "Approved" &&  approval=="Pending")
            {
                await createMail.NewMail(rentRequestToUpdate);

                //    BookDateDto bookDate = new BookDateDto()
                //    {
                //        BookId = rentRequest.BookId
                //    };

                //    while (DateTime.Compare(rentRequest.startdate.Date, rentRequest.enddate.Date) <= 0)
                //    {
                //        bookDate.date = rentRequest.startdate.Date;
                //        var bookDateEntity = _mapper.Map<BookDate>(bookDate);

                //        _repository.BookDate.CreateBookDate(bookDateEntity);
                //        _repository.Save();
                //        rentRequest.startdate = rentRequest.startdate.AddDays(1);
                //    }

            }

            return Ok(rentRequestToUpdate);
        }
    }
}
