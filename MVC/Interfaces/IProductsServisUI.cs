

namespace MVC.Interfaces
{
    public interface IProductsServisUI<T, K> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(K data);
        void Add(T data);
        void Delete(Guid id);
        void Update(T data);
    }
}