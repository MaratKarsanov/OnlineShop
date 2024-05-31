using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comparisons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comparisons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryData_DeliveryDataId",
                        column: x => x.DeliveryDataId,
                        principalTable: "DeliveryData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComparisonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FavouritesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Comparisons_ComparisonId",
                        column: x => x.ComparisonId,
                        principalTable: "Comparisons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Favourites_FavouritesId",
                        column: x => x.FavouritesId,
                        principalTable: "Favourites",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavouritesId", "Name" },
                values: new object[,]
                {
                    { new Guid("09b6973a-c6ac-46a0-9ca8-474962f936e8"), null, 500m, "Очень вкусный и ароматный чай", null, "Tess Flirt" },
                    { new Guid("0b48dd3b-8e8e-4d80-8779-c47b7ebaaca2"), null, 500m, "Очень вкусный и ароматный чай", null, "Curtis Isabella Grape" },
                    { new Guid("138d1841-d46e-4b51-b6d6-2c9f337e7ae5"), null, 500m, "Очень вкусный и ароматный чай", null, "Tess Forest Dream" },
                    { new Guid("1afe4c81-b95e-41fe-bdce-8d723abf652e"), null, 500m, "Очень вкусный и ароматный чай", null, "Ahmad Tea London Afternoon" },
                    { new Guid("20848550-ebfd-4915-8f3b-0fc179e298b2"), null, 500m, "Очень вкусный и ароматный чай", null, "Ahmad Tea Strawberry Mousse" },
                    { new Guid("262f905c-a15c-4665-a589-ad7be5efb0dc"), null, 500m, "Очень вкусный и ароматный чай", null, "Azer Tea" },
                    { new Guid("31f5ca54-1493-4d25-bfa8-8365da02fe2a"), null, 500m, "Очень вкусный и ароматный чай", null, "Ahmad Tea Ceylon" },
                    { new Guid("44a28a04-1e56-450e-a1c5-1d4737217d41"), null, 500m, "Очень вкусный и ароматный чай", null, "Ahmad Tea Pear Strudel" },
                    { new Guid("4f80e6f7-7527-4a67-bd75-88b6aa5aa343"), null, 500m, "Очень вкусный и ароматный чай", null, "Tess Dark" },
                    { new Guid("60254d66-6224-48cc-97c5-4334cf884b12"), null, 500m, "Очень вкусный и ароматный чай", null, "Ahmad Tea English Breakfast" },
                    { new Guid("910d6065-27fc-4f7e-9a0a-be7882000163"), null, 500m, "Очень вкусный и ароматный чай", null, "Ahmad Tea Classic Black" },
                    { new Guid("a055cb47-f621-4c2d-bef4-33c41081e4b7"), null, 500m, "Очень вкусный и ароматный чай", null, "Curtis White Bountea" },
                    { new Guid("a1eb9f0e-67ac-4abe-983d-58c61dbf98c6"), null, 500m, "Очень вкусный и ароматный чай", null, "Ahmad Tea Classic Grey" },
                    { new Guid("b237f4af-7618-4ce8-b2ea-997a397c994d"), null, 500m, "Очень вкусный и ароматный чай", null, "Tess Berry Bar" },
                    { new Guid("df617e27-6f09-44d3-85a8-527d52e5686b"), null, 500m, "Очень вкусный и ароматный чай", null, "Curtis Sunny Lemon" },
                    { new Guid("dfd70e45-d919-49f8-8be8-72e3c3b13c35"), null, 500m, "Очень вкусный и ароматный чай", null, "Curtis Summer Berries" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("044e37de-2943-4def-abbb-eb92c1425c17"), new Guid("df617e27-6f09-44d3-85a8-527d52e5686b"), "/images/Products/curtisSunnyLemon.png" },
                    { new Guid("055179ce-228b-44e1-84e7-830ecfe1c2c3"), new Guid("138d1841-d46e-4b51-b6d6-2c9f337e7ae5"), "/images/Products/tessForestDream.png" },
                    { new Guid("1dd2fc09-5594-42a1-adb9-d808db86b166"), new Guid("b237f4af-7618-4ce8-b2ea-997a397c994d"), "/images/Products/tessBerryBar.png" },
                    { new Guid("23b9f8c5-3643-437e-b0b4-fd77662fba29"), new Guid("a055cb47-f621-4c2d-bef4-33c41081e4b7"), "/images/Products/curtisWhiteBountea.png" },
                    { new Guid("82d69078-d813-4471-a595-8b946e0bcf07"), new Guid("4f80e6f7-7527-4a67-bd75-88b6aa5aa343"), "/images/Products/tessDark.png" },
                    { new Guid("8768b0ee-6439-4dd6-ac5a-a0796430543b"), new Guid("dfd70e45-d919-49f8-8be8-72e3c3b13c35"), "/images/Products/curtisSummerBerries.png" },
                    { new Guid("8c32a5fb-6709-40a4-8079-3bd8dc3e9c46"), new Guid("1afe4c81-b95e-41fe-bdce-8d723abf652e"), "/images/Products/ahmadTeaLondonAfternoon.png" },
                    { new Guid("8df0a3ec-b6b3-48b2-84bf-795f38580dab"), new Guid("31f5ca54-1493-4d25-bfa8-8365da02fe2a"), "/images/Products/ahmadTeaCeylonTea.png" },
                    { new Guid("95d8bb84-adb9-45da-8944-46b9a4c1295b"), new Guid("262f905c-a15c-4665-a589-ad7be5efb0dc"), "/images/Products/azer.png" },
                    { new Guid("b54b3a14-3fbc-4469-89b4-382e2c88c00d"), new Guid("60254d66-6224-48cc-97c5-4334cf884b12"), "/images/Products/ahmadTeaEnglishBreakfast.png" },
                    { new Guid("b9dfb257-e642-44d8-8e8b-9bc0bad15163"), new Guid("20848550-ebfd-4915-8f3b-0fc179e298b2"), "/images/Products/ahmadTeaStrawberryMousse.png" },
                    { new Guid("c82d2c9a-409d-47e1-a7a3-b606e66dc312"), new Guid("0b48dd3b-8e8e-4d80-8779-c47b7ebaaca2"), "/images/Products/curtisIsabellaGrape.png" },
                    { new Guid("cd178c04-fefa-43b7-9729-e8c40a32aeff"), new Guid("a1eb9f0e-67ac-4abe-983d-58c61dbf98c6"), "/images/Products/ahmadTeaClassicGrey.png" },
                    { new Guid("d83231a6-d222-4ad7-a585-fd4dc6cc4e3e"), new Guid("910d6065-27fc-4f7e-9a0a-be7882000163"), "/images/Products/ahmadTeaClassikBlackTea.png" },
                    { new Guid("e1a4238b-e9a8-4921-aa22-2571b70cca47"), new Guid("09b6973a-c6ac-46a0-9ca8-474962f936e8"), "/images/Products/tessFlirt.png" },
                    { new Guid("e976453b-3db1-4cd3-a13e-e0ea36240fb3"), new Guid("44a28a04-1e56-450e-a1c5-1d4737217d41"), "/images/Products/ahmadTeaPearStrudel.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_OrderId",
                table: "CartItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryDataId",
                table: "Orders",
                column: "DeliveryDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ComparisonId",
                table: "Products",
                column: "ComparisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavouritesId",
                table: "Products",
                column: "FavouritesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "DeliveryData");

            migrationBuilder.DropTable(
                name: "Comparisons");

            migrationBuilder.DropTable(
                name: "Favourites");
        }
    }
}
