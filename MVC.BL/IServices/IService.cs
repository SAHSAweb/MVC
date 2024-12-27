using MVC.DAL.Entities;
using MVC.Model;
using MVC.Model.Enams;

namespace MVC.BL.IServices
{ 
        public interface IService<T> where T : class
        {
            T GetById(Guid id);
            IEnumerable<T> GetAll(Products category);
            void Add(T data);
            void Delete(Guid id);
            void Update(ProductDto product);
        }    
}