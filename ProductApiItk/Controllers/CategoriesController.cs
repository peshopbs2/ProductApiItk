using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductApiItk.DTO.Requests;
using ProductApiItk.DTO.Responses;
using ProductApiItk.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApiItk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<CategoryResponseDTO>> Get()
        {
            return await _categoryService.GetAllCategoriesAsync();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<CategoryResponseDTO> Get(int id)
        {
            return await _categoryService.GetCategoryByIdAsync(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<CategoryResponseDTO> Post([FromBody] CategoryRequestDTO categoryRequestDTO)
        {
            return await _categoryService.CreateAsync(categoryRequestDTO);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<CategoryResponseDTO> Put(int id, [FromBody] CategoryRequestDTO categoryRequestDTO)
        {
            return await _categoryService.UpdateAsync(id, categoryRequestDTO);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<CategoryResponseDTO> Delete(int id)
        {
            return await _categoryService.DeleteAsync(id);
        }
    }
}
