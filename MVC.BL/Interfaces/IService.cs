using MVC.DAL.Entities;
using MVC.Model;
using MVC.Model.Enams;

namespace MVC.BL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task< IEnumerable<T>> GetAllAsync(Products category);
        Task AddAsync(T data);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(ProductDto product);
        Task UpdeteProductQuantityAsync(Guid productId, int amount);
    }
}