using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddBasicUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleName",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("020ee465-ebcb-4fd4-8e8b-84a69cf4ddbe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0458d28b-c3fe-48ed-bc79-e5a714b594d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("050b015e-e557-4afe-a91c-375010aed665"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0683aa36-ab01-4e98-bed4-2176f468292f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("06c6591d-ba20-404a-8c72-8afb61887da7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("07826e11-7ce3-4cc9-b8bd-37616b318d60"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c4e5bbd-6f24-46ea-9c65-e2fb36a03a98"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0d49521f-0b3b-41fc-804d-d7b1b596e563"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ff76584-03f3-42f2-a4f0-1c876f6bd0c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1551d956-8426-47c8-bf45-01cc83914754"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1a0f3dd1-67f7-465e-bdea-449be7cc146b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b09ddb7-e476-4fac-9c71-fd2b948d1df2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1e682c66-9b4e-4884-bef3-889c1ccd087a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("218b79cb-f5de-4544-9ee1-1c7645808ea4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2adaf171-50a5-43ab-bf0f-53cf0ac460f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d19858b-baea-4212-9038-1bc154888b2f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32bd3ec5-45b1-4820-ae6d-d474e1848c65"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32ec1f99-3f24-4b9a-8b6f-05a7ec517b37"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("341691b1-f9dc-4d20-a477-88b07abe86f4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3436edd5-f7dc-4c86-a81f-08b2c99c82b9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("38c3ba56-fdbb-4fcd-b6d8-550a5dab0d3f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("38ff2633-3b1b-4a4e-9884-c72355922573"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3bb84bec-3c62-4311-925e-bba0118d4a0e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3fc3b090-1d4f-49af-a85b-624c99e53adf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("41fd53b2-d9b0-445a-9c58-16e327d20138"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("41fed191-1d3d-43ca-9e01-ef145e4feecb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4232e07f-8f3e-411e-9b7e-b3b8b63e38f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46d22e79-e4e7-4786-8eb1-5113c8b569ab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4caaed6c-8d70-4d6c-b31e-066c2584f98a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d475bf5-3f0c-45ed-9a19-d141ac11aba5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d478d92-b5bf-47ab-bd71-e1ec99e8c7a6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4facd484-4c5d-4722-8ef5-6cf7135c6a7b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ff18dae-7eed-4a7e-aafd-874ec6b1cd12"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("517c15e2-f5d1-4700-b020-c11aa932e9f8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("57b4f572-21b2-4cf8-8844-fc1d91e38014"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5d58cc18-55d1-4754-b5c0-5f90fa35653c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5dd4ce1f-8612-485e-8676-cd8cbd099040"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6023a32f-1328-4be9-bc68-00a63f597a17"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("61d2e576-6a49-48f3-b7cd-73e86ba50e64"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64f38adb-3bbd-4041-85c3-7a5701acd0c7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("654915d2-1420-4b3d-8b57-98b9623e04d9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6664cb5e-ab60-4d80-bc9b-e4e4630a7d31"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("67ea9e0b-2372-44e6-a287-2c60b759951c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6bb3fee2-9752-4bd4-ba63-455c6e0d9181"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d53413e-5538-48b1-8a18-01d302724c13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e317fc0-e620-4aa9-b6e3-9512380d690d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f1c4a7f-ab25-4cf1-b764-e01eff8324ba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("71590f62-edfe-493b-bb9d-738ddb3bb966"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7285a46c-2d57-4cc0-952f-07449f4dadec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7561be6b-57e8-4321-a780-310a80d9b45a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7619090a-4e1d-4996-a5eb-453dc6d70679"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("782d0042-46bd-45e7-9eae-1e2e64cb9360"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7a0ce445-1b3e-435c-a867-f8f8365875f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7a860da9-1688-40b7-97a7-e0780ab8495c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d92c6a9-bd74-43b8-855b-401bc6d8430a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("80a7326e-8f94-4dad-b766-075d7758d31f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("84471332-7522-496f-8b4e-15ea9c3e649c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("89cbc656-0ab6-45a1-91a9-d0ba3c91c22c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8eca91d8-0303-4083-9762-ec4160b2b8c4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("92412742-598d-4eba-9fe7-26a841739e42"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93f3bc12-243f-4e13-8b3a-c0e14563889a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("941b2bb0-fbfd-4b46-972a-0c0c76fe3af5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("94a1a81c-bed8-4480-be1d-78fac69a7a5b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96e1255b-4440-487d-9463-f0ce04bd1f8f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("98c6ae8a-1d08-4b27-b361-c91ba5920a42"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99e14540-68f1-44d2-bfd8-a1c864a19d42"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c0fc76b-91e8-4a31-a83e-7bb7aec4522a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c4af692-e56c-44f2-8b8f-b5faf4ff2c20"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9cb6cd30-5d3e-4b49-a03a-ff167ae9db23"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d9a53de-c836-47d3-926c-778c798b24a7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a079052d-1cb4-42a7-8fc5-675c0e6ae991"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0b0b061-5a23-491f-995a-006642ecab01"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a11cc316-68df-4197-ac2e-4e38729bda16"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a9fb7004-6cb4-47b4-ba8a-12727c0bbb68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("abf4dc6b-4d32-4036-bc55-9179b861b693"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4920d1a-9172-46dc-992e-8b63f67db3c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b51f94ca-62c6-4524-be86-d574c5be3a4d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b633a560-3a1a-4a07-85a0-96452dba3be3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7d74fe3-055b-4eda-addd-2553f7a1b8ff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("baf76dba-b268-4877-a22f-793dc008fe57"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8cc6510-daa7-4667-a92b-89c63cb1171c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("caa1b394-812f-490b-b86d-07398cf3bdde"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cf396d7e-1d62-4335-9fad-db0f42964d2a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cf74126d-5f0f-493f-8b36-6413f73e21dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d25ee23a-1350-4d15-a04e-98f5128415df"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d27b9bbf-6529-4104-846d-8fbe9ec088d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2fa8058-5990-4499-9e59-edfc13b4594e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4a516d8-6929-4cfe-b940-037195ce1a82"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da551d68-c07f-4402-baf9-e1e00102fb06"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db2ec1a7-6ba1-483f-85b2-9c3c1351b9d8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dc58ed14-f4e2-4e20-96a2-14ff9bb8ab78"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e081fc59-2bb6-4dc4-b5f0-18a0c6212ef0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e70f6985-111d-4d34-819c-468ca5028570"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7db8eb0-d373-429d-85f5-a7a7efa9db67"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eaea7c5e-a493-40ac-86d7-33f99808d2cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f34821cd-591b-4b28-8765-a86cd19ef042"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f402298c-465a-441b-b71a-3ae66fcb2649"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb1ba2f7-d384-4b30-b727-9760b3f7ee31"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd0b990c-f173-42fc-9f12-46079ee88876"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff21d764-ba2d-4cf5-a640-f9d300e835dc"));

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavouritesId", "ImageLink", "IsInComparison", "IsInFavourites", "Name" },
                values: new object[,]
                {
                    { new Guid("05325365-e58a-42a4-9257-bef1d3d2fea7"), null, 6500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name65" },
                    { new Guid("05d4a10f-8157-4d04-aacb-ed6783d3c1ef"), null, 4300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name43" },
                    { new Guid("0e5b4da1-5628-4f13-a32b-b1b7f1ece6c9"), null, 1400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name14" },
                    { new Guid("126f668d-1c22-4806-8f0d-e00bac477e6b"), null, 5800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name58" },
                    { new Guid("14d10c52-cbe1-4031-b5cb-e2f39a347153"), null, 600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name6" },
                    { new Guid("1734013b-7a91-450e-abe3-86967cb90ea6"), null, 2900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name29" },
                    { new Guid("186f831c-0aae-4f29-85e6-a2313ddc23c3"), null, 7200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name72" },
                    { new Guid("189ea2ef-1f6d-403c-9b89-734c56e4200b"), null, 2600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name26" },
                    { new Guid("1a1508c0-088a-4aed-bf52-46a05cf995ba"), null, 9200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name92" },
                    { new Guid("1aadf54f-e195-46b1-aaed-e6a86b01323c"), null, 9100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name91" },
                    { new Guid("1b4fdea9-a543-4468-9339-288067e1ad03"), null, 5700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name57" },
                    { new Guid("1cc1e387-77f2-4e7c-ba79-13be2b568da8"), null, 1600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name16" },
                    { new Guid("1d7262bb-855d-4ff6-8c14-26119f5d2ddc"), null, 9700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name97" },
                    { new Guid("214dc587-ac46-4094-b0d8-1b9e41773bc5"), null, 3400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name34" },
                    { new Guid("2aafdd0f-3fe2-4c0d-b087-60019f49dc02"), null, 6200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name62" },
                    { new Guid("2ae4d4ea-c010-46a9-a385-fcc21f0b3efc"), null, 7500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name75" },
                    { new Guid("2cd88341-3628-4e2a-9118-0a63b181c2ac"), null, 2500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name25" },
                    { new Guid("2f49fc5f-8a11-4778-84d2-17bbeccd1553"), null, 5900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name59" },
                    { new Guid("30f72784-b3b6-4de8-b7f9-8bf5f151295b"), null, 5400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name54" },
                    { new Guid("31417907-0c62-436e-a5b7-24fbb449f82d"), null, 6800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name68" },
                    { new Guid("3353009c-8de7-4cbc-808a-0268dbaf2cf4"), null, 2400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name24" },
                    { new Guid("34290b4b-45e0-4a9d-ac91-a88516d18178"), null, 2800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name28" },
                    { new Guid("34fec9ee-3063-46da-959a-db86c57fd6ac"), null, 4900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name49" },
                    { new Guid("36a670ad-ac6a-4a98-9cea-48610d3f3dba"), null, 6600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name66" },
                    { new Guid("39c882f1-7c78-4c99-9a1a-684601ab44af"), null, 3100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name31" },
                    { new Guid("3aaaa6ca-683b-423b-aab0-c080e8cc57b9"), null, 6400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name64" },
                    { new Guid("3d8f7cf6-0f21-4131-a893-93e0d6b4161c"), null, 4500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name45" },
                    { new Guid("3de50e20-0527-4d6d-a920-1fe28b6494ec"), null, 2000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name20" },
                    { new Guid("3e1c2ed3-af6d-4771-b103-6d7677265cc5"), null, 7400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name74" },
                    { new Guid("3e5ffc5a-b267-4b35-b57b-6585cdc8563c"), null, 7100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name71" },
                    { new Guid("3f4702e6-4f7b-49a8-9357-3e59c3886ccd"), null, 9400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name94" },
                    { new Guid("41eb8835-b59e-46a7-ab5e-5754362069c9"), null, 7300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name73" },
                    { new Guid("425b0f08-f505-4ad3-9f94-10681824eae6"), null, 800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name8" },
                    { new Guid("43bba197-df20-4e0a-9086-fd087043ec5d"), null, 9800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name98" },
                    { new Guid("44205fa1-ca38-460a-b113-c8981acd3f68"), null, 9000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name90" },
                    { new Guid("45447ec8-57f2-489c-ad6c-5bae2072cd09"), null, 9600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name96" },
                    { new Guid("4b510fe8-bcba-4b63-b494-5fa67d3c0c45"), null, 8500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name85" },
                    { new Guid("4c4bcfbc-5dc1-4d58-be89-418191a01b47"), null, 6900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name69" },
                    { new Guid("4d5ecc14-9887-414b-91ce-a847aef43509"), null, 8000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name80" },
                    { new Guid("4f98eba7-9f3f-4ae3-b12c-b5d69c7034f1"), null, 3500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name35" },
                    { new Guid("5145b1d7-115d-411a-9a04-48718aed016b"), null, 1300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name13" },
                    { new Guid("54e5e444-677c-4ec9-a588-bdce33746d92"), null, 6000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name60" },
                    { new Guid("5764666e-4212-48fa-96b8-efb776209b7d"), null, 200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name2" },
                    { new Guid("59f20b4a-0735-412a-acb3-d05a302e093c"), null, 900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name9" },
                    { new Guid("60207254-145d-4f86-a119-21ec65b7f251"), null, 8700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name87" },
                    { new Guid("66177840-73c5-4dd4-995b-543437873500"), null, 8800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name88" },
                    { new Guid("67c74d76-37d0-4677-adb0-bbbaa5b98e75"), null, 8400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name84" },
                    { new Guid("67cb5eeb-99c6-4ee3-9cae-c271428942e0"), null, 5500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name55" },
                    { new Guid("6dd86860-5b4a-4922-84ef-912dd01f01d8"), null, 4200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name42" },
                    { new Guid("6df305c6-8d4d-4f37-b216-8d4346d0bbfe"), null, 4800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name48" },
                    { new Guid("70da25f7-448d-475c-8b44-aecf07129de4"), null, 1200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name12" },
                    { new Guid("729a8ea5-f02f-4fe0-b7ef-cf23c419973f"), null, 4400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name44" },
                    { new Guid("7453169e-d79c-4689-9420-06a98d5b8bca"), null, 500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name5" },
                    { new Guid("746ed55e-05d1-46f3-818e-19799709b402"), null, 3300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name33" },
                    { new Guid("756f398f-3174-4475-b6b8-f030afa87640"), null, 7800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name78" },
                    { new Guid("75a2c608-1d27-4161-9f4c-28e2249bc1d0"), null, 3000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name30" },
                    { new Guid("77a16df0-b0ff-4396-a891-a8d7be50811e"), null, 9300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name93" },
                    { new Guid("8509278e-7df7-4427-94d1-34e75b18e556"), null, 1500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name15" },
                    { new Guid("8647da53-1dfc-434f-98b6-c768937fd6ed"), null, 8200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name82" },
                    { new Guid("8a1bf9be-f32a-442b-be5c-f65c26f47d77"), null, 6700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name67" },
                    { new Guid("909c2cc7-6ea3-4d40-b693-fc52f8898466"), null, 3900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name39" },
                    { new Guid("91ae481d-e539-4e9a-a3e0-469d9d48ece9"), null, 2300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name23" },
                    { new Guid("9519b474-4cdb-4a8e-a2e0-0f6d0b9b9853"), null, 5100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name51" },
                    { new Guid("9bfaa4df-4540-4fae-a656-c512ab5b1499"), null, 2700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name27" },
                    { new Guid("9cfa5605-3b01-4e67-adc0-90c5061e401d"), null, 3800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name38" },
                    { new Guid("9d3788db-41cd-4f8f-b7b7-71c8d4949d10"), null, 7000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name70" },
                    { new Guid("9f485c28-0034-4349-8c8f-4bb13e5f69bc"), null, 3700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name37" },
                    { new Guid("a4840c3d-974e-4006-8260-6f36f72346a1"), null, 4100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name41" },
                    { new Guid("a7abc60e-7ea4-4a8c-bfc9-88db539c84dd"), null, 8900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name89" },
                    { new Guid("a9fef1b3-c7f5-4fd6-8fe0-2b1ddc0d778f"), null, 2200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name22" },
                    { new Guid("ad71c416-a662-42c9-a8bb-d0ba9cbb6889"), null, 8600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name86" },
                    { new Guid("ae86f80b-c078-4d0d-a0d2-1f6ad0808972"), null, 4700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name47" },
                    { new Guid("b2db8889-53cf-4d01-8083-fc75e79296a8"), null, 6300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name63" },
                    { new Guid("b481a390-a744-4b66-a34f-d916be857723"), null, 3600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name36" },
                    { new Guid("b5267945-0180-4fb7-8718-97fd3f6c6601"), null, 1700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name17" },
                    { new Guid("b9c4036e-ed91-42b8-ae8c-46d6ae85534a"), null, 6100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name61" },
                    { new Guid("bb355cf8-44ba-476e-a943-4420e468528c"), null, 4600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name46" },
                    { new Guid("be3148e0-746a-4e9b-ae96-7443d1f13e7f"), null, 5200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name52" },
                    { new Guid("be96a883-8437-4bff-8565-342667a8a8bb"), null, 1900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name19" },
                    { new Guid("d0dd7cee-21e5-4436-8ca5-ebb96c01a494"), null, 8100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name81" },
                    { new Guid("d2ac1be1-7887-4c91-827b-1449b3a47a7f"), null, 1000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name10" },
                    { new Guid("d7baa3fe-658d-44bf-ad7a-9c07b7f9c01f"), null, 1800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name18" },
                    { new Guid("d99450ec-0c22-44e1-8f27-b3f1fb133ca2"), null, 8300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name83" },
                    { new Guid("db65fa95-1d7d-452b-9b2c-b84a2f2b393d"), null, 7600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name76" },
                    { new Guid("dcbca455-bb43-4450-9125-368c63cba15c"), null, 9900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name99" },
                    { new Guid("e043bb94-ae83-4b69-afec-ba3dd7d767fb"), null, 700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name7" },
                    { new Guid("e1388950-d9b7-476b-8f47-6b1fd8442624"), null, 9500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name95" },
                    { new Guid("eb17b146-2ae1-4376-a66c-9ade3188a31b"), null, 5600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name56" },
                    { new Guid("efe3c82e-331f-4d69-9b32-79e1be2b947e"), null, 5000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name50" },
                    { new Guid("f05ce6b6-6f65-4f19-93e6-4f0b55bec3e0"), null, 4000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name40" },
                    { new Guid("f0bda594-aec0-4677-8573-3a58220f7508"), null, 7700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name77" },
                    { new Guid("f168addd-7f8f-4671-a447-a22fb8013591"), null, 1100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name11" },
                    { new Guid("f4433020-4eac-43c9-95e4-ee7754cfcfe9"), null, 3200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name32" },
                    { new Guid("f789aeb5-5058-4a8e-8720-c514194ce4f3"), null, 5300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name53" },
                    { new Guid("f7fafc58-1811-4d18-8356-cd568ee803c8"), null, 0m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name0" },
                    { new Guid("f821cbc5-0841-435f-b14c-558532c4b8b6"), null, 7900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name79" },
                    { new Guid("f829762d-53da-41cc-94ee-0d606ab05795"), null, 2100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name21" },
                    { new Guid("f8880ffe-1f5b-48bf-adad-347b54cbb131"), null, 400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name4" },
                    { new Guid("fa6ea92c-9ec8-43f4-9fd5-11fdfb4973af"), null, 100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name1" },
                    { new Guid("fe5ca804-bc57-4ec5-a3ed-c7f8f27aad0e"), null, 300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Address", "Name", "Password", "PhoneNumber", "RememberMe", "RoleName", "Surname" },
                values: new object[] { "karsanov@mail.ru", "Vatutina 37", "Marat", "marmar", "89187080533", false, "Administrator", "Karsanov" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleName",
                table: "Users",
                column: "RoleName",
                principalTable: "Roles",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleName",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("05325365-e58a-42a4-9257-bef1d3d2fea7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("05d4a10f-8157-4d04-aacb-ed6783d3c1ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e5b4da1-5628-4f13-a32b-b1b7f1ece6c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("126f668d-1c22-4806-8f0d-e00bac477e6b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("14d10c52-cbe1-4031-b5cb-e2f39a347153"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1734013b-7a91-450e-abe3-86967cb90ea6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("186f831c-0aae-4f29-85e6-a2313ddc23c3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("189ea2ef-1f6d-403c-9b89-734c56e4200b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1a1508c0-088a-4aed-bf52-46a05cf995ba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1aadf54f-e195-46b1-aaed-e6a86b01323c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b4fdea9-a543-4468-9339-288067e1ad03"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1cc1e387-77f2-4e7c-ba79-13be2b568da8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d7262bb-855d-4ff6-8c14-26119f5d2ddc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("214dc587-ac46-4094-b0d8-1b9e41773bc5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2aafdd0f-3fe2-4c0d-b087-60019f49dc02"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2ae4d4ea-c010-46a9-a385-fcc21f0b3efc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2cd88341-3628-4e2a-9118-0a63b181c2ac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2f49fc5f-8a11-4778-84d2-17bbeccd1553"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30f72784-b3b6-4de8-b7f9-8bf5f151295b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("31417907-0c62-436e-a5b7-24fbb449f82d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3353009c-8de7-4cbc-808a-0268dbaf2cf4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("34290b4b-45e0-4a9d-ac91-a88516d18178"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("34fec9ee-3063-46da-959a-db86c57fd6ac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36a670ad-ac6a-4a98-9cea-48610d3f3dba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("39c882f1-7c78-4c99-9a1a-684601ab44af"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3aaaa6ca-683b-423b-aab0-c080e8cc57b9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3d8f7cf6-0f21-4131-a893-93e0d6b4161c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3de50e20-0527-4d6d-a920-1fe28b6494ec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3e1c2ed3-af6d-4771-b103-6d7677265cc5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3e5ffc5a-b267-4b35-b57b-6585cdc8563c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3f4702e6-4f7b-49a8-9357-3e59c3886ccd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("41eb8835-b59e-46a7-ab5e-5754362069c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("425b0f08-f505-4ad3-9f94-10681824eae6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("43bba197-df20-4e0a-9086-fd087043ec5d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44205fa1-ca38-460a-b113-c8981acd3f68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("45447ec8-57f2-489c-ad6c-5bae2072cd09"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b510fe8-bcba-4b63-b494-5fa67d3c0c45"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c4bcfbc-5dc1-4d58-be89-418191a01b47"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d5ecc14-9887-414b-91ce-a847aef43509"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4f98eba7-9f3f-4ae3-b12c-b5d69c7034f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5145b1d7-115d-411a-9a04-48718aed016b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("54e5e444-677c-4ec9-a588-bdce33746d92"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5764666e-4212-48fa-96b8-efb776209b7d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59f20b4a-0735-412a-acb3-d05a302e093c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60207254-145d-4f86-a119-21ec65b7f251"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66177840-73c5-4dd4-995b-543437873500"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("67c74d76-37d0-4677-adb0-bbbaa5b98e75"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("67cb5eeb-99c6-4ee3-9cae-c271428942e0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6dd86860-5b4a-4922-84ef-912dd01f01d8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6df305c6-8d4d-4f37-b216-8d4346d0bbfe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("70da25f7-448d-475c-8b44-aecf07129de4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("729a8ea5-f02f-4fe0-b7ef-cf23c419973f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7453169e-d79c-4689-9420-06a98d5b8bca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("746ed55e-05d1-46f3-818e-19799709b402"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("756f398f-3174-4475-b6b8-f030afa87640"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75a2c608-1d27-4161-9f4c-28e2249bc1d0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77a16df0-b0ff-4396-a891-a8d7be50811e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8509278e-7df7-4427-94d1-34e75b18e556"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8647da53-1dfc-434f-98b6-c768937fd6ed"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a1bf9be-f32a-442b-be5c-f65c26f47d77"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("909c2cc7-6ea3-4d40-b693-fc52f8898466"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("91ae481d-e539-4e9a-a3e0-469d9d48ece9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9519b474-4cdb-4a8e-a2e0-0f6d0b9b9853"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9bfaa4df-4540-4fae-a656-c512ab5b1499"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9cfa5605-3b01-4e67-adc0-90c5061e401d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d3788db-41cd-4f8f-b7b7-71c8d4949d10"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f485c28-0034-4349-8c8f-4bb13e5f69bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a4840c3d-974e-4006-8260-6f36f72346a1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a7abc60e-7ea4-4a8c-bfc9-88db539c84dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a9fef1b3-c7f5-4fd6-8fe0-2b1ddc0d778f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad71c416-a662-42c9-a8bb-d0ba9cbb6889"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ae86f80b-c078-4d0d-a0d2-1f6ad0808972"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2db8889-53cf-4d01-8083-fc75e79296a8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b481a390-a744-4b66-a34f-d916be857723"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b5267945-0180-4fb7-8718-97fd3f6c6601"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9c4036e-ed91-42b8-ae8c-46d6ae85534a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb355cf8-44ba-476e-a943-4420e468528c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be3148e0-746a-4e9b-ae96-7443d1f13e7f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be96a883-8437-4bff-8565-342667a8a8bb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d0dd7cee-21e5-4436-8ca5-ebb96c01a494"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2ac1be1-7887-4c91-827b-1449b3a47a7f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d7baa3fe-658d-44bf-ad7a-9c07b7f9c01f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d99450ec-0c22-44e1-8f27-b3f1fb133ca2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db65fa95-1d7d-452b-9b2c-b84a2f2b393d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dcbca455-bb43-4450-9125-368c63cba15c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e043bb94-ae83-4b69-afec-ba3dd7d767fb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e1388950-d9b7-476b-8f47-6b1fd8442624"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb17b146-2ae1-4376-a66c-9ade3188a31b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("efe3c82e-331f-4d69-9b32-79e1be2b947e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f05ce6b6-6f65-4f19-93e6-4f0b55bec3e0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f0bda594-aec0-4677-8573-3a58220f7508"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f168addd-7f8f-4671-a447-a22fb8013591"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f4433020-4eac-43c9-95e4-ee7754cfcfe9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f789aeb5-5058-4a8e-8720-c514194ce4f3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f7fafc58-1811-4d18-8356-cd568ee803c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f821cbc5-0841-435f-b14c-558532c4b8b6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f829762d-53da-41cc-94ee-0d606ab05795"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f8880ffe-1f5b-48bf-adad-347b54cbb131"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa6ea92c-9ec8-43f4-9fd5-11fdfb4973af"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe5ca804-bc57-4ec5-a3ed-c7f8f27aad0e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "karsanov@mail.ru");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavouritesId", "ImageLink", "IsInComparison", "IsInFavourites", "Name" },
                values: new object[,]
                {
                    { new Guid("020ee465-ebcb-4fd4-8e8b-84a69cf4ddbe"), null, 6300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name63" },
                    { new Guid("0458d28b-c3fe-48ed-bc79-e5a714b594d3"), null, 5600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name56" },
                    { new Guid("050b015e-e557-4afe-a91c-375010aed665"), null, 200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name2" },
                    { new Guid("0683aa36-ab01-4e98-bed4-2176f468292f"), null, 8100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name81" },
                    { new Guid("06c6591d-ba20-404a-8c72-8afb61887da7"), null, 3400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name34" },
                    { new Guid("07826e11-7ce3-4cc9-b8bd-37616b318d60"), null, 4300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name43" },
                    { new Guid("0c4e5bbd-6f24-46ea-9c65-e2fb36a03a98"), null, 5400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name54" },
                    { new Guid("0d49521f-0b3b-41fc-804d-d7b1b596e563"), null, 9200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name92" },
                    { new Guid("0ff76584-03f3-42f2-a4f0-1c876f6bd0c0"), null, 4000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name40" },
                    { new Guid("1551d956-8426-47c8-bf45-01cc83914754"), null, 0m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name0" },
                    { new Guid("1a0f3dd1-67f7-465e-bdea-449be7cc146b"), null, 6200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name62" },
                    { new Guid("1b09ddb7-e476-4fac-9c71-fd2b948d1df2"), null, 7700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name77" },
                    { new Guid("1e682c66-9b4e-4884-bef3-889c1ccd087a"), null, 5300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name53" },
                    { new Guid("218b79cb-f5de-4544-9ee1-1c7645808ea4"), null, 4800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name48" },
                    { new Guid("2adaf171-50a5-43ab-bf0f-53cf0ac460f9"), null, 9700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name97" },
                    { new Guid("2d19858b-baea-4212-9038-1bc154888b2f"), null, 2700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name27" },
                    { new Guid("32bd3ec5-45b1-4820-ae6d-d474e1848c65"), null, 300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name3" },
                    { new Guid("32ec1f99-3f24-4b9a-8b6f-05a7ec517b37"), null, 1900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name19" },
                    { new Guid("341691b1-f9dc-4d20-a477-88b07abe86f4"), null, 1300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name13" },
                    { new Guid("3436edd5-f7dc-4c86-a81f-08b2c99c82b9"), null, 800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name8" },
                    { new Guid("38c3ba56-fdbb-4fcd-b6d8-550a5dab0d3f"), null, 5700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name57" },
                    { new Guid("38ff2633-3b1b-4a4e-9884-c72355922573"), null, 4200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name42" },
                    { new Guid("3bb84bec-3c62-4311-925e-bba0118d4a0e"), null, 2300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name23" },
                    { new Guid("3fc3b090-1d4f-49af-a85b-624c99e53adf"), null, 5100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name51" },
                    { new Guid("41fd53b2-d9b0-445a-9c58-16e327d20138"), null, 9800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name98" },
                    { new Guid("41fed191-1d3d-43ca-9e01-ef145e4feecb"), null, 5900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name59" },
                    { new Guid("4232e07f-8f3e-411e-9b7e-b3b8b63e38f5"), null, 1000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name10" },
                    { new Guid("46d22e79-e4e7-4786-8eb1-5113c8b569ab"), null, 1100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name11" },
                    { new Guid("4caaed6c-8d70-4d6c-b31e-066c2584f98a"), null, 6100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name61" },
                    { new Guid("4d475bf5-3f0c-45ed-9a19-d141ac11aba5"), null, 7600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name76" },
                    { new Guid("4d478d92-b5bf-47ab-bd71-e1ec99e8c7a6"), null, 2400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name24" },
                    { new Guid("4facd484-4c5d-4722-8ef5-6cf7135c6a7b"), null, 1800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name18" },
                    { new Guid("4ff18dae-7eed-4a7e-aafd-874ec6b1cd12"), null, 6800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name68" },
                    { new Guid("517c15e2-f5d1-4700-b020-c11aa932e9f8"), null, 3600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name36" },
                    { new Guid("57b4f572-21b2-4cf8-8844-fc1d91e38014"), null, 900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name9" },
                    { new Guid("5d58cc18-55d1-4754-b5c0-5f90fa35653c"), null, 8300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name83" },
                    { new Guid("5dd4ce1f-8612-485e-8676-cd8cbd099040"), null, 2800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name28" },
                    { new Guid("6023a32f-1328-4be9-bc68-00a63f597a17"), null, 3200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name32" },
                    { new Guid("61d2e576-6a49-48f3-b7cd-73e86ba50e64"), null, 4700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name47" },
                    { new Guid("64f38adb-3bbd-4041-85c3-7a5701acd0c7"), null, 9900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name99" },
                    { new Guid("654915d2-1420-4b3d-8b57-98b9623e04d9"), null, 6700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name67" },
                    { new Guid("6664cb5e-ab60-4d80-bc9b-e4e4630a7d31"), null, 3800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name38" },
                    { new Guid("67ea9e0b-2372-44e6-a287-2c60b759951c"), null, 7200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name72" },
                    { new Guid("6bb3fee2-9752-4bd4-ba63-455c6e0d9181"), null, 1400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name14" },
                    { new Guid("6d53413e-5538-48b1-8a18-01d302724c13"), null, 9600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name96" },
                    { new Guid("6e317fc0-e620-4aa9-b6e3-9512380d690d"), null, 6500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name65" },
                    { new Guid("6f1c4a7f-ab25-4cf1-b764-e01eff8324ba"), null, 4500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name45" },
                    { new Guid("71590f62-edfe-493b-bb9d-738ddb3bb966"), null, 9300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name93" },
                    { new Guid("7285a46c-2d57-4cc0-952f-07449f4dadec"), null, 1500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name15" },
                    { new Guid("7561be6b-57e8-4321-a780-310a80d9b45a"), null, 3500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name35" },
                    { new Guid("7619090a-4e1d-4996-a5eb-453dc6d70679"), null, 4100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name41" },
                    { new Guid("782d0042-46bd-45e7-9eae-1e2e64cb9360"), null, 6900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name69" },
                    { new Guid("7a0ce445-1b3e-435c-a867-f8f8365875f7"), null, 7400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name74" },
                    { new Guid("7a860da9-1688-40b7-97a7-e0780ab8495c"), null, 5500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name55" },
                    { new Guid("7d92c6a9-bd74-43b8-855b-401bc6d8430a"), null, 4900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name49" },
                    { new Guid("80a7326e-8f94-4dad-b766-075d7758d31f"), null, 7000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name70" },
                    { new Guid("84471332-7522-496f-8b4e-15ea9c3e649c"), null, 9500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name95" },
                    { new Guid("89cbc656-0ab6-45a1-91a9-d0ba3c91c22c"), null, 2000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name20" },
                    { new Guid("8eca91d8-0303-4083-9762-ec4160b2b8c4"), null, 3300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name33" },
                    { new Guid("92412742-598d-4eba-9fe7-26a841739e42"), null, 3700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name37" },
                    { new Guid("93f3bc12-243f-4e13-8b3a-c0e14563889a"), null, 500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name5" },
                    { new Guid("941b2bb0-fbfd-4b46-972a-0c0c76fe3af5"), null, 1700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name17" },
                    { new Guid("94a1a81c-bed8-4480-be1d-78fac69a7a5b"), null, 2100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name21" },
                    { new Guid("96e1255b-4440-487d-9463-f0ce04bd1f8f"), null, 3900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name39" },
                    { new Guid("98c6ae8a-1d08-4b27-b361-c91ba5920a42"), null, 8900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name89" },
                    { new Guid("99e14540-68f1-44d2-bfd8-a1c864a19d42"), null, 600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name6" },
                    { new Guid("9c0fc76b-91e8-4a31-a83e-7bb7aec4522a"), null, 2200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name22" },
                    { new Guid("9c4af692-e56c-44f2-8b8f-b5faf4ff2c20"), null, 700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name7" },
                    { new Guid("9cb6cd30-5d3e-4b49-a03a-ff167ae9db23"), null, 8200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name82" },
                    { new Guid("9d9a53de-c836-47d3-926c-778c798b24a7"), null, 6600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name66" },
                    { new Guid("a079052d-1cb4-42a7-8fc5-675c0e6ae991"), null, 8700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name87" },
                    { new Guid("a0b0b061-5a23-491f-995a-006642ecab01"), null, 7300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name73" },
                    { new Guid("a11cc316-68df-4197-ac2e-4e38729bda16"), null, 7500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name75" },
                    { new Guid("a9fb7004-6cb4-47b4-ba8a-12727c0bbb68"), null, 5000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name50" },
                    { new Guid("abf4dc6b-4d32-4036-bc55-9179b861b693"), null, 2900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name29" },
                    { new Guid("b4920d1a-9172-46dc-992e-8b63f67db3c0"), null, 4600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name46" },
                    { new Guid("b51f94ca-62c6-4524-be86-d574c5be3a4d"), null, 8400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name84" },
                    { new Guid("b633a560-3a1a-4a07-85a0-96452dba3be3"), null, 8500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name85" },
                    { new Guid("b7d74fe3-055b-4eda-addd-2553f7a1b8ff"), null, 1600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name16" },
                    { new Guid("baf76dba-b268-4877-a22f-793dc008fe57"), null, 5800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name58" },
                    { new Guid("c8cc6510-daa7-4667-a92b-89c63cb1171c"), null, 1200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name12" },
                    { new Guid("caa1b394-812f-490b-b86d-07398cf3bdde"), null, 6400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name64" },
                    { new Guid("cf396d7e-1d62-4335-9fad-db0f42964d2a"), null, 6000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name60" },
                    { new Guid("cf74126d-5f0f-493f-8b36-6413f73e21dd"), null, 4400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name44" },
                    { new Guid("d25ee23a-1350-4d15-a04e-98f5128415df"), null, 8800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name88" },
                    { new Guid("d27b9bbf-6529-4104-846d-8fbe9ec088d3"), null, 7100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name71" },
                    { new Guid("d2fa8058-5990-4499-9e59-edfc13b4594e"), null, 7800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name78" },
                    { new Guid("d4a516d8-6929-4cfe-b940-037195ce1a82"), null, 2500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name25" },
                    { new Guid("da551d68-c07f-4402-baf9-e1e00102fb06"), null, 400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name4" },
                    { new Guid("db2ec1a7-6ba1-483f-85b2-9c3c1351b9d8"), null, 9400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name94" },
                    { new Guid("dc58ed14-f4e2-4e20-96a2-14ff9bb8ab78"), null, 3000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name30" },
                    { new Guid("e081fc59-2bb6-4dc4-b5f0-18a0c6212ef0"), null, 7900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name79" },
                    { new Guid("e70f6985-111d-4d34-819c-468ca5028570"), null, 2600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name26" },
                    { new Guid("e7db8eb0-d373-429d-85f5-a7a7efa9db67"), null, 9000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name90" },
                    { new Guid("eaea7c5e-a493-40ac-86d7-33f99808d2cd"), null, 8600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name86" },
                    { new Guid("f34821cd-591b-4b28-8765-a86cd19ef042"), null, 100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name1" },
                    { new Guid("f402298c-465a-441b-b71a-3ae66fcb2649"), null, 5200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name52" },
                    { new Guid("fb1ba2f7-d384-4b30-b727-9760b3f7ee31"), null, 9100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name91" },
                    { new Guid("fd0b990c-f173-42fc-9f12-46079ee88876"), null, 8000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name80" },
                    { new Guid("ff21d764-ba2d-4cf5-a640-f9d300e835dc"), null, 3100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name31" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleName",
                table: "Users",
                column: "RoleName",
                principalTable: "Roles",
                principalColumn: "Name");
        }
    }
}
