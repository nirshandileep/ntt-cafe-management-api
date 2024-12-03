using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTT.CafeManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToEmployeeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "employee_code",
                schema: "public",
                table: "employees",
                newName: "code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "code",
                schema: "public",
                table: "employees",
                newName: "employee_code");
        }
    }
}
