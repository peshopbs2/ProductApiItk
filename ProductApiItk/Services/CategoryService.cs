using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductApiItk.Data;
using ProductApiItk.DTO.Requests;
using ProductApiItk.DTO.Responses;
using ProductApiItk.Repositories;

namespace ProductApiItk.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO category)
        {
            var item = await _categoryRepository.CreateAsync(new Category()
            {
              Title = category.Title,
              Created = DateTime.Now
            });

            return new CategoryResponseDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Created = item.Created,
                Modified = item.Modified
            };
        }

        public async Task<CategoryResponseDTO> DeleteAsync(int categoryId)
        {
            var item = await _categoryRepository.DeleteAsync(categoryId);

            return new CategoryResponseDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Created = item.Created,
                Modified = item.Modified
            };
        }

        public async Task<ICollection<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories
                .Select(item => new CategoryResponseDTO()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Created = item.Created,
                    Modified = item.Modified
                })
                .ToList();
        }

        public async Task<CategoryResponseDTO> GetCategoryByIdAsync(int categoryId)
        {
            var item = await _categoryRepository.GetByIdAsync(categoryId);

            return new CategoryResponseDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Created = item.Created,
                Modified = item.Modified
            };
        }

        public async Task<CategoryResponseDTO> UpdateAsync(int categoryId, CategoryRequestDTO category)
        {
            var item = await _categoryRepository.GetByIdAsync(categoryId);
            item.Title = category.Title;
            item.Modified = DateTime.Now;

            var product = await _categoryRepository.UpdateAsync(item);

            return new CategoryResponseDTO()
            {
                Id = product.Id,
                Title = product.Title,
                Created = product.Created,
                Modified = product.Modified
            };
        }
    }
}
