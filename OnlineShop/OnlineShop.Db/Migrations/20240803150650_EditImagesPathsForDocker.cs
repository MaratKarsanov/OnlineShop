using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class EditImagesPathsForDocker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("044e37de-2943-4def-abbb-eb92c1425c17"),
                column: "Url",
                value: "/app/wwwroot/images/Products/curtisSunnyLemon.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("055179ce-228b-44e1-84e7-830ecfe1c2c3"),
                column: "Url",
                value: "/app/wwwroot/images/Products/tessForestDream.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1dd2fc09-5594-42a1-adb9-d808db86b166"),
                column: "Url",
                value: "/app/wwwroot/images/Products/tessBerryBar.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("23b9f8c5-3643-437e-b0b4-fd77662fba29"),
                column: "Url",
                value: "/app/wwwroot/images/Products/curtisWhiteBountea.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("82d69078-d813-4471-a595-8b946e0bcf07"),
                column: "Url",
                value: "/app/wwwroot/images/Products/tessDark.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8768b0ee-6439-4dd6-ac5a-a0796430543b"),
                column: "Url",
                value: "/app/wwwroot/images/Products/curtisSummerBerries.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8c32a5fb-6709-40a4-8079-3bd8dc3e9c46"),
                column: "Url",
                value: "/app/wwwroot/images/Products/ahmadTeaLondonAfternoon.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8df0a3ec-b6b3-48b2-84bf-795f38580dab"),
                column: "Url",
                value: "/app/wwwroot/images/Products/ahmadTeaCeylonTea.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("95d8bb84-adb9-45da-8944-46b9a4c1295b"),
                column: "Url",
                value: "/app/wwwroot/images/Products/azer.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b54b3a14-3fbc-4469-89b4-382e2c88c00d"),
                column: "Url",
                value: "/app/wwwroot/images/Products/ahmadTeaEnglishBreakfast.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b9dfb257-e642-44d8-8e8b-9bc0bad15163"),
                column: "Url",
                value: "/app/wwwroot/images/Products/ahmadTeaStrawberryMousse.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c82d2c9a-409d-47e1-a7a3-b606e66dc312"),
                column: "Url",
                value: "/app/wwwroot/images/Products/curtisIsabellaGrape.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cd178c04-fefa-43b7-9729-e8c40a32aeff"),
                column: "Url",
                value: "/app/wwwroot/images/Products/ahmadTeaClassicGrey.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d83231a6-d222-4ad7-a585-fd4dc6cc4e3e"),
                column: "Url",
                value: "/app/wwwroot/images/Products/ahmadTeaClassikBlackTea.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e1a4238b-e9a8-4921-aa22-2571b70cca47"),
                column: "Url",
                value: "/app/wwwroot/images/Products/tessFlirt.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e976453b-3db1-4cd3-a13e-e0ea36240fb3"),
                column: "Url",
                value: "/app/wwwroot/images/Products/ahmadTeaPearStrudel.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("044e37de-2943-4def-abbb-eb92c1425c17"),
                column: "Url",
                value: "/images/Products/curtisSunnyLemon.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("055179ce-228b-44e1-84e7-830ecfe1c2c3"),
                column: "Url",
                value: "/images/Products/tessForestDream.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1dd2fc09-5594-42a1-adb9-d808db86b166"),
                column: "Url",
                value: "/images/Products/tessBerryBar.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("23b9f8c5-3643-437e-b0b4-fd77662fba29"),
                column: "Url",
                value: "/images/Products/curtisWhiteBountea.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("82d69078-d813-4471-a595-8b946e0bcf07"),
                column: "Url",
                value: "/images/Products/tessDark.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8768b0ee-6439-4dd6-ac5a-a0796430543b"),
                column: "Url",
                value: "/images/Products/curtisSummerBerries.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8c32a5fb-6709-40a4-8079-3bd8dc3e9c46"),
                column: "Url",
                value: "/images/Products/ahmadTeaLondonAfternoon.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8df0a3ec-b6b3-48b2-84bf-795f38580dab"),
                column: "Url",
                value: "/images/Products/ahmadTeaCeylonTea.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("95d8bb84-adb9-45da-8944-46b9a4c1295b"),
                column: "Url",
                value: "/images/Products/azer.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b54b3a14-3fbc-4469-89b4-382e2c88c00d"),
                column: "Url",
                value: "/images/Products/ahmadTeaEnglishBreakfast.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b9dfb257-e642-44d8-8e8b-9bc0bad15163"),
                column: "Url",
                value: "/images/Products/ahmadTeaStrawberryMousse.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c82d2c9a-409d-47e1-a7a3-b606e66dc312"),
                column: "Url",
                value: "/images/Products/curtisIsabellaGrape.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cd178c04-fefa-43b7-9729-e8c40a32aeff"),
                column: "Url",
                value: "/images/Products/ahmadTeaClassicGrey.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d83231a6-d222-4ad7-a585-fd4dc6cc4e3e"),
                column: "Url",
                value: "/images/Products/ahmadTeaClassikBlackTea.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e1a4238b-e9a8-4921-aa22-2571b70cca47"),
                column: "Url",
                value: "/images/Products/tessFlirt.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e976453b-3db1-4cd3-a13e-e0ea36240fb3"),
                column: "Url",
                value: "/images/Products/ahmadTeaPearStrudel.png");
        }
    }
}
