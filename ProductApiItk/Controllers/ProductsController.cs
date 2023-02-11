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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<ProductResponseDTO>> Get()
        {
            return await _productService.GetAllProductsAsync();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ProductResponseDTO> Get(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ProductResponseDTO> Post([FromBody] ProductRequestDTO product)
        {
            return await _productService.CreateAsync(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ProductResponseDTO> Put(int id, [FromBody] ProductRequestDTO product)
        {
            return await _productService.UpdateAsync(id, product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ProductResponseDTO> Delete(int id)
        {
            return await _productService.DeleteAsync(id);
        }
    }
}
