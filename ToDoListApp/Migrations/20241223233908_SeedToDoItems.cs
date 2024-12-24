using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedToDoItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { 1, "This is a sample description", new DateTime(2024, 12, 31, 0, 39, 8, 309, DateTimeKind.Local).AddTicks(2979), false, "Sample Task 1" },
                    { 2, "This is another sample description", new DateTime(2025, 1, 7, 0, 39, 8, 311, DateTimeKind.Local).AddTicks(5117), true, "Sample Task 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
