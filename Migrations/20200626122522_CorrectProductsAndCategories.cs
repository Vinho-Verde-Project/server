using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class CorrectProductsAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_step_step_id",
                table: "product");

            migrationBuilder.DropTable(
                name: "product_category");

            migrationBuilder.AlterColumn<string>(
                name: "shelf_life",
                table: "wine",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "production_date",
                table: "wine",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<double>(
                name: "quantity",
                table: "stock",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "quantity",
                table: "step",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "step_id",
                table: "product",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_product_step_step_id",
                table: "product",
                column: "step_id",
                principalTable: "step",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_step_step_id",
                table: "product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "shelf_life",
                table: "wine",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "production_date",
                table: "wine",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<float>(
                name: "quantity",
                table: "stock",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "quantity",
                table: "step",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "step_id",
                table: "product",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "product_category",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_category", x => new { x.product_id, x.category_id });
                    table.ForeignKey(
                        name: "fk_product_category_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_category_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_product_category_category_id",
                table: "product_category",
                column: "category_id");

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
