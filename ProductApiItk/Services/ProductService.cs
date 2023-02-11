using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductApiItk.Data;
using ProductApiItk.DTO.Requests;
using ProductApiItk.DTO.Responses;
using ProductApiItk.Repositories;

namespace ProductApiItk.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        public ProductService(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<ProductResponseDTO> CreateAsync(ProductRequestDTO item)
        {
            var product = await _productRepository.CreateAsync(new Product()
            {
                Title = item.Title,
                Description = item.Description,
                Price = item.Price,
                Created = DateTime.Now,
                Categories = item.CategoryIds
                    .Select(categoryId =>
                _categoryRepository.GetByIdAsync(categoryId).Result)
                    .ToList()
            });

            return new ProductResponseDTO()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Created = product.Created,
                Modified = product.Modified,
                Price = product.Price,
                Categories = product
                    .Categories
                    .Select(category => new CategoryResponseDTO()
                    {
                        Id = category.Id,
                        Title = category.Title,
                        Created = category.Created,
                        Modified = category.Modified
                    }
                    )
                    .ToList()
            };
        }

        public async Task<ProductResponseDTO> DeleteAsync(int productId)
        {
            var product = await _productRepository.DeleteAsync(productId);
            return new ProductResponseDTO()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Created = product.Created,
                Modified = product.Modified,
                Price = product.Price,
                Categories = product
                                .Categories
                                .Select(category => new CategoryResponseDTO()
                                {
                                    Id = category.Id,
                                    Title = category.Title,
                                    Created = category.Created,
                                    Modified = category.Modified
                                }
                                )
                                .ToList()
            };
        }

        public async Task<ICollection<ProductResponseDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products
                .Select(product => new ProductResponseDTO()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Created = product.Created,
                    Modified = product.Modified,
                    Price = product.Price,
                    Categories = product
                                .Categories
                                .Select(category => new CategoryResponseDTO()
                                {
                                    Id = category.Id,
                                    Title = category.Title,
                                    Created = category.Created,
                                    Modified = category.Modified
                                }
                                )
                                .ToList()
                })
                .ToList();
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            return new ProductResponseDTO()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Created = product.Created,
                Modified = product.Modified,
                Price = product.Price,
                Categories = product
                                .Categories
                                .Select(category => new CategoryResponseDTO()
                                {
                                    Id = category.Id,
                                    Title = category.Title,
                                    Created = category.Created,
                                    Modified = category.Modified
                                }
                                )
                                .ToList()
            };
        }

        public async Task<ProductResponseDTO> UpdateAsync(int productId, ProductRequestDTO item)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            product.Title = item.Title;
            product.Description = item.Description;
            product.Price = item.Price;
            product.Modified = DateTime.Now;
            await _productRepository.UpdateAsync(product);
            
            return new ProductResponseDTO()
        {
            Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Created = product.Created,
                Modified = product.Modified,
                Price = product.Price,
                Categories = product
                    .Categories
                    .Select(category => new CategoryResponseDTO()
                    {
                        Id = category.Id,
                        Title = category.Title,
                        Created = category.Created,
                        Modified = category.Modified
                    }
                    )
                    .ToList()
            };

    }
}
}
