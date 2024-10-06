using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examdb.Migrations
{
    /// <inheritdoc />
    public partial class config_props : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstName = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar", nullable: false),
                    phone = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    hireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    position = table.Column<string>(type: "varchar", nullable: false),
                    salary = table.Column<decimal>(type: "decimal", nullable: false),
                    departmentName = table.Column<string>(type: "varchar", nullable: false),
                    managerId = table.Column<Guid>(type: "uuid", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    address = table.Column<string>(type: "varchar", nullable: false),
                    city = table.Column<string>(type: "varchar", nullable: false),
                    country = table.Column<string>(type: "varchar", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
