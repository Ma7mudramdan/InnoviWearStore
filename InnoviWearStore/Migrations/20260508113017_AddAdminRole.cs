using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnoviWearStore.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Color", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "Size", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Shirts", "Black", new DateTime(2026, 5, 5, 16, 12, 28, 118, DateTimeKind.Local).AddTicks(2551), "Comfortable cotton t-shirt", "/images/tshirt.jpg", "Classic T-Shirt", 29.99m, "M", 100 },
                    { 2, "Jeans", "Blue", new DateTime(2026, 5, 5, 16, 12, 28, 118, DateTimeKind.Local).AddTicks(2638), "Stylish slim fit denim jeans", "/images/jeans.jpg", "Slim Fit Jeans", 79.99m, "32", 50 },
                    { 3, "Jackets", "Red", new DateTime(2026, 5, 5, 16, 12, 28, 118, DateTimeKind.Local).AddTicks(2644), "Warm winter jacket", "/images/jacket.jpg", "Winter Jacket", 149.99m, "L", 30 },
                    { 4, "Shoes", "White", new DateTime(2026, 5, 5, 16, 12, 28, 118, DateTimeKind.Local).AddTicks(2649), "Lightweight running shoes", "/images/shoes.jpg", "Running Shoes", 89.99m, "42", 75 },
                    { 5, "Hoodies", "Gray", new DateTime(2026, 5, 5, 16, 12, 28, 118, DateTimeKind.Local).AddTicks(2652), "Soft cotton hoodie", "/images/hoodie.jpg", "Casual Hoodie", 59.99m, "XL", 60 },
                    { 6, "Accessories", "Brown", new DateTime(2026, 5, 5, 16, 12, 28, 118, DateTimeKind.Local).AddTicks(2656), "Genuine leather belt", "/images/belt.jpg", "Leather Belt", 39.99m, "M", 120 }
                });
        }
    }
}
