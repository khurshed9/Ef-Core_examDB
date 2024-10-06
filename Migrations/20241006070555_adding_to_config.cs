using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examdb.Migrations
{
    /// <inheritdoc />
    public partial class adding_to_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "employees",
                newName: "firstNameEmployee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "firstNameEmployee",
                table: "employees",
                newName: "firstName");
        }
    }
}
