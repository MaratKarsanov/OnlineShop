﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Review.Domain;

#nullable disable

namespace Review.Domain.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Review.Domain.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Review.Domain.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("31f5ca54-1493-4d25-bfa8-8365da02fe2a"),
                            CreationDate = new DateTime(2024, 5, 8, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6280),
                            Grade = 2,
                            ProductId = new Guid("e45800e0-6b23-462a-bd61-1f1124794368"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consecte",
                            UserId = new Guid("92e9d625-11af-4cfa-95d1-a1b4a902a04b")
                        },
                        new
                        {
                            Id = new Guid("a1eb9f0e-67ac-4abe-983d-58c61dbf98c6"),
                            CreationDate = new DateTime(2024, 4, 28, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6352),
                            Grade = 3,
                            ProductId = new Guid("942d961c-0d8a-4212-adbb-f30907db45a7"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisi",
                            UserId = new Guid("a17d9e04-ee41-4e32-ab75-e5f9db3bf9a7")
                        },
                        new
                        {
                            Id = new Guid("910d6065-27fc-4f7e-9a0a-be7882000163"),
                            CreationDate = new DateTime(2024, 6, 13, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6355),
                            Grade = 1,
                            ProductId = new Guid("412c0e6a-0d6c-4456-8166-02735c2091e7"),
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,",
                            UserId = new Guid("6c66930e-5cc2-4c64-a47b-58cb974f637f")
                        },
                        new
                        {
                            Id = new Guid("60254d66-6224-48cc-97c5-4334cf884b12"),
                            CreationDate = new DateTime(2024, 5, 12, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6373),
                            Grade = 1,
                            ProductId = new Guid("ff73c057-50c1-48c1-98d6-e8c4b0559751"),
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectet",
                            UserId = new Guid("69366f47-e218-4ad3-ab51-5f954b65bba1")
                        },
                        new
                        {
                            Id = new Guid("1afe4c81-b95e-41fe-bdce-8d723abf652e"),
                            CreationDate = new DateTime(2024, 5, 22, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6376),
                            Grade = 0,
                            ProductId = new Guid("63a914fe-fe55-4e6f-966f-8a02b56fe6d0"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisici",
                            UserId = new Guid("37333403-1c88-4071-a3dc-fc5538ee2dc4")
                        },
                        new
                        {
                            Id = new Guid("44a28a04-1e56-450e-a1c5-1d4737217d41"),
                            CreationDate = new DateTime(2024, 5, 8, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6379),
                            Grade = 5,
                            ProductId = new Guid("48dc3e9c-d573-4da5-9356-2be2f014e03a"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut",
                            UserId = new Guid("ec10883e-db00-4835-a2c8-6b362210a8fa")
                        },
                        new
                        {
                            Id = new Guid("20848550-ebfd-4915-8f3b-0fc179e298b2"),
                            CreationDate = new DateTime(2024, 6, 12, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6382),
                            Grade = 5,
                            ProductId = new Guid("a1b72f35-f5fa-4915-8f22-f313d97e226e"),
                            Status = 1,
                            Text = "Lorem ipsum dolor si",
                            UserId = new Guid("5d53c573-43cd-4830-af11-d8b2dc35efa1")
                        },
                        new
                        {
                            Id = new Guid("262f905c-a15c-4665-a589-ad7be5efb0dc"),
                            CreationDate = new DateTime(2024, 3, 24, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6387),
                            Grade = 4,
                            ProductId = new Guid("84870da4-099f-43ad-9ecc-91474d23aac5"),
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temp",
                            UserId = new Guid("437c7ddf-85ad-44a7-b634-6eb1acb35bc1")
                        },
                        new
                        {
                            Id = new Guid("0b48dd3b-8e8e-4d80-8779-c47b7ebaaca2"),
                            CreationDate = new DateTime(2024, 4, 6, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6398),
                            Grade = 5,
                            ProductId = new Guid("dd852474-98f3-422f-aedd-2a7c07bbb4f2"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod t",
                            UserId = new Guid("70ba532b-3c58-43a3-a486-f9c29e030424")
                        },
                        new
                        {
                            Id = new Guid("dfd70e45-d919-49f8-8be8-72e3c3b13c35"),
                            CreationDate = new DateTime(2024, 5, 31, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6401),
                            Grade = 3,
                            ProductId = new Guid("6b907281-1f10-4652-936e-7e80a1b9fc93"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt",
                            UserId = new Guid("98175bac-3740-41f1-a9e4-bb6c996f0834")
                        },
                        new
                        {
                            Id = new Guid("df617e27-6f09-44d3-85a8-527d52e5686b"),
                            CreationDate = new DateTime(2024, 3, 25, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6404),
                            Grade = 2,
                            ProductId = new Guid("159cf9ae-f719-48b0-98b3-795a83248388"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,",
                            UserId = new Guid("1a4675bc-68f3-42f4-b9c3-7347eba26bf6")
                        },
                        new
                        {
                            Id = new Guid("a055cb47-f621-4c2d-bef4-33c41081e4b7"),
                            CreationDate = new DateTime(2024, 4, 14, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6410),
                            Grade = 1,
                            ProductId = new Guid("5da677a5-3d0e-4cb7-8dad-a3411af00f22"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, conse",
                            UserId = new Guid("0dc3892f-da30-42f3-bca8-5f36ec94055d")
                        },
                        new
                        {
                            Id = new Guid("b237f4af-7618-4ce8-b2ea-997a397c994d"),
                            CreationDate = new DateTime(2024, 6, 4, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6414),
                            Grade = 3,
                            ProductId = new Guid("87be3e9e-6fce-4b49-844f-a87e360a0c93"),
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicin",
                            UserId = new Guid("2e505e5a-07ce-4b03-99d7-a425fa9b0a94")
                        },
                        new
                        {
                            Id = new Guid("4f80e6f7-7527-4a67-bd75-88b6aa5aa343"),
                            CreationDate = new DateTime(2024, 5, 22, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6424),
                            Grade = 5,
                            ProductId = new Guid("7753ae40-1963-427c-b093-ca65dc7a3d82"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adip",
                            UserId = new Guid("869a5076-a6db-49c1-bea8-92da66cbcc8c")
                        },
                        new
                        {
                            Id = new Guid("09b6973a-c6ac-46a0-9ca8-474962f936e8"),
                            CreationDate = new DateTime(2024, 4, 23, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6427),
                            Grade = 1,
                            ProductId = new Guid("af335f5f-77c9-459d-82c8-81e5e41d9b31"),
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ",
                            UserId = new Guid("7fac4523-bb0f-40fd-8519-00dd7d4d11e3")
                        },
                        new
                        {
                            Id = new Guid("138d1841-d46e-4b51-b6d6-2c9f337e7ae5"),
                            CreationDate = new DateTime(2024, 5, 6, 16, 54, 30, 472, DateTimeKind.Local).AddTicks(6432),
                            Grade = 3,
                            ProductId = new Guid("98762668-a1c7-4f6f-a99c-e1071123fe5f"),
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur ad",
                            UserId = new Guid("624a6b3b-5ce8-4a1b-9402-3563054d0007")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
