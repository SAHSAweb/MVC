using MVC.Models;
using MVC.ViewModels;
using System.Security.Cryptography;

namespace MVC.Interfaces
{
    public interface IRepository
    {
        public Task<IEnumerable<IProducts>> GetAsync(int id);
        public ProductViewModel? AddProduct(int id);
        public Task AddCategoryAsync(ProductViewModel model);
        public Task DeleteCategoryAsync(int Id, int categoriesId);
        public ProductViewModel CreateModel(int Id, int categoriesId);
        public Task UpdateProductAsync(ProductViewModel model);
        public Task<ProductViewModel> BuldingOrders(string Name, int count, double price);
        public Task ChangeQuantity(int categoriesid, int id, int count);       
    }
}
