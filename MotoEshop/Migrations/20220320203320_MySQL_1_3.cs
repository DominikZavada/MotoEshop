using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoEshop.Migrations
{
    public partial class MySQL_1_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Order",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Order",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "NOW()");
        }
    }
}
