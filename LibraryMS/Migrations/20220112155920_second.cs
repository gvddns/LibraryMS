using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryMS.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentRequests_Categories_BookId",
                table: "RentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168e6bb0-f62b-4462-b4ea-4f1ad026cb53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6373dba-77a6-4539-b485-dac4c0d6f50c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8daebfae-c0ec-498f-a428-9698c116eece", "4a9168ec-1f4c-41d1-b6f4-8d5d7f1767e7", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83587504-3300-425a-9681-12a4e6b7e00e", "ba15bb2c-b8d8-49c3-b7d4-19737c14afe5", "Admin", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_RentRequests_Books_BookId",
                table: "RentRequests",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentRequests_Books_BookId",
                table: "RentRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83587504-3300-425a-9681-12a4e6b7e00e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8daebfae-c0ec-498f-a428-9698c116eece");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "168e6bb0-f62b-4462-b4ea-4f1ad026cb53", "a6d6223b-3405-4327-ad03-2b0b54f5cc46", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6373dba-77a6-4539-b485-dac4c0d6f50c", "e847a356-9ea2-4355-b72e-325a9a5b2ab9", "Admin", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_RentRequests_Categories_BookId",
                table: "RentRequests",
                column: "BookId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
