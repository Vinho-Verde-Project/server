using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class CorrectStepProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "min_qantity",
                table: "stock_product",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "stock_id",
                table: "product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_product_stock_id",
                table: "product",
                column: "stock_id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_stock_stock_id",
                table: "product",
                column: "stock_id",
                principalTable: "stock",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_stock_stock_id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "ix_product_stock_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "stock_id",
                table: "product");

            migrationBuilder.AlterColumn<float>(
                name: "min_qantity",
                table: "stock_product",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
