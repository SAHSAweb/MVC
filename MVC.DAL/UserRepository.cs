

using MVC.DAL.Entities.Interfaces;
using MVC.DAL.Entities;
using MVC.Model.Enams;

namespace MVC.DAL
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly MarketDbContext _dbContext;
        public UserRepository(MarketDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Add(User user)
        {
            bool exists = _dbContext.Users.Any(u => u.Name == user.Name || u.Email == user.Email);

            if (exists)
            {
                return false;  // "User with the same Name or Email already exists.";
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return true;//"User added successfully.";
        }

        public void Delete(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll(UserTypes user)
        {
            return _dbContext.Users;
        }

       

        public User GetById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(p => p.Id == id);
        }

       
    }
}
