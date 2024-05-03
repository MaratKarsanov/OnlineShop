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
            migrationBuilder.DropTable(
                name: "ComparisonProduct");

            migrationBuilder.DropTable(
                name: "FavouritesProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "ComparisonId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavouritesId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavouritesId", "ImageLink", "IsInComparison", "IsInFavourites", "Name" },
                values: new object[,]
                {
                    { new Guid("00c5d5df-1558-4e91-80a1-a8e3198d9ba4"), null, 8400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name84" },
                    { new Guid("01fba458-755e-4839-a559-a711adc59528"), null, 3400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name34" },
                    { new Guid("02184905-10c6-4830-a4d0-4d6e3b7fc644"), null, 4200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name42" },
                    { new Guid("0341c423-ceb6-4288-89a6-b989ec413e11"), null, 6200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name62" },
                    { new Guid("05899858-f220-4e5c-9716-ae0352a7536c"), null, 6800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name68" },
                    { new Guid("08dc8629-e526-43c6-9f42-3d15bd073ce2"), null, 9600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name96" },
                    { new Guid("0a99ea39-28b9-4121-a0f8-c0da2fdb6b14"), null, 5600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name56" },
                    { new Guid("0c88a881-5fbd-4910-88d8-0b2482b651db"), null, 1600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name16" },
                    { new Guid("0ca602d7-f87b-4708-854b-cfe4a84c3c23"), null, 8500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name85" },
                    { new Guid("0fa8734b-25b9-456c-be3d-d1c147bdcdb2"), null, 500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name5" },
                    { new Guid("105ffbe5-6938-447d-8932-55b9f087d89c"), null, 4400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name44" },
                    { new Guid("12518a4a-825d-47a3-9abd-cbeca85afa9e"), null, 9100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name91" },
                    { new Guid("141370de-0dea-42b7-94fa-96f5e77880d6"), null, 3900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name39" },
                    { new Guid("19b76339-d173-4240-8b46-b0da5f6f6a04"), null, 2300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name23" },
                    { new Guid("1b62a685-1687-4721-92b8-59feb13119ed"), null, 200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name2" },
                    { new Guid("1fc404ef-dbf6-459f-bdae-adea19ed4187"), null, 3500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name35" },
                    { new Guid("2446ae26-0bbf-4dd4-a629-b07a0c94bee6"), null, 6600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name66" },
                    { new Guid("247e7349-e03d-4c89-b680-5199e8aa3286"), null, 100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name1" },
                    { new Guid("25614a32-551f-4d27-8c71-492a954577c6"), null, 9200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name92" },
                    { new Guid("2a9fa0ab-ec44-47c2-8b5a-16993582613d"), null, 5900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name59" },
                    { new Guid("30692f39-d8ef-4979-a27d-f43d2c995503"), null, 8100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name81" },
                    { new Guid("33472187-23ad-4308-b523-c9242eeb21ce"), null, 2900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name29" },
                    { new Guid("33a338b5-68b4-4e8b-b872-9a2e11de4a32"), null, 9500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name95" },
                    { new Guid("33b0ffd6-9d07-4bbb-bd2c-d6c633904aa2"), null, 9800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name98" },
                    { new Guid("34d450d5-038c-4ed6-b527-8ea380b1d90f"), null, 6400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name64" },
                    { new Guid("357b726e-a80c-4fa2-a9bc-c3109a7e4eee"), null, 9700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name97" },
                    { new Guid("36b32d25-5565-4a20-959b-5f42ae2231b7"), null, 3600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name36" },
                    { new Guid("3a664fb8-fc86-4b69-b096-04b9fcfe3e6d"), null, 1400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name14" },
                    { new Guid("41da35f2-83a9-4ad1-92fb-a181df753229"), null, 1700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name17" },
                    { new Guid("44033022-5967-4546-97cf-a8f83c577950"), null, 7200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name72" },
                    { new Guid("478284bf-b12f-4fce-9f3e-6e65eafae10a"), null, 7400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name74" },
                    { new Guid("5333831f-0c07-43ae-8ec5-1d098ae4c3f7"), null, 4300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name43" },
                    { new Guid("53d01021-3ed1-4b56-8f85-3112a02141df"), null, 1100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name11" },
                    { new Guid("54c47ce9-0666-4fbd-848d-bd367127bfcb"), null, 5000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name50" },
                    { new Guid("571d09da-6d2f-493b-b79e-6d137bfe9ab0"), null, 900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name9" },
                    { new Guid("5911f8a2-be2d-43f0-a1b5-3d41f72822f2"), null, 400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name4" },
                    { new Guid("5a18097a-6517-4907-b9e0-8886b14caa68"), null, 800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name8" },
                    { new Guid("5a9f014f-a0e0-4ea1-bbfb-15437069154c"), null, 7100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name71" },
                    { new Guid("5e86c253-322e-43ca-bd19-79575c014f14"), null, 7500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name75" },
                    { new Guid("603fd36b-7d1d-4b7a-abdd-aabc426b99f9"), null, 6000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name60" },
                    { new Guid("620f911a-6360-4e37-9987-792639178ae9"), null, 7000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name70" },
                    { new Guid("67cf7a1a-f678-4dce-abd5-9f5afb395389"), null, 9300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name93" },
                    { new Guid("6909ac94-2036-41ed-927f-6406224bade6"), null, 2400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name24" },
                    { new Guid("6aeebbc1-0338-4fbc-934b-fa58ba158bde"), null, 2700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name27" },
                    { new Guid("6bffd4f9-3131-4591-b17c-c46363608acb"), null, 5700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name57" },
                    { new Guid("7110c3cb-4e7e-4c49-a06f-c89f052a51e7"), null, 8700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name87" },
                    { new Guid("746b1a71-f793-40e2-98a5-f4b935c9cefd"), null, 3200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name32" },
                    { new Guid("76a343dd-92e9-48af-baa0-5b8d08a48e84"), null, 3100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name31" },
                    { new Guid("7796ce58-6073-4310-908c-243054bcd5ce"), null, 4600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name46" },
                    { new Guid("786174d5-70c1-4223-a13c-db7281acd1ee"), null, 2500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name25" },
                    { new Guid("7beed880-34dc-4d41-addb-0a0d8b5430dc"), null, 2800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name28" },
                    { new Guid("7d2f72fb-5e27-495b-89f8-9159ed139623"), null, 3700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name37" },
                    { new Guid("7dc65c0a-15ea-45e1-a448-808218949257"), null, 300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name3" },
                    { new Guid("7e6afdb1-c822-4dbb-a644-0c673d6492c7"), null, 5300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name53" },
                    { new Guid("814de527-e838-4e55-b3b1-baaef5d99b9f"), null, 8800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name88" },
                    { new Guid("86b8d4f5-5ca9-4b6f-b64e-fd9bcafc02ea"), null, 4700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name47" },
                    { new Guid("87d0c5e2-89fb-4d64-8764-e2e5421b861e"), null, 5100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name51" },
                    { new Guid("88a9df97-ef89-4659-aec2-2f332546d59b"), null, 6100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name61" },
                    { new Guid("88b19c94-5945-4050-8111-a4a063998b9b"), null, 1000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name10" },
                    { new Guid("8af7f3d3-1af3-419c-b887-7159e41532de"), null, 4000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name40" },
                    { new Guid("901766e2-bdbb-43dd-a7f6-43046c3806a4"), null, 2100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name21" },
                    { new Guid("928a997b-af78-4634-8be9-8b203083ec5e"), null, 4100m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name41" },
                    { new Guid("93248196-9306-43c7-9e9f-b5c627079fd3"), null, 5500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name55" },
                    { new Guid("93cafc22-f80a-4685-970f-3be33a630197"), null, 4900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name49" },
                    { new Guid("943bc3f6-c69b-4e30-be3b-a2adb5e66380"), null, 1800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name18" },
                    { new Guid("973bdaa6-da5e-4ead-8e83-75f624f75ec5"), null, 1200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name12" },
                    { new Guid("9aef0c97-f878-4a4e-a299-1017be828f15"), null, 9400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name94" },
                    { new Guid("9f2f99f7-384c-4e9b-97c3-5707104fe2fc"), null, 6300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name63" },
                    { new Guid("a185e8d1-3bbf-4438-8b2f-241f5a0e48a5"), null, 7800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name78" },
                    { new Guid("a23d8916-65e8-4aa5-87e0-ad1b2c2d0d52"), null, 7300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name73" },
                    { new Guid("ad0146c2-7892-45f9-850c-ff6dd09dcb55"), null, 2000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name20" },
                    { new Guid("b36f624a-b346-43ff-966e-e47877ba5a58"), null, 9900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name99" },
                    { new Guid("b697730a-886a-4801-a68e-845bdfd6b969"), null, 4800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name48" },
                    { new Guid("b94671ab-d07b-487f-be7b-7aac473017df"), null, 7600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name76" },
                    { new Guid("baa88f6d-b8be-45e8-b818-a4f750ad3ce6"), null, 6500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name65" },
                    { new Guid("bfcdc284-605d-4a19-90f9-2212a696e9f1"), null, 1300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name13" },
                    { new Guid("c1899ec1-fdf6-4243-9fe4-faebad848845"), null, 8200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name82" },
                    { new Guid("c1cb0f00-da9a-4e2a-8cfe-bdef329bb955"), null, 2200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name22" },
                    { new Guid("c878ec42-5448-4e4e-8108-9398e658059e"), null, 7700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name77" },
                    { new Guid("ca9e436d-2b15-4ea0-ad1f-dca3aeccbf90"), null, 700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name7" },
                    { new Guid("cbdc98b3-8c07-4982-8aee-31922c75600d"), null, 5200m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name52" },
                    { new Guid("cdead5c4-4b6a-40e5-9b60-ec70813847f4"), null, 2600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name26" },
                    { new Guid("d30d1238-c2dd-48b5-8d1c-7dca5c278091"), null, 1900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name19" },
                    { new Guid("d4270b06-02f1-4f61-9f59-21414aaa7f03"), null, 3300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name33" },
                    { new Guid("d8d62579-f1c2-4c2e-8e16-65b844c975fc"), null, 8900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name89" },
                    { new Guid("db188e0b-3e31-4ad8-87a2-bb370d528d9d"), null, 6900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name69" },
                    { new Guid("dc09221e-ed43-4171-a28d-c97427569832"), null, 5400m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name54" },
                    { new Guid("dd25733e-6b1a-43c2-be83-fb7b70264590"), null, 9000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name90" },
                    { new Guid("e605968d-ca69-4cc3-bacb-631789e09c31"), null, 3000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name30" },
                    { new Guid("e88d279a-3db7-4c25-9320-97779df110ed"), null, 5800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name58" },
                    { new Guid("eb53c021-cd2e-4235-bfeb-67827bf16111"), null, 600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name6" },
                    { new Guid("ecbf9abf-f23e-49e5-a763-d8f257bdee91"), null, 1500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name15" },
                    { new Guid("edbf94be-9add-4afb-bc92-f6eb0ea8410c"), null, 7900m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name79" },
                    { new Guid("ee161f74-bb51-494e-ba58-aaf72dd548ca"), null, 8000m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name80" },
                    { new Guid("f1997bfb-3422-4b6a-9a7b-bc94b208e202"), null, 3800m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name38" },
                    { new Guid("f1d687fe-5155-4b03-bb93-f4e81d701494"), null, 8600m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name86" },
                    { new Guid("f4fc5700-bcf3-454d-b499-d6afed89ba4c"), null, 4500m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name45" },
                    { new Guid("f53b2ad3-4b36-499f-b541-34acb6d52efc"), null, 0m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name0" },
                    { new Guid("f5d19160-a35b-40b2-875e-fdd27ddd2e64"), null, 6700m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name67" },
                    { new Guid("f5d8a75a-4fff-4c8f-ac33-b873c084b0d6"), null, 8300m, "Very good product!", null, "/images/DefaultImg.jpg", false, false, "Name83" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00c5d5df-1558-4e91-80a1-a8e3198d9ba4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("01fba458-755e-4839-a559-a711adc59528"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02184905-10c6-4830-a4d0-4d6e3b7fc644"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0341c423-ceb6-4288-89a6-b989ec413e11"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("05899858-f220-4e5c-9716-ae0352a7536c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("08dc8629-e526-43c6-9f42-3d15bd073ce2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a99ea39-28b9-4121-a0f8-c0da2fdb6b14"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c88a881-5fbd-4910-88d8-0b2482b651db"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ca602d7-f87b-4708-854b-cfe4a84c3c23"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fa8734b-25b9-456c-be3d-d1c147bdcdb2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("105ffbe5-6938-447d-8932-55b9f087d89c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("12518a4a-825d-47a3-9abd-cbeca85afa9e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("141370de-0dea-42b7-94fa-96f5e77880d6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("19b76339-d173-4240-8b46-b0da5f6f6a04"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b62a685-1687-4721-92b8-59feb13119ed"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1fc404ef-dbf6-459f-bdae-adea19ed4187"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2446ae26-0bbf-4dd4-a629-b07a0c94bee6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("247e7349-e03d-4c89-b680-5199e8aa3286"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("25614a32-551f-4d27-8c71-492a954577c6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2a9fa0ab-ec44-47c2-8b5a-16993582613d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30692f39-d8ef-4979-a27d-f43d2c995503"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33472187-23ad-4308-b523-c9242eeb21ce"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33a338b5-68b4-4e8b-b872-9a2e11de4a32"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33b0ffd6-9d07-4bbb-bd2c-d6c633904aa2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("34d450d5-038c-4ed6-b527-8ea380b1d90f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("357b726e-a80c-4fa2-a9bc-c3109a7e4eee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36b32d25-5565-4a20-959b-5f42ae2231b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a664fb8-fc86-4b69-b096-04b9fcfe3e6d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("41da35f2-83a9-4ad1-92fb-a181df753229"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44033022-5967-4546-97cf-a8f83c577950"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("478284bf-b12f-4fce-9f3e-6e65eafae10a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5333831f-0c07-43ae-8ec5-1d098ae4c3f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("53d01021-3ed1-4b56-8f85-3112a02141df"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("54c47ce9-0666-4fbd-848d-bd367127bfcb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("571d09da-6d2f-493b-b79e-6d137bfe9ab0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5911f8a2-be2d-43f0-a1b5-3d41f72822f2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5a18097a-6517-4907-b9e0-8886b14caa68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5a9f014f-a0e0-4ea1-bbfb-15437069154c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5e86c253-322e-43ca-bd19-79575c014f14"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("603fd36b-7d1d-4b7a-abdd-aabc426b99f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("620f911a-6360-4e37-9987-792639178ae9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("67cf7a1a-f678-4dce-abd5-9f5afb395389"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6909ac94-2036-41ed-927f-6406224bade6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6aeebbc1-0338-4fbc-934b-fa58ba158bde"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6bffd4f9-3131-4591-b17c-c46363608acb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7110c3cb-4e7e-4c49-a06f-c89f052a51e7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("746b1a71-f793-40e2-98a5-f4b935c9cefd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("76a343dd-92e9-48af-baa0-5b8d08a48e84"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7796ce58-6073-4310-908c-243054bcd5ce"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("786174d5-70c1-4223-a13c-db7281acd1ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7beed880-34dc-4d41-addb-0a0d8b5430dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d2f72fb-5e27-495b-89f8-9159ed139623"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7dc65c0a-15ea-45e1-a448-808218949257"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e6afdb1-c822-4dbb-a644-0c673d6492c7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("814de527-e838-4e55-b3b1-baaef5d99b9f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86b8d4f5-5ca9-4b6f-b64e-fd9bcafc02ea"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("87d0c5e2-89fb-4d64-8764-e2e5421b861e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("88a9df97-ef89-4659-aec2-2f332546d59b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("88b19c94-5945-4050-8111-a4a063998b9b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8af7f3d3-1af3-419c-b887-7159e41532de"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("901766e2-bdbb-43dd-a7f6-43046c3806a4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("928a997b-af78-4634-8be9-8b203083ec5e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93248196-9306-43c7-9e9f-b5c627079fd3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93cafc22-f80a-4685-970f-3be33a630197"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("943bc3f6-c69b-4e30-be3b-a2adb5e66380"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("973bdaa6-da5e-4ead-8e83-75f624f75ec5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9aef0c97-f878-4a4e-a299-1017be828f15"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f2f99f7-384c-4e9b-97c3-5707104fe2fc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a185e8d1-3bbf-4438-8b2f-241f5a0e48a5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a23d8916-65e8-4aa5-87e0-ad1b2c2d0d52"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad0146c2-7892-45f9-850c-ff6dd09dcb55"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b36f624a-b346-43ff-966e-e47877ba5a58"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b697730a-886a-4801-a68e-845bdfd6b969"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b94671ab-d07b-487f-be7b-7aac473017df"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("baa88f6d-b8be-45e8-b818-a4f750ad3ce6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bfcdc284-605d-4a19-90f9-2212a696e9f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c1899ec1-fdf6-4243-9fe4-faebad848845"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c1cb0f00-da9a-4e2a-8cfe-bdef329bb955"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c878ec42-5448-4e4e-8108-9398e658059e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca9e436d-2b15-4ea0-ad1f-dca3aeccbf90"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cbdc98b3-8c07-4982-8aee-31922c75600d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cdead5c4-4b6a-40e5-9b60-ec70813847f4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d30d1238-c2dd-48b5-8d1c-7dca5c278091"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4270b06-02f1-4f61-9f59-21414aaa7f03"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d8d62579-f1c2-4c2e-8e16-65b844c975fc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db188e0b-3e31-4ad8-87a2-bb370d528d9d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dc09221e-ed43-4171-a28d-c97427569832"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd25733e-6b1a-43c2-be83-fb7b70264590"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e605968d-ca69-4cc3-bacb-631789e09c31"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e88d279a-3db7-4c25-9320-97779df110ed"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb53c021-cd2e-4235-bfeb-67827bf16111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ecbf9abf-f23e-49e5-a763-d8f257bdee91"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("edbf94be-9add-4afb-bc92-f6eb0ea8410c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ee161f74-bb51-494e-ba58-aaf72dd548ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1997bfb-3422-4b6a-9a7b-bc94b208e202"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1d687fe-5155-4b03-bb93-f4e81d701494"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f4fc5700-bcf3-454d-b499-d6afed89ba4c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f53b2ad3-4b36-499f-b541-34acb6d52efc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f5d19160-a35b-40b2-875e-fdd27ddd2e64"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f5d8a75a-4fff-4c8f-ac33-b873c084b0d6"));

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
                    ComparisonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    FavouritesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
    }
}
