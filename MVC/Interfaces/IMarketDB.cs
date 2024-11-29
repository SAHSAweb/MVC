using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Interfaces
{
    public interface IMarketDB
    {
        public DbSet<Beverages> Beverages { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Meat> Meat { get; set; } 
        public DbSet<Vegetables> Vegetables { get; set; }
        public DbSet<ProductViewModel> ClientsOrders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
