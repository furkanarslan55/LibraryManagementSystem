using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 19, 15, 4, 50, 599, DateTimeKind.Local).AddTicks(5205), "Bilim Kurgu" },
                    { 2, new DateTime(2026, 1, 19, 15, 4, 50, 599, DateTimeKind.Local).AddTicks(5210), "Dünya Klasikleri" },
                    { 3, new DateTime(2026, 1, 19, 15, 4, 50, 599, DateTimeKind.Local).AddTicks(5213), "Kişisel Gelişim" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 19, 15, 4, 50, 599, DateTimeKind.Local).AddTicks(2676), 250m, "Dune" },
                    { 2, 2, new DateTime(2026, 1, 19, 15, 4, 50, 599, DateTimeKind.Local).AddTicks(2689), 180m, "Suç ve Ceza" },
                    { 3, 3, new DateTime(2026, 1, 19, 15, 4, 50, 599, DateTimeKind.Local).AddTicks(2692), 200m, "Atomik Alışkanlıklar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
