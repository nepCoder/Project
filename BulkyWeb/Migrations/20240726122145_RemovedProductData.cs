using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyWeb.Migrations
{
    /// <inheritdoc />
    public partial class RemovedProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products2",
                columns: new[] { "PId", "Author", "CategoryID", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "John Doe", 1, "Action related", "SJFK46546F", "", 99.0, 95.0, 85.0, 90.0, "Ranger" },
                    { 2, "Roman Reigns", 1, "Thriller", "SJFK46546F", "", 99.0, 95.0, 85.0, 90.0, "Book of Gangster" },
                    { 3, "John Cena", 1, "Fortune of your", "SJFK46546F", "", 99.0, 95.0, 85.0, 90.0, "Book of Fortune" }
                });
        }
    }
}
