using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo_WebApp.Migrations.Identity
{
    /// <inheritdoc />
    public partial class RecreateUserProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
				name: "UserProfiles",
				columns: table => new
				{
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
					City = table.Column<string>(type: "nvarchar(max)", nullable: false),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserProfiles", x => x.UserId);
					table.ForeignKey(
						name: "FK_UserProfiles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
