using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAt_ToPostComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 17, 1, 5, 14, 634, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 16, 1, 5, 14, 634, DateTimeKind.Local).AddTicks(4998));
        }
    }
}
