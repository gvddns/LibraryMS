using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryMS.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87b5d2a3-5ccc-4295-a445-1ebbe67eb27c", "9e285220-0f9b-4ff0-8f67-4802e4a0d10b", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dcfb558-249e-463d-9612-8b4d42c8c172", "26e934d7-2a41-4ff3-8a40-639af977f761", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dcfb558-249e-463d-9612-8b4d42c8c172");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b5d2a3-5ccc-4295-a445-1ebbe67eb27c");
        }
    }
}
