﻿
using MVC.Model.Enams;
using MVC.ViewModels;

namespace MVC.Interfaces
{  
        public interface IUiService<T> where T : class
        {
            T GetById(Guid id);
            IEnumerable<T> GetAll(Products category);
            void Add(T data);
            void Delete(Guid id);
            void Update(ProductViewModel product);
        }
}