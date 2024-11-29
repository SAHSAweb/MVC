using Microsoft.EntityFrameworkCore;
using MVC.Interfaces;

namespace MVC.Managers
{
    
    
        //public interface IGenericRepository<T> where T : IProducts
        //{
        //    Task<IEnumerable<T>> GetAllAsync();
        //    Task<T> GetByIdAsync(int id);
        //    Task AddAsync(T entity);
        //    Task UpdateAsync(T entity);
        //    Task DeleteAsync(int id);
        //}

        //public class GenericRepository<T> : IGenericRepository<T> where T : IProducts
        //{
        //    private readonly DbContext _context;
        //   // private readonly DbSet<T> _dbSet;

        //    public GenericRepository(DbContext context)
        //    {
        //        _context = context;
        //      //  _dbSet = context.Set<T>();
        //    }

        //    public async Task<IEnumerable<T>> GetAllAsync()
        //    {
        //        return await _context.ToListAsync();
        //    }

        //    public async Task<T> GetByIdAsync(int id)
        //    {
        //        return await _dbSet.FindAsync(id);
        //    }

        //    public async Task AddAsync(T entity)
        //    {
        //        await _dbSet.AddAsync(entity);
        //        await _context.SaveChangesAsync();
        //    }

        //    public async Task UpdateAsync(T entity)
        //    {
        //        _dbSet.Update(entity);
        //        await _context.SaveChangesAsync();
        //    }

        //    public async Task DeleteAsync(int id)
        //    {
        //        var entity = await GetByIdAsync(id);
        //        if (entity != null)
        //        {
        //            _dbSet.Remove(entity);
        //            await _context.SaveChangesAsync();
        //        }
        //    }
        //}

    }

