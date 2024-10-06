using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examdb.Migrations
{
    /// <inheritdoc />
    public partial class phone_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "ValidPhone",
                table: "employees",
                sql: "length(phone) >= 10");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ValidPhone",
                table: "employees");
        }
    }
}
