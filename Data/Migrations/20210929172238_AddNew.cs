using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ccog3nt_product_Management_4._0.Data.Migrations
{
    public partial class AddNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 60,
                columns: new[] { "ProductName", "OrderSKU" },
                values: new object[] { "W.Lab Lime DWL", 20003784 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 61,
                columns: new[] { "ProductName", "OrderSKU" },
                values: new object[] { "English Cucumber", 20004019 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 62,
                columns: new[] { "ProductName", "OrderSKU" },
                values: new object[] { "Mini Cucumbers", 20004057 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 63,
                columns: new[] { "ProductName", "OrderSKU" },
                values: new object[] { "Iceberg Lettuce Head", 20004071 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "ImportDate", "ModifiedDate", "OrderProductId", "ProductID", "ProductName", "OrderSKU", "UnitsPerCase" },
                values: new object[,]
                {
                    { 64, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 64, "Celery Whole 400g", 20004194, 12 },
                    { 65, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 65, "Celery Fingers", 20004200, 6 },
                    { 66, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 66, "Parsley 30g", 20004255, 14 },
                    { 67, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 67, "Avocado 4 Punnet", 20004323, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 60,
                columns: new[] { "ProductName", "OrderSKU" },
                values: new object[] { "English Cucumber", 20003319 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 61,
                columns: new[] { "ProductName", "OrderSKU" },
                values: new object[] { "Mini Cucumbers", 20003067 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 62,
                columns: new[] { "ProductName", "OrderSKU" },
                values: new object[] { "Iceberg Lettuce Head", 20003357 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 63,
                columns: new[] { "ProductName", "OrderSKU" },
                values: new object[] { "Celery Whole 400g", 20003388 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "ImportDate", "ModifiedDate", "OrderProductId", "ProductID", "ProductName", "OrderSKU", "UnitsPerCase" },
                values: new object[] { 59, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 59, "W.Lab Lime DWL", 20003067, 12 });
        }
    }
}
