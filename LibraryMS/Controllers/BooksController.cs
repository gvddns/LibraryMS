using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LibraryMS.Interface;
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
    public class BooksController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IBookBL _bookbl;

        public BooksController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper, IBookBL bookbl)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _bookbl = bookbl;
        }

        [HttpGet] 
        public async Task<IActionResult> GetBooks() 
        {
            var books = await _repository.Book.GetAllBooksAsync();
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(booksDto);    
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
        public async Task<IActionResult> GetBooksForCategory(int categoryid)
        {
            var category = await _repository.Category.GetCategoryAsync(categoryid);
            if (category == null)
            {
                _logger.LogInfo($"Category with id: {categoryid} doesn't exist in the database.");
                return NotFound();
            }
            var booksforcategory = await _repository.Book.GetBooksAsync(categoryid);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksforcategory);
            return Ok(booksDto);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookCreateDto book)
        {
            var category = await _repository.Category.GetCategoryAsync(book.CategoryId);
            if (category == null)
            {
                _logger.LogError("Category sent from client is null.");
                return BadRequest("Category does not exist.");
            }
            var bookEntity = _mapper.Map<Book>(book);
            _repository.Book.CreateBook(bookEntity);
            await _repository.SaveAsync();
            return Ok("Successully Added");
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response= await _repository.Book.DeleteBookAsync(id);
            await _repository.SaveAsync();
            return Ok(response);
        }
        
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookCreateDto book)
        {
            Book bookToUpdate = await _repository.Book.GetBookAsync(id);
            if (bookToUpdate == null)
            {
                return NotFound("The book record couldn't be found.");
            }
            _mapper.Map(book, bookToUpdate);
            _repository.Save();
            return Ok("Updated Successfully");
            
            
        }

        [HttpGet]
        [Route("AvailableBooks")]
        public async Task<IActionResult> GetAvailableBooks(int bookid, string d)
        {
            var date = DateTime.Parse(d);
            var book = await _repository.Book.GetBookAsync(bookid);
            if (book == null)
            {
                _logger.LogInfo($"Book with id: {bookid} doesn't exist in the database.");
                return NotFound();
            }
            int availablebooks =book.NoOfBooks - _repository.BookDate.FindNpofBooksForDate(bookid, date);
            return Ok(availablebooks);
        }
    }
}
