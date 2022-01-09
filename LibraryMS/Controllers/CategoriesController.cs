using AutoMapper;
using Contracts;
using Entities.DTO;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoriesController(IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _repository.Category.GetAllCategories(trackChanges: false);
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _repository.Category.GetCategory(id, trackChanges: false);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            if (categoryDto == null)
            {
                _logger.LogInfo($"Book with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(categoryDto);
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCategory([FromBody]CategoryCreateDto category)
        {
            if (category == null)
            {
                _logger.LogError("category sent from client is null.");
                return BadRequest("category object is null");
            }
            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.CreateCategory(categoryEntity);
            _repository.Save();
            return Ok("Successully Added");
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryCreateDto category)
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
            var categoryEntity = _mapper.Map<Category>(category);
            categoryEntity.CategoryId  = id;
            _repository.Category.UpdateCategory(categoryEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
