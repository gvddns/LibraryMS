using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryMS.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2bcf0eb-86e6-480f-bdd7-66dccd1ef02d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeb2f0ee-cece-40bb-a99b-4b14d59be123");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c3679fdf-acf3-4901-9d61-4988a9f6832c", "e937a789-9239-48a9-80cd-c7e654ebe368", "User", "User" },
                    { "b8c2d7f9-1794-4397-9582-23259adcc0d6", "58d3560c-cb38-47d9-9618-8fd2649ba444", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "RentRequests",
                columns: new[] { "id", "BookId", "approval", "approvaldate", "enddate", "requestdate", "startdate", "totalrent", "username" },
                values: new object[,]
                {
                    { 1, 2, "Pending", new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "gvddns" },
                    { 2, 3, "Pending", new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "gvddns" },
                    { 3, 1, "Pending", new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, "gvddns" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8c2d7f9-1794-4397-9582-23259adcc0d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3679fdf-acf3-4901-9d61-4988a9f6832c");

            migrationBuilder.DeleteData(
                table: "RentRequests",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentRequests",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentRequests",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eeb2f0ee-cece-40bb-a99b-4b14d59be123", "885e7944-401d-4af5-8990-1c10f0616963", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2bcf0eb-86e6-480f-bdd7-66dccd1ef02d", "1f9acade-f3c3-4415-9451-4989d0189593", "Admin", "Admin" });
        }
    }
}
