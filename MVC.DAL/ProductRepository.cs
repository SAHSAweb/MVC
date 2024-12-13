﻿using MVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL
{
   
    
        public class ProductRepository : IRepository<Product>
        {
            private readonly MarketDbContext _dbContext;
            public ProductRepository(MarketDbContext context)
            {
                _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            }
            public void Add(Product product)
            {
                _dbContext.Products.Add(product);
            }
            public void Delete(Guid id)
            {
                var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);

                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    _dbContext.SaveChanges();
                }
            }
            public IEnumerable<Product> GetAll()
            {
                return _dbContext.Products;
            }
            public Product GetById(Guid id)
            {
                return _dbContext.Products.FirstOrDefault(p => p.Id == id);
            }
        
    }

    
}