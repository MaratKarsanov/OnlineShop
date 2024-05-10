using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavouritesId", "ImageLink", "IsInComparison", "IsInFavourites", "Name" },
                values: new object[,]
                {
                    { new Guid("022d0a79-f8cb-44a5-9709-124359512159"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaClassicGrey.png", false, false, "Ahmad Tea Classic Grey" },
                    { new Guid("0e523662-9c79-4121-82e9-e5fcac260d9b"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/curtisWhiteBountea.png", false, false, "Curtis White Bountea" },
                    { new Guid("13bb4596-526b-4e4b-a083-086fba4784bf"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/tessFlirt.png", false, false, "Tess Flirt" },
                    { new Guid("18b7172c-26f6-43c5-af1c-289615e4e82a"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/curtisSummerBerries.png", false, false, "Curtis Summer Berries" },
                    { new Guid("1c94fbd2-aa6e-40fe-955c-444f94d119a7"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/curtisSunnyLemon.png", false, false, "Curtis Sunny Lemon" },
                    { new Guid("270684d3-4d4f-4652-b59b-f87fd58a8297"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaLondonAfternoon.png", false, false, "Ahmad Tea London Afternoon" },
                    { new Guid("34a03e74-090b-4699-85d5-cc212e4597ca"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/tessForestDream.png", false, false, "Tess Forest Dream" },
                    { new Guid("7795c6d9-9a8b-4c36-9c42-99f73d79871c"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/azer.png", false, false, "Azer Tea" },
                    { new Guid("8f94f1dc-887d-451f-a9fd-56a0d4e7e374"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaCeylonTea.png", false, false, "Ahmad Tea Ceylon" },
                    { new Guid("a7b663b9-0132-45ff-96eb-bcab037c9190"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaStrawberryMousse.png", false, false, "Ahmad Tea Strawberry Mousse" },
                    { new Guid("b8744ed8-31c0-40b0-b988-7f1578cbc4b3"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/tessDark.png", false, false, "Tess Dark" },
                    { new Guid("c1b61939-ca84-4a14-a698-0946540612a0"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaClassikBlackTea.png", false, false, "Ahmad Tea Classic Black" },
                    { new Guid("d054d31e-5b33-4447-b7af-46dc26c74572"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaEnglishBreakfast.png", false, false, "Ahmad Tea English Breakfast" },
                    { new Guid("d579d880-9616-4e06-8249-62f6c482ad1d"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/curtisIsabellaGrape.png", false, false, "Curtis Isabella Grape" },
                    { new Guid("d777d305-279e-4e99-8a5f-c0155019a08f"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/tessBerryBar.png", false, false, "Tess Berry Bar" },
                    { new Guid("f25f268a-b0e9-40cc-989d-4e186592a469"), null, 500m, "Очень вкусный и ароматный чай", null, "/images/teas/ahmadTeaPearStrudel.png", false, false, "Ahmad Tea Pear Strudel" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                column: "Name",
                values: new object[]
                {
                    "Administrator",
                    "User"
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Address", "Name", "Password", "PhoneNumber", "RememberMe", "RoleName", "Surname" },
                values: new object[] { "karsanov@mail.ru", "Vatutina 37", "Marat", "marmar", "89187080533", false, "Administrator", "Karsanov" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("022d0a79-f8cb-44a5-9709-124359512159"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e523662-9c79-4121-82e9-e5fcac260d9b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13bb4596-526b-4e4b-a083-086fba4784bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("18b7172c-26f6-43c5-af1c-289615e4e82a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1c94fbd2-aa6e-40fe-955c-444f94d119a7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("270684d3-4d4f-4652-b59b-f87fd58a8297"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("34a03e74-090b-4699-85d5-cc212e4597ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7795c6d9-9a8b-4c36-9c42-99f73d79871c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f94f1dc-887d-451f-a9fd-56a0d4e7e374"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a7b663b9-0132-45ff-96eb-bcab037c9190"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b8744ed8-31c0-40b0-b988-7f1578cbc4b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c1b61939-ca84-4a14-a698-0946540612a0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d054d31e-5b33-4447-b7af-46dc26c74572"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d579d880-9616-4e06-8249-62f6c482ad1d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d777d305-279e-4e99-8a5f-c0155019a08f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f25f268a-b0e9-40cc-989d-4e186592a469"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Name",
                keyValue: "User");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "karsanov@mail.ru");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Name",
                keyValue: "Administrator");
        }
    }
}
