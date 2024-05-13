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
            var basicProducts = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Ahmad Tea Ceylon",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/ahmadTeaCeylonTea.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Ahmad Tea Classic Grey",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/ahmadTeaClassicGrey.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Ahmad Tea Classic Black",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/ahmadTeaClassikBlackTea.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Ahmad Tea English Breakfast",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/ahmadTeaEnglishBreakfast.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Ahmad Tea London Afternoon",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/ahmadTeaLondonAfternoon.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Ahmad Tea Pear Strudel",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/ahmadTeaPearStrudel.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Ahmad Tea Strawberry Mousse",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/ahmadTeaStrawberryMousse.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Azer Tea",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/azer.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Curtis Isabella Grape",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/curtisIsabellaGrape.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Curtis Summer Berries",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/curtisSummerBerries.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Curtis Sunny Lemon",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/curtisSunnyLemon.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Curtis White Bountea",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/curtisWhiteBountea.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Tess Berry Bar",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/tessBerryBar.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Tess Dark",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/tessDark.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Tess Flirt",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/tessFlirt.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Tess Forest Dream",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай",
                    ImageLink = "/images/teas/tessForestDream.png"
                }
            };
            var basicRoles = new List<Role>()
            {
                new Role(){ Name = "Administrator" },
                new Role(){ Name = "User" }
            };
            var basicUsers = new List<User>()
            {
                new User()
                {
                    UserName = "karsanov@mail.ru",
                    PasswordHash = "marmar".GetHashCode().ToString(),
                    Name = "Marat",
                    Surname = "Karsanov",
                    Address = "Vatutina 37",
                    PhoneNumber = "89187080533",
                    RoleName = "Administrator"
                }
            };
            modelBuilder.Entity<Product>().HasData(basicProducts);
            modelBuilder.Entity<Role>().HasData(basicRoles);
            modelBuilder.Entity<User>().HasData(basicUsers);
        }
    }
}
