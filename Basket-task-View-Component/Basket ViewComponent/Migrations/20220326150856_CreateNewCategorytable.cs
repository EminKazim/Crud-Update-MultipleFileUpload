using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket_ViewComponent.Migrations
{
    public partial class CreateNewCategorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "AroowIcon",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryIcon",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AroowIcon",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryIcon",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Count",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
