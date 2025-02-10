namespace MVC.Interfaces
{
    public interface IUsersServiseUI<T, K> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(K data);
        Task<bool> AddAsync(T data);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(T data);
    }
}
