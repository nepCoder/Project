using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb.Migrations
{
    /// <inheritdoc />
    public partial class PructDataAddedNext23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 3,
                column: "Price100",
                value: 56.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 3,
                column: "Price100",
                value: 55.0);
        }
    }
}
