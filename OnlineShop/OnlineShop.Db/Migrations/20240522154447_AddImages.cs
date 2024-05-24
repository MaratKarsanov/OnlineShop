using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13aca13d-22f7-41ff-ad29-77bc13da813a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13c00883-e3c7-4ee4-83c4-e43ab97e6f57"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1c99c083-39ab-4115-94ab-c89a49ba6382"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2baee684-8e22-4cd1-8f17-60c81082716a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ebd2235-6413-4ce3-a8fe-11e1c27e607e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5e701a10-0638-434f-bcd0-dffe27988d7f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6bdf217c-d72a-480c-bb97-1cde95028db4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74a7787d-6c06-40c0-8571-682c914f662b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a6a5859-542a-4186-aea6-7f86cac19e54"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ee912ff-020b-415f-9e1a-38b66c651f3e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c1dfc863-e553-4e3c-afaf-e83bf714affb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e38dea82-a635-446c-bef7-f88891e7ad30"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eda18f5f-3762-4dfc-aa8b-6e56600e5c0a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f30fdd14-d6e8-46cb-a5cd-8767f13449c2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6d0a154-e167-4bab-8f1a-26055f2d5cfd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffa4fc54-34a2-47b8-8b5b-008a0247921b"));

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsInComparison",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsInFavourites",
                table: "Products");

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
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09b6973a-c6ac-46a0-9ca8-474962f936e8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b48dd3b-8e8e-4d80-8779-c47b7ebaaca2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("138d1841-d46e-4b51-b6d6-2c9f337e7ae5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1afe4c81-b95e-41fe-bdce-8d723abf652e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("20848550-ebfd-4915-8f3b-0fc179e298b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("262f905c-a15c-4665-a589-ad7be5efb0dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("31f5ca54-1493-4d25-bfa8-8365da02fe2a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44a28a04-1e56-450e-a1c5-1d4737217d41"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4f80e6f7-7527-4a67-bd75-88b6aa5aa343"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60254d66-6224-48cc-97c5-4334cf884b12"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("910d6065-27fc-4f7e-9a0a-be7882000163"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a055cb47-f621-4c2d-bef4-33c41081e4b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1eb9f0e-67ac-4abe-983d-58c61dbf98c6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b237f4af-7618-4ce8-b2ea-997a397c994d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df617e27-6f09-44d3-85a8-527d52e5686b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dfd70e45-d919-49f8-8be8-72e3c3b13c35"));

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInComparison",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInFavourites",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavouritesId", "ImageLink", "IsInComparison", "IsInFavourites", "Name" },
                values: new object[,]
                {
                    { new Guid("13aca13d-22f7-41ff-ad29-77bc13da813a"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaLondonAfternoon.png", false, false, "Ahmad Tea London Afternoon" },
                    { new Guid("13c00883-e3c7-4ee4-83c4-e43ab97e6f57"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaCeylonTea.png", false, false, "Ahmad Tea Ceylon" },
                    { new Guid("1c99c083-39ab-4115-94ab-c89a49ba6382"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaClassikBlackTea.png", false, false, "Ahmad Tea Classic Black" },
                    { new Guid("2baee684-8e22-4cd1-8f17-60c81082716a"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaEnglishBreakfast.png", false, false, "Ahmad Tea English Breakfast" },
                    { new Guid("4ebd2235-6413-4ce3-a8fe-11e1c27e607e"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/tessForestDream.png", false, false, "Tess Forest Dream" },
                    { new Guid("5e701a10-0638-434f-bcd0-dffe27988d7f"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/curtisIsabellaGrape.png", false, false, "Curtis Isabella Grape" },
                    { new Guid("6bdf217c-d72a-480c-bb97-1cde95028db4"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/tessBerryBar.png", false, false, "Tess Berry Bar" },
                    { new Guid("74a7787d-6c06-40c0-8571-682c914f662b"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/curtisSummerBerries.png", false, false, "Curtis Summer Berries" },
                    { new Guid("8a6a5859-542a-4186-aea6-7f86cac19e54"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/tessFlirt.png", false, false, "Tess Flirt" },
                    { new Guid("8ee912ff-020b-415f-9e1a-38b66c651f3e"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/azer.png", false, false, "Azer Tea" },
                    { new Guid("c1dfc863-e553-4e3c-afaf-e83bf714affb"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/curtisWhiteBountea.png", false, false, "Curtis White Bountea" },
                    { new Guid("e38dea82-a635-446c-bef7-f88891e7ad30"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/curtisSunnyLemon.png", false, false, "Curtis Sunny Lemon" },
                    { new Guid("eda18f5f-3762-4dfc-aa8b-6e56600e5c0a"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/tessDark.png", false, false, "Tess Dark" },
                    { new Guid("f30fdd14-d6e8-46cb-a5cd-8767f13449c2"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaStrawberryMousse.png", false, false, "Ahmad Tea Strawberry Mousse" },
                    { new Guid("f6d0a154-e167-4bab-8f1a-26055f2d5cfd"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaClassicGrey.png", false, false, "Ahmad Tea Classic Grey" },
                    { new Guid("ffa4fc54-34a2-47b8-8b5b-008a0247921b"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaPearStrudel.png", false, false, "Ahmad Tea Pear Strudel" }
                });
        }
    }
}
