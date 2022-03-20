using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoEshop.Migrations
{
    public partial class MySQL_1_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeCreated",
                table: "OrderItem",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Carousels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "Carousels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeCreated",
                table: "OrderItem",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "NOW()");
        }
    }
}
