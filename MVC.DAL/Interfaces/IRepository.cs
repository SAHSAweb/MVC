using MVC.DAL.Entities;
using MVC.Model.Enams;

namespace MVC.DAL.Interfaces
{

    public interface IRepository<T> where T : class
    {
       Task<T> GetByIdAsync(Guid id);
       Task<IEnumerable<T>> GetAllAsync(Products category);
        Task AddAsync(T user);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Product product);
    }

}