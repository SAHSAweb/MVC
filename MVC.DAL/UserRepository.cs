using MVC.DAL.Entities;
using MVC.Model.Enams;
using MVC.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MVC.DAL
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly MarketDbContext _dbContext;
        public UserRepository(MarketDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddAsync(User user)
        {
            bool exists = await _dbContext.Users.AnyAsync(u => u.Name == user.Name || u.Email == user.Email);

            if (exists)
            {
                return false; 
            }

           await _dbContext.Users.AddAsync(user);
           await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
               await _dbContext.SaveChangesAsync();
            }
        }

        public async Task< IEnumerable<User>> GetAllAsync(UserTypes user)
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

       
    }
}
