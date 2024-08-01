using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class Postgre3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Comparisons_ComparisonId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Favourites_FavouritesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ComparisonId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FavouritesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComparisonId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FavouritesId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ComparisonProduct",
                columns: table => new
                {
                    ComparisonsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComparisonProduct", x => new { x.ComparisonsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ComparisonProduct_Comparisons_ComparisonsId",
                        column: x => x.ComparisonsId,
                        principalTable: "Comparisons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComparisonProduct_Products_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouritesProduct",
                columns: table => new
                {
                    FavouritesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritesProduct", x => new { x.FavouritesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_FavouritesProduct_Favourites_FavouritesId",
                        column: x => x.FavouritesId,
                        principalTable: "Favourites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouritesProduct_Products_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComparisonProduct_ItemsId",
                table: "ComparisonProduct",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritesProduct_ItemsId",
                table: "FavouritesProduct",
                column: "ItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComparisonProduct");

            migrationBuilder.DropTable(
                name: "FavouritesProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "ComparisonId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavouritesId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09b6973a-c6ac-46a0-9ca8-474962f936e8"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b48dd3b-8e8e-4d80-8779-c47b7ebaaca2"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("138d1841-d46e-4b51-b6d6-2c9f337e7ae5"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1afe4c81-b95e-41fe-bdce-8d723abf652e"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("20848550-ebfd-4915-8f3b-0fc179e298b2"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("262f905c-a15c-4665-a589-ad7be5efb0dc"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("31f5ca54-1493-4d25-bfa8-8365da02fe2a"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44a28a04-1e56-450e-a1c5-1d4737217d41"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4f80e6f7-7527-4a67-bd75-88b6aa5aa343"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60254d66-6224-48cc-97c5-4334cf884b12"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("910d6065-27fc-4f7e-9a0a-be7882000163"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a055cb47-f621-4c2d-bef4-33c41081e4b7"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1eb9f0e-67ac-4abe-983d-58c61dbf98c6"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b237f4af-7618-4ce8-b2ea-997a397c994d"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df617e27-6f09-44d3-85a8-527d52e5686b"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dfd70e45-d919-49f8-8be8-72e3c3b13c35"),
                columns: new[] { "ComparisonId", "FavouritesId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ComparisonId",
                table: "Products",
                column: "ComparisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavouritesId",
                table: "Products",
                column: "FavouritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Comparisons_ComparisonId",
                table: "Products",
                column: "ComparisonId",
                principalTable: "Comparisons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Favourites_FavouritesId",
                table: "Products",
                column: "FavouritesId",
                principalTable: "Favourites",
                principalColumn: "Id");
        }
    }
}
