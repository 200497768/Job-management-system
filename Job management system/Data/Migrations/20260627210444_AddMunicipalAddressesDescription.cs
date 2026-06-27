using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_management_system.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMunicipalAddressesDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MunicipalAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MunicipalAddress");
        }
    }
}
