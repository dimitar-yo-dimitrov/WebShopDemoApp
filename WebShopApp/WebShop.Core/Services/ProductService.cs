using Microsoft.EntityFrameworkCore;
using WebShop.Core.Contracts;
using WebShop.Core.Data.Common;
using WebShop.Core.Data.Models;
using WebShop.Core.Models;

namespace WebShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repo;

        /// <summary>
        /// IoC 
        /// </summary>
        /// <param name="repo">Application configuration</param>
        public ProductService(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">Product model</param>
        /// <returns></returns>
        public async Task Add(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };

            await _repo.AddAsync(product);
            await _repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await _repo.All<Product>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.IsActive = false;

                await _repo.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await _repo.AllReadonly<Product>(p => p.IsActive)
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToListAsync();
        }

        //public async Task<IEnumerable<ProductDto>> GetAllWhere(Expression<Func<Product, bool>> search)
        //{
        //    return await _repo.AllReadonly(search)
        //        .Select(p => new ProductDto()
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Price = p.Price,
        //            Quantity = p.Quantity
        //        }).ToListAsync();
        //}
    }
}
