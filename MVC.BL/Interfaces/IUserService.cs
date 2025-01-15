
using MVC.Model.Enams;

namespace MVC.BL.Interfaces
{
    public interface IUserService<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(UserTypes user);
        bool Add(T user);
        void Delete(Guid id);
    }
}