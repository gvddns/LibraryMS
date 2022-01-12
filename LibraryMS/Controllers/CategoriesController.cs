using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repository.Category.GetAllCategoriesAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repository.Category.GetCategoryAsync(id);
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
        
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]CategoryCreateDto category)
        {
            if (category == null)
            {
                _logger.LogError("category sent from client is null.");
                return BadRequest("category object is null");
            }
            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.CreateCategory(categoryEntity);
            await _repository.SaveAsync();
            return Ok("Successully Added");
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            Category category = await _repository.Category.GetCategoryAsync(id);
            if (category == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound("The category record couldn't be found.");
            }
            _repository.Category.DeleteCategory(category);
            await _repository.SaveAsync();
            return  Ok();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryCreateDto category)
        {
            if (category == null)
            {
                return BadRequest("category is null.");
            }
            Category categoryToUpdate = await _repository.Category.GetCategoryAsync(id);
            if (categoryToUpdate == null)
            {
                return NotFound("The category record couldn't be found.");
            }
            _mapper.Map(category, categoryToUpdate);
            _repository.Save();
            return NoContent();
        }
    }
}
