using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo_WebApp.Migrations.Identity
{
    /// <inheritdoc />
    public partial class UserProfileUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
