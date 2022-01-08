using AutoMapper;
using Contracts;
using Entities.DTO;
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
        private readonly IMapper _mapper;
        private readonly IAddBookDate _addBookDate;

        public RentRequestsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IMailService mailService, IAddBookDate addBookDate)
        {
            _repository = repository;
            _logger = logger;
            _mailService = mailService;
            _mapper = mapper;
            _addBookDate = addBookDate;
        }

        [HttpGet]
        public IActionResult GetRentRequests()
        {
            var rentrequest = _repository.RentRequest.GetAllRentRequests(trackChanges: false);
            //var rentrequestEntity = _mapper.Map<RentRequestUpdateDto>(rentrequest);
            return Ok(rentrequest);
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
        public IActionResult CreateRentRequest([FromBody] RentRequestCreateDto rentrequests)
        {
            if (rentrequests == null)
            {
                _logger.LogError("rentrequests sent from client is null.");
                return BadRequest("rentrequests object is null");
            }
            var rentrequestsEntity = _mapper.Map<RentRequest>(rentrequests);
            rentrequestsEntity.approval = "Pending";
            _repository.RentRequest.CreateRentRequest(rentrequestsEntity);
            _repository.Save();
            return Ok(rentrequests);
        }

        [HttpPut]
        public IActionResult RentRequestUpdate([FromBody] RentRequestDto rentRequest)
        {
            if (rentRequest == null)
            {
                return BadRequest("RentRequest is null.");
            }
            RentRequest rentRequestToUpdate = _repository.RentRequest.GetRentRequest(rentRequest.id, false);
            if (rentRequestToUpdate == null)
            {
                return NotFound("The RentRequest record couldn't be found.");
            }
            var rentRequestEntity = _mapper.Map<RentRequest>(rentRequest);
            _repository.RentRequest.UpdateRentRequest(rentRequestEntity);
            _repository.Save();
            CreateMail createMail = new CreateMail(_repository,_logger,_mailService);
            if (rentRequest.approval == "Approved" && rentRequestToUpdate.approval=="Pending")
            {
                createMail.NewMail(rentRequestEntity);
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
                _addBookDate.AddBooks(rentRequestEntity.startdate, rentRequestEntity.enddate, rentRequestEntity.BookId);
            }
                
            return NoContent();
        }
    }
}
