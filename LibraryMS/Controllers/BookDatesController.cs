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
        public async Task<IActionResult> GetAllBookDates()
        {
            var bookdates = await _repository.BookDate.GetAllBookDatesAsync();
            return Ok(bookdates);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookdates(int id)
        {
            var bookdates = await _repository.BookDate.GetBookDatesAsync(id);
            if (bookdates == null)
            {
                _logger.LogInfo($"BookDate with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
                return Ok(bookdates);    
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBookDate([FromBody] BookDate bookdates)
        {
            _repository.BookDate.CreateBookDate(bookdates);
            await _repository.SaveAsync();
            return Ok("Successfully Created");
        }
    }
}
