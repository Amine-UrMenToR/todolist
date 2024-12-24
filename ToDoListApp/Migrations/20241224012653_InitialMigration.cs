using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 12, 31, 2, 26, 53, 119, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2025, 1, 7, 2, 26, 53, 123, DateTimeKind.Local).AddTicks(1591));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 12, 31, 2, 24, 13, 356, DateTimeKind.Local).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2025, 1, 7, 2, 24, 13, 358, DateTimeKind.Local).AddTicks(9933));
        }
    }
}
