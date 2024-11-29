using Microsoft.EntityFrameworkCore;
using MVC.Interfaces;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Managers
{
    public class MarketDB : DbContext
    {
        public DbSet<Beverages> Beverages { get; set; } = null!;
        public DbSet<Fish> Fish { get; set; } = null!;
        public DbSet<Meat> Meat { get; set; } = null!;
        public DbSet<Vegetables> Vegetables { get; set; } = null!;
        public DbSet<ProductViewModel>ClientsOrders { get; set; } = null!;
        public MarketDB(DbContextOptions<MarketDB> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
