using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb.Migrations
{
    /// <inheritdoc />
    public partial class PructDataAddedNext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 3,
                column: "ISBN",
                value: "SJHBFHJN567");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 3,
                column: "ISBN",
                value: "SJFK46546F");
        }
    }
}
