using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products2");

            migrationBuilder.RenameColumn(
                name: "Pid",
                table: "Products2",
                newName: "PId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products2",
                table: "Products2",
                column: "PId");

            migrationBuilder.InsertData(
                table: "Products2",
                columns: new[] { "PId", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "John Doe", "Action related", "SJFK46546F", 99.0, 95.0, 85.0, 90.0, "Ranger" },
                    { 2, "Roman Reigns", "Thriller", "SJFK46546F", 99.0, 95.0, 85.0, 90.0, "Book of Gangster" },
                    { 3, "John Cena", "Fortune of your", "SJFK46546F", 99.0, 95.0, 85.0, 90.0, "Book of Fortune" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products2",
                table: "Products2");

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

            migrationBuilder.RenameTable(
                name: "Products2",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "PId",
                table: "Products",
                newName: "Pid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Pid");
        }
    }
}
