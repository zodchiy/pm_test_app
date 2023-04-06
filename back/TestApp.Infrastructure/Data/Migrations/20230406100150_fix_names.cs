using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProvinceName",
                table: "Provinces",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Countries",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Provinces",
                newName: "ProvinceName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "CountryName");
        }
    }
}
