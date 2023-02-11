using ProductApiItk.DTO.Requests;
using ProductApiItk.DTO.Responses;

namespace ProductApiItk.Services
{
    public interface IProductService
    {
        //TODO: Should we use DTOs here?
        public Task<ProductResponseDTO> GetProductByIdAsync(int productId);
        public Task<ICollection<ProductResponseDTO>> GetAllProductsAsync();
        public Task<ProductResponseDTO> CreateAsync(ProductRequestDTO item);
        public Task<ProductResponseDTO> UpdateAsync(int productId, ProductRequestDTO item);
        public Task<ProductResponseDTO> DeleteAsync(int productId);
    }
}
