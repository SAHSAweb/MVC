using Microsoft.EntityFrameworkCore;
using MVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL
{
    public class MarketDbContext :DbContext
    {
        private readonly DbContextOptions<MarketDbContext> options;

        public MarketDbContext(DbContextOptions<MarketDbContext> options)
        {
            this.options = options;
        }
        public DbSet<Product> Products { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
              entity.ToTable("Products");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);
                entity.Property(p => p.Price)
                .IsRequired()
             .HasColumnType("decimal(18,2)");
            });
        }
    }
}
