
using MVC.Model.Enams;

namespace MVC.BL.Interfaces
{
    public interface IUserService<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(UserTypes user);
        Task<bool> AddAsync(T user);
        Task DeleteAsync(Guid id);
    }
}