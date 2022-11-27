using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Migrations
{
    /// <inheritdoc />
    public partial class updatesalestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Inventories_InventoryId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "Sales",
                newName: "OperatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_InventoryId",
                table: "Sales",
                newName: "IX_Sales_OperatorId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sales",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Inventories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SaleId",
                table: "Inventories",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Sales_SaleId",
                table: "Inventories",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_OperatorId",
                table: "Sales",
                column: "OperatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Sales_SaleId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_OperatorId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_SaleId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "Sales",
                newName: "InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_OperatorId",
                table: "Sales",
                newName: "IX_Sales_InventoryId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sales",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Inventories_InventoryId",
                table: "Sales",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
