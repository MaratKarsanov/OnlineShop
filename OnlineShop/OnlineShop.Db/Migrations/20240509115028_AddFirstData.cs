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

            migrationBuilder.InsertData(
                table: "Roles",
                column: "Name",
                values: new object[]
                {
                    "Administrator",
                    "User"
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Name",
                keyValue: "Administrator");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Name",
                keyValue: "User");
        }
    }
}
