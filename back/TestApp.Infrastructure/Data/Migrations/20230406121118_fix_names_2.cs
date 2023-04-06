using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_names_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_CountrydId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "IdentityGuid",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CountrydId",
                table: "Provinces",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Provinces_CountrydId",
                table: "Provinces",
                newName: "IX_Provinces_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "Identity",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_CountryId",
                table: "Provinces",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_CountryId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Provinces",
                newName: "CountrydId");

            migrationBuilder.RenameIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                newName: "IX_Provinces_CountrydId");

            migrationBuilder.AddColumn<string>(
                name: "IdentityGuid",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_CountrydId",
                table: "Provinces",
                column: "CountrydId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
