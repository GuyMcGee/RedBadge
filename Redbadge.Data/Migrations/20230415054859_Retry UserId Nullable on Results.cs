using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Redbadge.Data.Migrations
{
    /// <inheritdoc />
    public partial class RetryUserIdNullableonResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualResults_AspNetUsers_UserId",
                table: "IndividualResults");

            migrationBuilder.DropIndex(
                name: "IX_IndividualResults_UserId",
                table: "IndividualResults");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c9e5996-4f98-479a-b11b-850c5771ee6d");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "IndividualResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "IndividualResults",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "306dc6cf-cf53-4b8a-a4e8-5fec3520e910", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 48, 59, 4, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 48, 59, 4, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 48, 59, 4, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 48, 59, 4, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "Occasion",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2023, 4, 15, 1, 48, 59, 4, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.CreateIndex(
                name: "IX_IndividualResults_AppUserId",
                table: "IndividualResults",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualResults_AspNetUsers_AppUserId",
                table: "IndividualResults",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualResults_AspNetUsers_AppUserId",
                table: "IndividualResults");

            migrationBuilder.DropIndex(
                name: "IX_IndividualResults_AppUserId",
                table: "IndividualResults");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "306dc6cf-cf53-4b8a-a4e8-5fec3520e910");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "IndividualResults");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "IndividualResults",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_IndividualResults_UserId",
                table: "IndividualResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualResults_AspNetUsers_UserId",
                table: "IndividualResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
