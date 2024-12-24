using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class CaptureAllChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 12, 31, 0, 43, 12, 243, DateTimeKind.Local).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2025, 1, 7, 0, 43, 12, 245, DateTimeKind.Local).AddTicks(7781));
        }
    }
}
