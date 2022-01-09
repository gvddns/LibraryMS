using Contracts;
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
    public class BookDatesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public BookDatesController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllBookDates()
        {
            var bookdates = _repository.BookDate.GetAllBookDates(trackChanges: false);
            
            return Ok(bookdates);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetBookdates(int id)
        {
            var bookdates = _repository.BookDate.GetBookDates(id, trackChanges: false);
            if (bookdates == null)
            {
                _logger.LogInfo($"BookDate with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(bookdates);
            }
        }

        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateBookDate([FromBody] BookDate bookdates)
        {
            if (bookdates == null)
            {
                _logger.LogError("category sent from client is null.");
                return BadRequest("category object is null");
            }
            _repository.BookDate.CreateBookDate(bookdates);
            _repository.Save();
            return Ok("Successfully Created");
        }
    }
}
