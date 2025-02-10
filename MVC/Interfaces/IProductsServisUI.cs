

namespace MVC.Interfaces
{
    public interface IProductsServisUI<T, K> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(K data);
        Task AddAsync(T data);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(T data);
        Task UpdeteProductQuantityAsync(Guid productId, int amount);
    }
}