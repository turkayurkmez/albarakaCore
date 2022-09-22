using catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace catalog.DataAccess.Data
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluently configuration
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(150);

            //modelBuilder.Entity<Product>().HasOne(p => p.Category)
            //                              .WithMany(p => p.Products)



            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Elektronik" }, new Category { Id = 2, Name = "Giyim" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "DELL XPS 15", Price = 100, StockCount = 100, CategoryId = 1 }, new Product { Id = 2, Name = "Kazak", Price = 100, StockCount = 100, CategoryId = 2 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
