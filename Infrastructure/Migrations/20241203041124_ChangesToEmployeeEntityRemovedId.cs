using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTT.CafeManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToEmployeeEntityRemovedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employee_cafe_assignments_employees_employee_id",
                schema: "public",
                table: "employee_cafe_assignments");

            migrationBuilder.DropColumn(
                name: "code",
                schema: "public",
                table: "employees");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                schema: "public",
                table: "employees",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "employee_id",
                schema: "public",
                table: "employee_cafe_assignments",
                type: "character varying(9)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employee_cafe_assignments_employee_employee_id",
                schema: "public",
                table: "employee_cafe_assignments");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "public",
                table: "employees",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9);

            migrationBuilder.AddColumn<string>(
                name: "code",
                schema: "public",
                table: "employees",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "employee_id",
                schema: "public",
                table: "employee_cafe_assignments",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(9)");

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
    }
}
