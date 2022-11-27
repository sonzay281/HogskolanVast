using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Migrations
{
    /// <inheritdoc />
    public partial class renamefields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "expiryDate",
                table: "Inventories",
                newName: "ExpiryDate");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "Inventories",
                newName: "Discount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "Inventories",
                newName: "expiryDate");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Inventories",
                newName: "discount");
        }
    }
}
