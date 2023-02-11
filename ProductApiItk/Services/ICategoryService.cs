using ProductApiItk.DTO.Requests;
using ProductApiItk.DTO.Responses;

namespace ProductApiItk.Services
{
    public interface ICategoryService
    {
        public Task<CategoryResponseDTO> GetCategoryByIdAsync(int categoryId);
        public Task<ICollection<CategoryResponseDTO>> GetAllCategoriesAsync();
        public Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO category);
        public Task<CategoryResponseDTO> UpdateAsync(int categoryId, CategoryRequestDTO category);
        public Task<CategoryResponseDTO> DeleteAsync(int categoryId);
    }
}
