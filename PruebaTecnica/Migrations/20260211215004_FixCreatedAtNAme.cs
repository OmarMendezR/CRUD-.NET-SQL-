using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class FixCreatedAtNAme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Products",
                newName: "CreateAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Products",
                newName: "DateTime");
        }
    }
}
