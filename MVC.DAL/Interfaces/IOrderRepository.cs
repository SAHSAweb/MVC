using MVC.DAL.Entities;
using MVC.Model.Enams;

namespace MVC.DAL.Interfaces
{
    public interface IOrderRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(Guid userId);
        Task AddAsync(T user);
        Task DeleteAsync(Guid id);
       
    }
}