using MVC.Model.Enams;

namespace MVC.DAL.Entities.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(UserTypes user);
        bool Add(T user);
        void Delete(Guid id);
    }
}