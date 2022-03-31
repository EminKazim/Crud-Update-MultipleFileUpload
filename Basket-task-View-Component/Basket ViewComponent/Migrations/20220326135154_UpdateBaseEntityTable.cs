using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket_ViewComponent.Migrations
{
    public partial class UpdateBaseEntityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDleted",
                table: "Sliders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDleted",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDleted",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDleted",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "IsDleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDleted",
                table: "Categories");
        }
    }
}
