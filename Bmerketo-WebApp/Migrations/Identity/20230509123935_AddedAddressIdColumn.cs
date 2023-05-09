using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo_WebApp.Migrations.Identity
{
    /// <inheritdoc />
    public partial class AddedAddressIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<int>(
	            name: "AddressId",
	            table: "UserProfiles",
	            type: "int",
	            nullable: false,
	            defaultValue: 0);

			migrationBuilder.CreateIndex(
				name: "IX_UserProfiles_AddressId",
				table: "UserProfiles",
				column: "AddressId");

			migrationBuilder.AddForeignKey(
				name: "FK_UserProfiles_Addresses_AddressId",
				table: "UserProfiles",
				column: "AddressId",
				principalTable: "Addresses",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropForeignKey(
				name: "FK_UserProfiles_Addresses_AddressId",
				table: "UserProfiles");

			migrationBuilder.DropIndex(
				name: "IX_UserProfiles_AddressId",
				table: "UserProfiles");

			migrationBuilder.DropColumn(
				name: "AddressId",
				table: "UserProfiles");
		}
    }
}
