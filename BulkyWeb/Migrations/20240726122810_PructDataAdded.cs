using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyWeb.Migrations
{
    /// <inheritdoc />
    public partial class PructDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products2",
                columns: new[] { "PId", "Author", "CategoryID", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Harper Lee", 2, " A novel about the serious issues of rape and racial inequality", "SJFK46546F", "", 99.0, 95.0, 85.0, 90.0, "To Kill a Mockingbird" },
                    { 2, "RJane Austen", 3, "A romantic novel", "SJFK46546F", "", 90.0, 85.0, 75.0, 80.0, "Pride and Prejudice" },
                    { 3, "Suzanne Collins", 1, "teenagers are selected to compete in a televised death match", "SJFK46546F", "", 70.0, 65.0, 55.0, 60.0, "The Hunger Games" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 3);
        }
    }
}
