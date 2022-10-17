using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCard.DataAcess.Migrations
{
    public partial class AddingOrderPropertyInCategoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Categories");
        }
    }
}
