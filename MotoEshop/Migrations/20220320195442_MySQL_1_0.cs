﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoEshop.Migrations
{
    public partial class MySQL_1_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carousels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DataTarget = table.Column<string>(nullable: false),
                    ImageSrc = table.Column<string>(maxLength: 255, nullable: false),
                    ImageAlt = table.Column<string>(maxLength: 25, nullable: false),
                    CarouselContent = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    OrderNumber = table.Column<string>(maxLength: 25, nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ProductName = table.Column<string>(nullable: false),
                    ImageSrc = table.Column<string>(maxLength: 225, nullable: false),
                    ImageAlt = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductID",
                table: "OrderItem",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousels");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
