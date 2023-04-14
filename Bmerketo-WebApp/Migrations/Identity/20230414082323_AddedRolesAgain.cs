using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bmerketo_WebApp.Migrations.Identity
{
    /// <inheritdoc />
    public partial class AddedRolesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b246ec2-12df-4401-b20a-2d1e2e137d40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab18f504-7bb6-4e27-84fb-244bf3ca5e7e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e720096-5c02-49ee-b5ea-d88766bd456b", null, "admin", "ADMIN" },
                    { "6ab1077a-27b8-47ac-8083-850615ea97c8", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e720096-5c02-49ee-b5ea-d88766bd456b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ab1077a-27b8-47ac-8083-850615ea97c8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b246ec2-12df-4401-b20a-2d1e2e137d40", null, "user", null },
                    { "ab18f504-7bb6-4e27-84fb-244bf3ca5e7e", null, "admin", null }
                });
        }
    }
}
