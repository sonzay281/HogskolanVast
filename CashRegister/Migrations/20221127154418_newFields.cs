using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Migrations
{
    /// <inheritdoc />
    public partial class newFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiscountAmount",
                table: "Sales",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "Sales",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Sales");
        }
    }
}
