using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecomm.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DisplayOrder", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 17, 13, 6, 14, 736, DateTimeKind.Local).AddTicks(5040), 1, "Samsung" },
                    { 2, new DateTime(2024, 3, 17, 13, 6, 14, 736, DateTimeKind.Local).AddTicks(5055), 2, "Xiomi" },
                    { 3, new DateTime(2024, 3, 17, 13, 6, 14, 736, DateTimeKind.Local).AddTicks(5057), 3, "Nokia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
