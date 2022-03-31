using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket_ViewComponent.Migrations
{
    public partial class CreateNavCategoryTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "navCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryIcon = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ArrowIcon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_navCategories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoryTypes");

            migrationBuilder.DropTable(
                name: "navCategories");
        }
    }
}
