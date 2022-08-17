using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ccog3nt_product_Management_4._0.Data.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                        //.Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: true),
                    OrderSKU = table.Column<int>(nullable: false),
                    OrderProductId = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UnitsPerCase = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "ImportDate", "ModifiedDate", "OrderProductId", "ProductID", "ProductName", "OrderSKU", "UnitsPerCase" },
                values: new object[,]
                {
                    { 37, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 37, "Pork Bangers 500 g", 20000370, 4 },
                    { 55, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 55, "Ext Strong Black Tea", 20003067, 6 },
                    { 54, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 54, "English Breakfast Te", 20003319, 6 },
                    { 52, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 52, "Sev Orange Marmalade", 20003067, 12 },
                    { 51, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 51, "Apricot Jam Jar 340", 20003050, 12 },
                    { 50, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 50, "Straw Jam Jar 340 g", 20003036, 12 },
                    { 49, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 49, "Tomato Soup 400 g", 20002718, 12 },
                    { 48, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 48, "WW Beans Tom Sauce", 20002480, 12 },
                    { 47, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 47, "Ccnut Mmallows 150 g", 20001209, 40 },
                    { 46, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 46, "Liq Allsorts 125 g", 200001056, 40 },
                    { 45, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 45, "Cran Mac Ngt 100 g", 200001056, 12 },
                    { 44, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 44, "Soft Eating Gum 125g", 200001025, 40 },
                    { 43, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 43, "Pecan Cashew 100 g", 20001018, 12 },
                    { 42, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 42, "Chuckles Peanut 150g", 20000974, 30 },
                    { 41, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 41, "Chuckles Peanut 150g", 20000967, 48 },
                    { 40, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 40, "Chuckles Peanut 150g", 20000950, 30 },
                    { 39, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 39, "Chuckles Peanut 150g", 20000943, 30 },
                    { 38, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 38, "BF Bangers", 20000400, 2 },
                    { 56, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, 56, "Breakfst Ground 250g", 20003357, 8 },
                    { 57, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 57, "Sunflower Oil 750ml", 20003388, 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
