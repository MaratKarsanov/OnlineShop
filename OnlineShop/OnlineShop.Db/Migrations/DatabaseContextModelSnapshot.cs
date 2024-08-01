﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineShop.Db;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Comparison", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Comparisons");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.DeliveryData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeliveryData");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favourites", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8df0a3ec-b6b3-48b2-84bf-795f38580dab"),
                            ProductId = new Guid("31f5ca54-1493-4d25-bfa8-8365da02fe2a"),
                            Url = "/images/Products/ahmadTeaCeylonTea.png"
                        },
                        new
                        {
                            Id = new Guid("cd178c04-fefa-43b7-9729-e8c40a32aeff"),
                            ProductId = new Guid("a1eb9f0e-67ac-4abe-983d-58c61dbf98c6"),
                            Url = "/images/Products/ahmadTeaClassicGrey.png"
                        },
                        new
                        {
                            Id = new Guid("d83231a6-d222-4ad7-a585-fd4dc6cc4e3e"),
                            ProductId = new Guid("910d6065-27fc-4f7e-9a0a-be7882000163"),
                            Url = "/images/Products/ahmadTeaClassikBlackTea.png"
                        },
                        new
                        {
                            Id = new Guid("b54b3a14-3fbc-4469-89b4-382e2c88c00d"),
                            ProductId = new Guid("60254d66-6224-48cc-97c5-4334cf884b12"),
                            Url = "/images/Products/ahmadTeaEnglishBreakfast.png"
                        },
                        new
                        {
                            Id = new Guid("8c32a5fb-6709-40a4-8079-3bd8dc3e9c46"),
                            ProductId = new Guid("1afe4c81-b95e-41fe-bdce-8d723abf652e"),
                            Url = "/images/Products/ahmadTeaLondonAfternoon.png"
                        },
                        new
                        {
                            Id = new Guid("e976453b-3db1-4cd3-a13e-e0ea36240fb3"),
                            ProductId = new Guid("44a28a04-1e56-450e-a1c5-1d4737217d41"),
                            Url = "/images/Products/ahmadTeaPearStrudel.png"
                        },
                        new
                        {
                            Id = new Guid("b9dfb257-e642-44d8-8e8b-9bc0bad15163"),
                            ProductId = new Guid("20848550-ebfd-4915-8f3b-0fc179e298b2"),
                            Url = "/images/Products/ahmadTeaStrawberryMousse.png"
                        },
                        new
                        {
                            Id = new Guid("95d8bb84-adb9-45da-8944-46b9a4c1295b"),
                            ProductId = new Guid("262f905c-a15c-4665-a589-ad7be5efb0dc"),
                            Url = "/images/Products/azer.png"
                        },
                        new
                        {
                            Id = new Guid("c82d2c9a-409d-47e1-a7a3-b606e66dc312"),
                            ProductId = new Guid("0b48dd3b-8e8e-4d80-8779-c47b7ebaaca2"),
                            Url = "/images/Products/curtisIsabellaGrape.png"
                        },
                        new
                        {
                            Id = new Guid("8768b0ee-6439-4dd6-ac5a-a0796430543b"),
                            ProductId = new Guid("dfd70e45-d919-49f8-8be8-72e3c3b13c35"),
                            Url = "/images/Products/curtisSummerBerries.png"
                        },
                        new
                        {
                            Id = new Guid("044e37de-2943-4def-abbb-eb92c1425c17"),
                            ProductId = new Guid("df617e27-6f09-44d3-85a8-527d52e5686b"),
                            Url = "/images/Products/curtisSunnyLemon.png"
                        },
                        new
                        {
                            Id = new Guid("23b9f8c5-3643-437e-b0b4-fd77662fba29"),
                            ProductId = new Guid("a055cb47-f621-4c2d-bef4-33c41081e4b7"),
                            Url = "/images/Products/curtisWhiteBountea.png"
                        },
                        new
                        {
                            Id = new Guid("1dd2fc09-5594-42a1-adb9-d808db86b166"),
                            ProductId = new Guid("b237f4af-7618-4ce8-b2ea-997a397c994d"),
                            Url = "/images/Products/tessBerryBar.png"
                        },
                        new
                        {
                            Id = new Guid("82d69078-d813-4471-a595-8b946e0bcf07"),
                            ProductId = new Guid("4f80e6f7-7527-4a67-bd75-88b6aa5aa343"),
                            Url = "/images/Products/tessDark.png"
                        },
                        new
                        {
                            Id = new Guid("e1a4238b-e9a8-4921-aa22-2571b70cca47"),
                            ProductId = new Guid("09b6973a-c6ac-46a0-9ca8-474962f936e8"),
                            Url = "/images/Products/tessFlirt.png"
                        },
                        new
                        {
                            Id = new Guid("055179ce-228b-44e1-84e7-830ecfe1c2c3"),
                            ProductId = new Guid("138d1841-d46e-4b51-b6d6-2c9f337e7ae5"),
                            Url = "/images/Products/tessForestDream.png"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeliveryDataId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryDataId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ComparisonId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("FavouritesId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ComparisonId");

                    b.HasIndex("FavouritesId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("31f5ca54-1493-4d25-bfa8-8365da02fe2a"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Ahmad Tea Ceylon"
                        },
                        new
                        {
                            Id = new Guid("a1eb9f0e-67ac-4abe-983d-58c61dbf98c6"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Ahmad Tea Classic Grey"
                        },
                        new
                        {
                            Id = new Guid("910d6065-27fc-4f7e-9a0a-be7882000163"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Ahmad Tea Classic Black"
                        },
                        new
                        {
                            Id = new Guid("60254d66-6224-48cc-97c5-4334cf884b12"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Ahmad Tea English Breakfast"
                        },
                        new
                        {
                            Id = new Guid("1afe4c81-b95e-41fe-bdce-8d723abf652e"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Ahmad Tea London Afternoon"
                        },
                        new
                        {
                            Id = new Guid("44a28a04-1e56-450e-a1c5-1d4737217d41"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Ahmad Tea Pear Strudel"
                        },
                        new
                        {
                            Id = new Guid("20848550-ebfd-4915-8f3b-0fc179e298b2"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Ahmad Tea Strawberry Mousse"
                        },
                        new
                        {
                            Id = new Guid("262f905c-a15c-4665-a589-ad7be5efb0dc"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Azer Tea"
                        },
                        new
                        {
                            Id = new Guid("0b48dd3b-8e8e-4d80-8779-c47b7ebaaca2"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Curtis Isabella Grape"
                        },
                        new
                        {
                            Id = new Guid("dfd70e45-d919-49f8-8be8-72e3c3b13c35"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Curtis Summer Berries"
                        },
                        new
                        {
                            Id = new Guid("df617e27-6f09-44d3-85a8-527d52e5686b"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Curtis Sunny Lemon"
                        },
                        new
                        {
                            Id = new Guid("a055cb47-f621-4c2d-bef4-33c41081e4b7"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Curtis White Bountea"
                        },
                        new
                        {
                            Id = new Guid("b237f4af-7618-4ce8-b2ea-997a397c994d"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Tess Berry Bar"
                        },
                        new
                        {
                            Id = new Guid("4f80e6f7-7527-4a67-bd75-88b6aa5aa343"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Tess Dark"
                        },
                        new
                        {
                            Id = new Guid("09b6973a-c6ac-46a0-9ca8-474962f936e8"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Tess Flirt"
                        },
                        new
                        {
                            Id = new Guid("138d1841-d46e-4b51-b6d6-2c9f337e7ae5"),
                            Cost = 500m,
                            Description = "Очень вкусный и ароматный чай",
                            Name = "Tess Forest Dream"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfileImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineShop.Db.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineShop.Db.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineShop.Db.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.DeliveryData", "DeliveryData")
                        .WithMany()
                        .HasForeignKey("DeliveryDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryData");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Comparison", null)
                        .WithMany("Items")
                        .HasForeignKey("ComparisonId");

                    b.HasOne("OnlineShop.Db.Models.Favourites", null)
                        .WithMany("Items")
                        .HasForeignKey("FavouritesId");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Comparison", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favourites", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
