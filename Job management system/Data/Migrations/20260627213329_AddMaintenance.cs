using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_management_system.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipalAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_MunicipalAddress_MunicipalAddressId",
                        column: x => x.MunicipalAddressId,
                        principalTable: "MunicipalAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobId",
                table: "Employee",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_MunicipalAddressId",
                table: "Job",
                column: "MunicipalAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Job_JobId",
                table: "Employee",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Job_JobId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropIndex(
                name: "IX_Employee_JobId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Employee");
        }
    }
}
