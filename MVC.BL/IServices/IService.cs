using MVC.DAL.Entities;
using MVC.Model;

namespace MVC.BL.IServices
{ 
        public interface IService<T> where T : class
        {
            T GetById(Guid id);
            IEnumerable<T> GetAll();
            void Add(T data);
            void Delete(Guid id);
            void Update(ProductDto product);
        }    
}