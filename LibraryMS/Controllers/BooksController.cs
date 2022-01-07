using Contracts;
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
    public class BooksController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public BooksController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        [HttpGet] 
        public IActionResult GetBooks() 
        {
            var books = _repository.Book.GetAllBooks(trackChanges: false);
            return Ok(books);    
        }

        //[HttpGet("{id}")]
        //public IActionResult GetBook(int id) 
        //{
        //    var book = _repository.Book.GetBook(id, trackChanges: false);
        //    if (book == null) 
        //    {
        //        _logger.LogInfo($"Book with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    else 
        //    {
        //        return Ok(book); 
        //    } 
        //}

        [HttpGet("{categoryid}")]
        public IActionResult GetBooksForCategory(int categoryid)
        {
            var category = _repository.Category.GetCategory(categoryid, trackChanges: false);
            if (category == null)
            {
                _logger.LogInfo($"Company with id: {categoryid} doesn't exist in the database.");
                return NotFound();
            }
            var booksforcategory = _repository.Book.GetBooks(categoryid, trackChanges: false);
            return Ok(booksforcategory);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
            {
                _logger.LogError("Book sent from client is null.");
                return BadRequest("Book is null.");
            }
            _repository.Book.CreateBook(book);
            _repository.Save();
            return Ok("Successully Added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            Book book = _repository.Book.GetBook(id,false);
            if (book == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound("The book record couldn't be found.");
            }
            _repository.Book.DeleteBook(book);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("book is null.");
            }
            Book bookToUpdate = _repository.Book.GetBook(id,false);
            if (bookToUpdate == null)
            {
                return NotFound("The book record couldn't be found.");
            }
            book.BookId = id;
            _repository.Book.UpdateBook(book);
            _repository.Save();
            return NoContent();
        }

        [HttpGet]
        [Route("AvailableBooks")]
        public IActionResult GetAvailableBooks(int bookid, string d)
        {
            var date = DateTime.Parse(d);
            var book = _repository.Book.GetBook(bookid, trackChanges: false);
            if (book == null)
            {
                _logger.LogInfo($"Book with id: {bookid} doesn't exist in the database.");
                return NotFound();
            }
            int availablebooks =book.NoOfBooks - _repository.BookDate.FindNpofBooksForDate(bookid, date, false);
            return Ok(availablebooks);
        }
    }
}
