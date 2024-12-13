﻿namespace MVC.DAL
{

    public interface IRepository<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T user);
        void Delete(Guid id);
    }

}