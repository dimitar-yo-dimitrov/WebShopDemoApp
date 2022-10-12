using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Core.Migrations
{
    public partial class ChangeToSecondDigit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Product price",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldComment: "Product price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,4)",
                nullable: false,
                comment: "Product price",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Product price");
        }
    }
}
