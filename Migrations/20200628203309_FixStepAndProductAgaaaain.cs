using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class FixStepAndProductAgaaaain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_step_step_id",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "step_id",
                table: "product",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_product_step_step_id",
                table: "product",
                column: "step_id",
                principalTable: "step",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_step_step_id",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "step_id",
                table: "product",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "fk_product_step_step_id",
                table: "product",
                column: "step_id",
                principalTable: "step",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
