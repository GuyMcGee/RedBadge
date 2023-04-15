using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Redbadge.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserIdNullableonResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "783454a2-1a07-4aac-b213-0d6db198e12e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c9e5996-4f98-479a-b11b-850c5771ee6d", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 37, 43, 72, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 37, 43, 72, DateTimeKind.Local).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 37, 43, 72, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 37, 43, 72, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 37, 43, 72, DateTimeKind.Local).AddTicks(6315));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c9e5996-4f98-479a-b11b-850c5771ee6d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "783454a2-1a07-4aac-b213-0d6db198e12e", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 30, 25, 825, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 30, 25, 825, DateTimeKind.Local).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 30, 25, 825, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 30, 25, 825, DateTimeKind.Local).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 30, 25, 825, DateTimeKind.Local).AddTicks(7645));
        }
    }
}
