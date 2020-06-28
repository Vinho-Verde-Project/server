using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class VaiCarai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_step_product_product_id",
                table: "step");

            migrationBuilder.AlterColumn<int>(
                name: "product_id",
                table: "step",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_step_product_product_id",
                table: "step",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_step_product_product_id",
                table: "step");

            migrationBuilder.AlterColumn<int>(
                name: "product_id",
                table: "step",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "fk_step_product_product_id",
                table: "step",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
