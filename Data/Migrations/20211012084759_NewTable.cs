using Microsoft.EntityFrameworkCore.Migrations;

namespace Ccog3nt_product_Management_4._0.Data.Migrations
{
    public partial class NewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClusteredProducts",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                       /* .Annotation("SqlServer:Identity", "1, 1")*/
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusteredProducts", x => x.ProductID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClusteredProducts");
        }
    }
}
