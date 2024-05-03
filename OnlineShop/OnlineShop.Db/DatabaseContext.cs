using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Favourites> Favourites { get; set; }
        public DbSet<Comparison> Comparisons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var basicProducts = new List<Product>();
            for (var i = 0; i < 100; i++)
            {
                basicProducts.Add(new Product()
                {
                    Name = $"Name{i}",
                    Cost = i * 100,
                    Description = "Very good product!",
                });
            }
            modelBuilder.Entity<Product>().HasData(basicProducts);
        }
    }
}
