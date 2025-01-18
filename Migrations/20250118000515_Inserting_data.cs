using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeedBackWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Inserting_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PostComments",
                columns: new[] { "Id", "Content", "CreatedAt", "FullName" },
                values: new object[,]
                {
                    { 1, "Keep going", new DateTime(2025, 1, 17, 1, 5, 14, 634, DateTimeKind.Local).AddTicks(4953), "Astri05" },
                    { 2, "Looks ok but more things i can see to work on ", new DateTime(2025, 1, 16, 1, 5, 14, 634, DateTimeKind.Local).AddTicks(4998), "Martin" }
                });

            migrationBuilder.InsertData(
                table: "PostReactions",
                columns: new[] { "Id", "Dislikes", "Hearts", "Likes", "PostCommentId" },
                values: new object[,]
                {
                    { 1, 0, 0, 1, 2 },
                    { 2, 0, 0, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostComments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
