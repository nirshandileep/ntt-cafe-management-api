using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTT.CafeManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "cafes",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cafes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employee_code = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee_cafe_assignments",
                schema: "public",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cafe_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employee_cafe_assignments", x => new { x.employee_id, x.cafe_id });
                    table.ForeignKey(
                        name: "fk_employee_cafe_assignments_cafes_cafe_id",
                        column: x => x.cafe_id,
                        principalSchema: "public",
                        principalTable: "cafes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_employee_cafe_assignments_employee_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "public",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_employee_cafe_assignments_cafe_id",
                schema: "public",
                table: "employee_cafe_assignments",
                column: "cafe_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee_cafe_assignments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cafes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "public");
        }
    }
}
