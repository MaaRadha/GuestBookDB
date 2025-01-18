using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackWebApi.Migrations
{
    /// <inheritdoc />
    public partial class max_length_content_fullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "PostComments",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 17, 2, 31, 22, 616, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 16, 2, 31, 22, 616, DateTimeKind.Local).AddTicks(6154));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "PostComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 17, 1, 39, 51, 368, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 16, 1, 39, 51, 368, DateTimeKind.Local).AddTicks(2255));
        }
    }
}
