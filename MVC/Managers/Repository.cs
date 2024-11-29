using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Interfaces;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Managers
{
    public class Repository
    {
        MarketDB Mdb { get; set; }
        public Repository(MarketDB mdb)
        {
            Mdb = mdb;
        }
        public async Task<IEnumerable<IProducts>> GetAsync(int id)
        {
            if (id == 1)
            {
                var caunt = await Mdb.Beverages.CountAsync();
                if (caunt <= 0)
                {
                    await Mdb.Beverages.AddAsync(new Beverages());
                    await Mdb.SaveChangesAsync();
                    return await Mdb.Beverages.ToListAsync();
                }
                else return await Mdb.Beverages.ToListAsync();
            }
            if (id == 2)
            {
                var caunt = await Mdb.Fish.CountAsync();
                if (caunt <= 0)
                {
                    await Mdb.Fish.AddAsync(new Fish());
                    await Mdb.SaveChangesAsync();
                    return await Mdb.Fish.ToListAsync();
                }
                else return await Mdb.Fish.ToListAsync();
            }
            if (id == 3)
            {
                var caunt = await Mdb.Meat.CountAsync();
                if (caunt <= 0)
                {
                    await Mdb.Meat.AddAsync(new Meat());
                    await Mdb.SaveChangesAsync();
                    return await Mdb.Meat.ToListAsync();
                }
                else return await Mdb.Meat.ToListAsync();
            }
            if (id == 4)
            {
                var caunt = await Mdb.Vegetables.CountAsync();
                if (caunt <= 0)
                {
                    await Mdb.Vegetables.AddAsync(new Vegetables());
                    await Mdb.SaveChangesAsync();
                    return await Mdb.Vegetables.ToListAsync();
                }
                else return await Mdb.Vegetables.ToListAsync();
            }
            else return Enumerable.Empty<IProducts>();
        }
        public ProductViewModel? AddProduct(int id)
        {
            if (id == 1)
            {
                return new ProductViewModel { CategoriesId = 1, CategoriesName = "BEVERAGES" };
            }
            if (id == 2)
            {
                return new ProductViewModel { CategoriesId = 2, CategoriesName = "FISH" };
            }
            if (id == 3)
            {
                return new ProductViewModel { CategoriesId = 3, CategoriesName = "MEAT" };
            }
            if (id == 4)
            {
                return new ProductViewModel { CategoriesId = 4, CategoriesName = "VEGETABLES" };
            }
            else return null;
        }
        public async Task AddCategoryAsync(ProductViewModel model)
        {
            if (model.CategoriesId == 1)
            {
                var product = new Beverages()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Price = model.Price
                };
                await Mdb.Beverages.AddAsync(product);
                await Mdb.SaveChangesAsync();
            }
            if (model.CategoriesId == 2)
            {
                var product = new Fish()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Price = model.Price
                };
                await Mdb.Fish.AddAsync(product);
                await Mdb.SaveChangesAsync();
            }
            if (model.CategoriesId == 3)
            {
                var product = new Meat()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Price = model.Price

                };
                await Mdb.Meat.AddAsync(product);
                await Mdb.SaveChangesAsync();
            }
            if (model.CategoriesId == 4)
            {
                var product = new Vegetables()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Price = model.Price
                };
                await Mdb.Vegetables.AddAsync(product);
                await Mdb.SaveChangesAsync();
            }
        }
        public async Task DeleteCategoryAsync(int Id, int categoriesId)
        {
            if (categoriesId == 1)
            {
                var category = await Mdb.Beverages.FirstOrDefaultAsync(x => x.Id == Id);
                if (category != null)
                {
                    Mdb.Beverages.Remove(category);
                    await Mdb.SaveChangesAsync();
                }
            }
            if (categoriesId == 2)
            {
                var category = await Mdb.Fish.FirstOrDefaultAsync(x => x.Id == Id);
                if (category != null)
                {
                    Mdb.Fish.Remove(category);
                    await Mdb.SaveChangesAsync();
                }
            }
            if (categoriesId == 3)
            {
                var category = await Mdb.Meat.FirstOrDefaultAsync(x => x.Id == Id);
                if (category != null)
                {
                    Mdb.Meat.Remove(category);
                    await Mdb.SaveChangesAsync();
                }
            }
            if (categoriesId == 4)
            {
                var category = await Mdb.Vegetables.FirstOrDefaultAsync(x => x.Id == Id);
                if (category != null)
                {
                    Mdb.Vegetables.Remove(category);
                    await Mdb.SaveChangesAsync();
                }
            }
        }
        public ProductViewModel CreateModel(int Id, int categoriesId)
        {
            if (categoriesId == 1)
            {
                var category = Mdb.Beverages.FirstOrDefault(x => x.Id == Id);
                if (category != null)
                {
                    var product = new ProductViewModel()
                    {
                        CategoriesId = 1,
                        Name = category.Name,
                        Quantity = category.Quantity,
                        Id = category.Id,
                        Price = category.Price,
                        CategoriesName = "BEVERAGES"
                    };
                    return product;
                }
            }
            if (categoriesId == 2)
            {
                var category = Mdb.Fish.FirstOrDefault(x => x.Id == Id);
                if (category != null)
                {
                    var product = new ProductViewModel()
                    {
                        CategoriesId = 2,
                        Name = category.Name,
                        Quantity = category.Quantity,
                        Id = category.Id,
                        Price = category.Price,
                        CategoriesName = "FISH"
                    };
                    return product;
                }
            }
            if (categoriesId == 3)
            {
                var category = Mdb.Meat.FirstOrDefault(x => x.Id == Id);
                if (category != null)
                {
                    var product = new ProductViewModel()
                    {
                        CategoriesId = 3,
                        Name = category.Name,
                        Quantity = category.Quantity,
                        Id = category.Id,
                        Price = category.Price,
                        CategoriesName = "MEAT"
                    };
                    return product;
                }
            }
            if (categoriesId == 4)
            {
                var category = Mdb.Vegetables.FirstOrDefault(x => x.Id == Id);
                if (category != null)
                {
                    var product = new ProductViewModel()
                    {
                        CategoriesId = 4,
                        Name = category.Name,
                        Quantity = category.Quantity,
                        Id = category.Id,
                        Price = category.Price,
                        CategoriesName = "VEGETABLES"
                    };
                    return product;
                }
            }
            return null!;
        }
        public async Task UpdateProductAsync(ProductViewModel model)
        {
            if (model.CategoriesId == 1)
            {
                var productToUpdate = new Beverages()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Id = model.Id,
                    Price = model.Price
                };
                Mdb.Beverages.Update(productToUpdate);
                await Mdb.SaveChangesAsync();
            }
            if (model.CategoriesId == 2)
            {
                var productToUpdate = new Fish()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Id = model.Id,
                    Price = model.Price
                };
                Mdb.Fish.Update(productToUpdate);
                await Mdb.SaveChangesAsync();
            }
            if (model.CategoriesId == 3)
            {
                var productToUpdate = new Meat()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Id = model.Id,
                    Price = model.Price
                };
                Mdb.Meat.Update(productToUpdate);
                await Mdb.SaveChangesAsync();
            }
            if (model.CategoriesId == 4)
            {
                var productToUpdate = new Vegetables()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Id = model.Id,
                    Price = model.Price
                };
                Mdb.Vegetables.Update(productToUpdate);
                await Mdb.SaveChangesAsync();
            }
















            //if (model.ProductType == "Fish")
            //{
            //    var result = new Fish() { Name = model.Name, Description = model.Description };
            //    await Rep.AddCategoryAsync(result);
            //    return RedirectToAction("Index", new { id = 2 });
            //}
            //if (model.ProductType == "Meat")
            //{
            //    var result = new Meat() { Name = model.Name, Description = model.Description };
            //    await Rep.AddCategoryAsync(result);
            //    return RedirectToAction("Index", new { id = 3 });
            //}
            //if (model.ProductType == "Vegetables")
            //{
            //    var result = new Vegetables() { Name = model.Name, Description = model.Description };
            //    await Rep.AddCategoryAsync(result);
            //    return RedirectToAction("Index", new { id = 4 });
            //}
            //return View(model);
        }

        public async Task<ProductViewModel> BuldingOrders(string Name, int count, double price)
        {
            var product = new ProductViewModel()
            {
                Name = Name,
                Count = count,
                Price = price
            };
            await Mdb.ClientsOrders.AddAsync(product);
            await Mdb.SaveChangesAsync();
          //  return await Mdb.Beverages.ToListAsync();
            return product;
        }
        public async Task ChangeQuantity(int categoriesid, int id, int count)
        {
            if (categoriesid == 1)
            {
                var product = await Mdb.Beverages.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    throw new InvalidOperationException("");
                }
                product.Quantity -= count;
                await Mdb.SaveChangesAsync();
            }
            if (categoriesid == 2)
            {
                var product = await Mdb.Fish.FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException("");
                product.Quantity -= count;
                await Mdb.SaveChangesAsync();
            }
            if (categoriesid == 3)
            {
                var product = await Mdb.Meat.FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException("");
                product.Quantity -= count;
                await Mdb.SaveChangesAsync();
            }
            if (categoriesid == 4)
            {
                var product = await Mdb.Vegetables.FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException("");
                product.Quantity -= count;
                await Mdb.SaveChangesAsync();
            }
        }
    }
}

