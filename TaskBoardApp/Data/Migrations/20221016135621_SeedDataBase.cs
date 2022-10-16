using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bbf01137-6ee1-4067-ace6-a47d929208ae", 0, "7a93fe84-4d1b-4006-b342-fcf981938573", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEL6aG5p2wSggmwhEA+j4/rB1K42aAX0YGfoqK15tS62iW7EGcXKTJiMfQRsrESKvXA==", null, false, "2fae5838-81e4-499c-8066-87746a5e160d", false, "guest" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 16, 16, 56, 21, 437, DateTimeKind.Local).AddTicks(4811), "Test Identity", "bbf01137-6ee1-4067-ace6-a47d929208ae", "Prepare for Exam" },
                    { 2, 3, new DateTime(2022, 5, 16, 16, 56, 21, 437, DateTimeKind.Local).AddTicks(4867), "Test Identity", "bbf01137-6ee1-4067-ace6-a47d929208ae", "Prepare for Exam and improve" },
                    { 3, 2, new DateTime(2021, 12, 16, 16, 56, 21, 437, DateTimeKind.Local).AddTicks(4872), "Test Identity", "bbf01137-6ee1-4067-ace6-a47d929208ae", "Just Improve skills" },
                    { 4, 3, new DateTime(2021, 10, 16, 16, 56, 21, 437, DateTimeKind.Local).AddTicks(4877), "Test Identity", "bbf01137-6ee1-4067-ace6-a47d929208ae", "Prepare for c# Exam1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbf01137-6ee1-4067-ace6-a47d929208ae");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
