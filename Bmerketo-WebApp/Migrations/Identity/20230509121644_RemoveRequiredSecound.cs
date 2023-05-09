using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo_WebApp.Migrations.Identity
{
    /// <inheritdoc />
    public partial class RemoveRequiredSecound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropColumn(
	            name: "PostalCode",
	            table: "UserProfiles");

			migrationBuilder.DropColumn(
				name: "City",
				table: "UserProfiles");

			migrationBuilder.DropColumn(
				name: "StreetName",
				table: "UserProfiles");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<string>(
				name: "PostalCode",
				table: "UserProfiles",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "City",
				table: "UserProfiles",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "StreetName",
				table: "UserProfiles",
				type: "nvarchar(max)",
				nullable: true);
		}
    }
}
