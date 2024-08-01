using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Favourites> Favourites { get; set; }
        public DbSet<Comparison> Comparisons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(t => t.Items)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(ci => ci.OrderId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            var product1Id = Guid.Parse("31f5ca54-1493-4d25-bfa8-8365da02fe2a");
            var product2Id = Guid.Parse("a1eb9f0e-67ac-4abe-983d-58c61dbf98c6");
            var product3Id = Guid.Parse("910d6065-27fc-4f7e-9a0a-be7882000163");
            var product4Id = Guid.Parse("60254d66-6224-48cc-97c5-4334cf884b12");
            var product5Id = Guid.Parse("1afe4c81-b95e-41fe-bdce-8d723abf652e");
            var product6Id = Guid.Parse("44a28a04-1e56-450e-a1c5-1d4737217d41");
            var product7Id = Guid.Parse("20848550-ebfd-4915-8f3b-0fc179e298b2");
            var product8Id = Guid.Parse("262f905c-a15c-4665-a589-ad7be5efb0dc");
            var product9Id = Guid.Parse("0b48dd3b-8e8e-4d80-8779-c47b7ebaaca2");
            var product10Id = Guid.Parse("dfd70e45-d919-49f8-8be8-72e3c3b13c35");
            var product11Id = Guid.Parse("df617e27-6f09-44d3-85a8-527d52e5686b");
            var product12Id = Guid.Parse("a055cb47-f621-4c2d-bef4-33c41081e4b7");
            var product13Id = Guid.Parse("b237f4af-7618-4ce8-b2ea-997a397c994d");
            var product14Id = Guid.Parse("4f80e6f7-7527-4a67-bd75-88b6aa5aa343");
            var product15Id = Guid.Parse("09b6973a-c6ac-46a0-9ca8-474962f936e8");
            var product16Id = Guid.Parse("138d1841-d46e-4b51-b6d6-2c9f337e7ae5");

            var basicProductsImages = new List<Image>()
            {
                new Image()
                {
                    Id = Guid.Parse("8df0a3ec-b6b3-48b2-84bf-795f38580dab"),
                    Url = "/images/Products/ahmadTeaCeylonTea.png",
                    ProductId = product1Id
                },
                new Image()
                {
                    Id = Guid.Parse("cd178c04-fefa-43b7-9729-e8c40a32aeff"),
                    Url = "/images/Products/ahmadTeaClassicGrey.png",
                    ProductId = product2Id
                },
                new Image()
                {
                    Id = Guid.Parse("d83231a6-d222-4ad7-a585-fd4dc6cc4e3e"),
                    Url = "/images/Products/ahmadTeaClassikBlackTea.png",
                    ProductId = product3Id
                },
                 new Image()
                {
                    Id = Guid.Parse("b54b3a14-3fbc-4469-89b4-382e2c88c00d"),
                    Url = "/images/Products/ahmadTeaEnglishBreakfast.png",
                    ProductId = product4Id
                },
                new Image()
                {
                    Id = Guid.Parse("8c32a5fb-6709-40a4-8079-3bd8dc3e9c46"),
                    Url = "/images/Products/ahmadTeaLondonAfternoon.png",
                    ProductId = product5Id
                },
                 new Image()
                {
                    Id = Guid.Parse("e976453b-3db1-4cd3-a13e-e0ea36240fb3"),
                    Url = "/images/Products/ahmadTeaPearStrudel.png",
                    ProductId = product6Id
                },
                new Image()
                {
                    Id = Guid.Parse("b9dfb257-e642-44d8-8e8b-9bc0bad15163"),
                    Url = "/images/Products/ahmadTeaStrawberryMousse.png",
                    ProductId = product7Id
                },
                new Image()
                {
                    Id = Guid.Parse("95d8bb84-adb9-45da-8944-46b9a4c1295b"),
                    Url = "/images/Products/azer.png",
                    ProductId = product8Id
                },
                new Image()
                {
                    Id = Guid.Parse("c82d2c9a-409d-47e1-a7a3-b606e66dc312"),
                    Url = "/images/Products/curtisIsabellaGrape.png",
                    ProductId = product9Id
                },
                new Image()
                {
                    Id = Guid.Parse("8768b0ee-6439-4dd6-ac5a-a0796430543b"),
                    Url = "/images/Products/curtisSummerBerries.png",
                    ProductId = product10Id
                },
                new Image()
                {
                    Id = Guid.Parse("044e37de-2943-4def-abbb-eb92c1425c17"),
                    Url = "/images/Products/curtisSunnyLemon.png",
                    ProductId = product11Id
                },
                new Image()
                {
                    Id = Guid.Parse("23b9f8c5-3643-437e-b0b4-fd77662fba29"),
                    Url = "/images/Products/curtisWhiteBountea.png",
                    ProductId = product12Id
                },
                 new Image()
                {
                    Id = Guid.Parse("1dd2fc09-5594-42a1-adb9-d808db86b166"),
                    Url = "/images/Products/tessBerryBar.png",
                    ProductId = product13Id
                },
                new Image()
                {
                    Id = Guid.Parse("82d69078-d813-4471-a595-8b946e0bcf07"),
                    Url = "/images/Products/tessDark.png",
                    ProductId = product14Id
                },
                 new Image()
                {
                    Id = Guid.Parse("e1a4238b-e9a8-4921-aa22-2571b70cca47"),
                    Url = "/images/Products/tessFlirt.png",
                    ProductId = product15Id
                },
                new Image()
                {
                    Id = Guid.Parse("055179ce-228b-44e1-84e7-830ecfe1c2c3"),
                    Url = "/images/Products/tessForestDream.png",
                    ProductId = product16Id
                }
            };
            modelBuilder.Entity<Image>().HasData(basicProductsImages);

            var basicProducts = new List<Product>()
            {
                new Product()
                {
                    Id = product1Id,
                    Name = $"Ahmad Tea Ceylon",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product2Id,
                    Name = $"Ahmad Tea Classic Grey",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product3Id,
                    Name = $"Ahmad Tea Classic Black",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product4Id,
                    Name = $"Ahmad Tea English Breakfast",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product5Id,
                    Name = $"Ahmad Tea London Afternoon",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product6Id,
                    Name = $"Ahmad Tea Pear Strudel",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product7Id,
                    Name = $"Ahmad Tea Strawberry Mousse",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product8Id,
                    Name = $"Azer Tea",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product9Id,
                    Name = $"Curtis Isabella Grape",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product10Id,
                    Name = $"Curtis Summer Berries",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product11Id,
                    Name = $"Curtis Sunny Lemon",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product12Id,
                    Name = $"Curtis White Bountea",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product13Id,
                    Name = $"Tess Berry Bar",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product14Id,
                    Name = $"Tess Dark",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product15Id,
                    Name = $"Tess Flirt",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                },
                new Product()
                {
                    Id = product16Id,
                    Name = $"Tess Forest Dream",
                    Cost = 500,
                    Description = "Очень вкусный и ароматный чай"
                }
            };
            modelBuilder.Entity<Product>().HasData(basicProducts);
        }
    }
}
