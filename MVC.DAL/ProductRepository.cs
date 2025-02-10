using Microsoft.EntityFrameworkCore;
using MVC.DAL.Entities;
using MVC.DAL.Interfaces;
using MVC.Model.Enams;


namespace MVC.DAL
{


    public class ProductRepository : IRepository<Product>
    {
        private readonly MarketDbContext _dbContext;
        public ProductRepository(MarketDbContext context)
        {
            _dbContext = context;
        }

        public async Task< IEnumerable<Product>> GetAllAsync(Products category)
        {
            return await _dbContext.Products.Where(p => p.Category == category).ToListAsync();
        }
        public async Task AddAsync(Product product)
        {
            product.Name = product.Name;

           await _dbContext.Products.AddAsync(product);
           await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
                existingProduct.Quantity = product.Quantity;
               await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} was not found.");
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
               await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
