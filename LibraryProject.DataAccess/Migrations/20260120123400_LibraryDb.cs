using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LibraryDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 20, 15, 33, 59, 923, DateTimeKind.Local).AddTicks(935), "J.K.", "Rowling" },
                    { 2, new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 20, 15, 33, 59, 923, DateTimeKind.Local).AddTicks(953), "George", "Orwell" },
                    { 3, new DateTime(1821, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 20, 15, 33, 59, 923, DateTimeKind.Local).AddTicks(956), "Fyodor", "Dostoyevski" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 20, 15, 33, 59, 923, DateTimeKind.Local).AddTicks(9575), "Bilim Kurgu" },
                    { 2, new DateTime(2026, 1, 20, 15, 33, 59, 923, DateTimeKind.Local).AddTicks(9582), "Dünya Klasikleri" },
                    { 3, new DateTime(2026, 1, 20, 15, 33, 59, 923, DateTimeKind.Local).AddTicks(9585), "Kişisel Gelişim" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 1, 20, 15, 33, 59, 923, DateTimeKind.Local).AddTicks(5794), 250m, "Dune" },
                    { 2, 2, 2, new DateTime(2026, 1, 20, 15, 33, 59, 923, DateTimeKind.Local).AddTicks(5805), 180m, "Suç ve Ceza" },
                    { 3, 3, 3, new DateTime(2026, 1, 20, 15, 33, 59, 923, DateTimeKind.Local).AddTicks(5809), 200m, "Atomik Alışkanlıklar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
