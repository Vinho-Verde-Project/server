using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class StepWithOnlyOneProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_step_step_id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "ix_product_step_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "step_id",
                table: "product");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "step",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_step_product_id",
                table: "step",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "fk_step_product_product_id",
                table: "step",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_step_product_product_id",
                table: "step");

            migrationBuilder.DropIndex(
                name: "ix_step_product_id",
                table: "step");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "step");

            migrationBuilder.AddColumn<int>(
                name: "step_id",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_product_step_id",
                table: "product",
                column: "step_id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_step_step_id",
                table: "product",
                column: "step_id",
                principalTable: "step",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
