using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Core.Migrations
{
    public partial class ModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Product");
        }
    }
}
