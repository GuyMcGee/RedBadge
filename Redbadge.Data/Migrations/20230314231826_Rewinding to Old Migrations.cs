using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Redbadge.Data.Migrations
{
    /// <inheritdoc />
    public partial class RewindingtoOldMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Occasion",
                columns: new[] { "Id", "DateTime", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 14, 19, 18, 26, 330, DateTimeKind.Local).AddTicks(7313), "Bryan's Bachelor Party" },
                    { 2, new DateTime(2023, 3, 14, 19, 18, 26, 330, DateTimeKind.Local).AddTicks(7352), "That one time at Kyle's house" },
                    { 3, new DateTime(2023, 3, 14, 19, 18, 26, 330, DateTimeKind.Local).AddTicks(7355), "August 13th, 1998" },
                    { 4, new DateTime(2023, 3, 14, 19, 18, 26, 330, DateTimeKind.Local).AddTicks(7357), "2004 Xmas Party" },
                    { 5, new DateTime(2023, 3, 14, 19, 18, 26, 330, DateTimeKind.Local).AddTicks(7361), "07/04/2021" }
                });

            migrationBuilder.InsertData(
                table: "Rank",
                columns: new[] { "Id", "RankName" },
                values: new object[,]
                {
                    { 1, "Winner" },
                    { 2, "Loser" },
                    { 3, "Gold" },
                    { 4, "Silver" },
                    { 5, "Bronze" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rank",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rank",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rank",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rank",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rank",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
