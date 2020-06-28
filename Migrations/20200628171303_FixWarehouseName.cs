using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class FixWarehouseName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "warehouse",
                table: "stock_wine");

            migrationBuilder.DropColumn(
                name: "warehouse",
                table: "stock_product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "warehouse",
                table: "stock_wine",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "warehouse",
                table: "stock_product",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
