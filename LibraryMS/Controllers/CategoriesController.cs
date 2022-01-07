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
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CategoriesController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _repository.Category.GetAllCategories(trackChanges: false);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var categories = _repository.Category.GetCategory(id, trackChanges: false);
            if (categories == null)
            {
                _logger.LogInfo($"Book with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(categories);
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody]Category category)
        {
            if (category == null)
            {
                _logger.LogError("category sent from client is null.");
                return BadRequest("category object is null");
            }
            _repository.Category.CreateCategory(category);
            _repository.Save();
            return Ok("Successully Added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _repository.Category.GetCategory(id, false);
            if (category == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound("The category record couldn't be found.");
            }
            _repository.Category.DeleteCategory(category);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("category is null.");
            }
            Category categoryToUpdate = _repository.Category.GetCategory(id, false);
            if (categoryToUpdate == null)
            {
                return NotFound("The category record couldn't be found.");
            }
            category.CategoryId  = id;
            _repository.Category.UpdateCategory(category);
            _repository.Save();
            return NoContent();
        }
    }
}
