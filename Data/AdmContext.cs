using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AdmContext : DbContext
    {

        public AdmContext(DbContextOptions<AdmContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseSnakeCaseNamingConvention();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(s => s.Step)
                .WithMany(p => p.Products)
                .HasForeignKey(e => e.StepId);

            modelBuilder.Entity<StockProduct>()
                .HasKey(t => new { t.StockId, t.ProductId });
            
            modelBuilder.Entity<StockWine>()
                .HasKey(t => new { t.StockId, t.WineId });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<StockProduct> StockProducts { get; set; }
        public DbSet<StockWine> StockWines { get; set; }
    }
}