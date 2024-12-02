using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTT.CafeManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDbStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employee_cafe_assignments_employee_employee_id",
                schema: "public",
                table: "employee_cafe_assignments");

            migrationBuilder.AddForeignKey(
                name: "fk_employee_cafe_assignments_employees_employee_id",
                schema: "public",
                table: "employee_cafe_assignments",
                column: "employee_id",
                principalSchema: "public",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employee_cafe_assignments_employees_employee_id",
                schema: "public",
                table: "employee_cafe_assignments");

            migrationBuilder.AddForeignKey(
                name: "fk_employee_cafe_assignments_employee_employee_id",
                schema: "public",
                table: "employee_cafe_assignments",
                column: "employee_id",
                principalSchema: "public",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
