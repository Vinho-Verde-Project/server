using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class FixStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_stock_employee_employee_id",
                table: "stock");

            migrationBuilder.DropIndex(
                name: "ix_stock_employee_id",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "qantity",
                table: "stock_product");

            migrationBuilder.DropColumn(
                name: "employee_id",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "entry_date",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "warehouse",
                table: "stock");

            migrationBuilder.AddColumn<int>(
                name: "employee_id",
                table: "stock_wine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "entry_date",
                table: "stock_wine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "quantity",
                table: "stock_wine",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "warehouse",
                table: "stock_wine",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "employee_id",
                table: "stock_product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "entry_date",
                table: "stock_product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "quantity",
                table: "stock_product",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "warehouse",
                table: "stock_product",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "stock",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_stock_wine_employee_id",
                table: "stock_wine",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_product_employee_id",
                table: "stock_product",
                column: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "fk_stock_product_employee_employee_id",
                table: "stock_product",
                column: "employee_id",
                principalTable: "employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stock_wine_employee_employee_id",
                table: "stock_wine",
                column: "employee_id",
                principalTable: "employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_stock_product_employee_employee_id",
                table: "stock_product");

            migrationBuilder.DropForeignKey(
                name: "fk_stock_wine_employee_employee_id",
                table: "stock_wine");

            migrationBuilder.DropIndex(
                name: "ix_stock_wine_employee_id",
                table: "stock_wine");

            migrationBuilder.DropIndex(
                name: "ix_stock_product_employee_id",
                table: "stock_product");

            migrationBuilder.DropColumn(
                name: "employee_id",
                table: "stock_wine");

            migrationBuilder.DropColumn(
                name: "entry_date",
                table: "stock_wine");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "stock_wine");

            migrationBuilder.DropColumn(
                name: "warehouse",
                table: "stock_wine");

            migrationBuilder.DropColumn(
                name: "employee_id",
                table: "stock_product");

            migrationBuilder.DropColumn(
                name: "entry_date",
                table: "stock_product");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "stock_product");

            migrationBuilder.DropColumn(
                name: "warehouse",
                table: "stock_product");

            migrationBuilder.DropColumn(
                name: "title",
                table: "stock");

            migrationBuilder.AddColumn<double>(
                name: "qantity",
                table: "stock_product",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "employee_id",
                table: "stock",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "entry_date",
                table: "stock",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "warehouse",
                table: "stock",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_stock_employee_id",
                table: "stock",
                column: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "fk_stock_employee_employee_id",
                table: "stock",
                column: "employee_id",
                principalTable: "employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
