using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationBetweenProductAndCategoryWithForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Products2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Products2",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 1,
                columns: new[] { "CategoryID", "ID" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 2,
                columns: new[] { "CategoryID", "ID" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Products2",
                keyColumn: "PId",
                keyValue: 3,
                columns: new[] { "CategoryID", "ID" },
                values: new object[] { 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Products2_ID",
                table: "Products2",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products2_Categories_ID",
                table: "Products2",
                column: "ID",
                principalTable: "Categories",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products2_Categories_ID",
                table: "Products2");

            migrationBuilder.DropIndex(
                name: "IX_Products2_ID",
                table: "Products2");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Products2");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Products2");
        }
    }
}
