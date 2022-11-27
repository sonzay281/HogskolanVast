using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Migrations
{
    /// <inheritdoc />
    public partial class updatesalestable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Sales_SaleId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_SaleId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "SalesDate",
                table: "Sales",
                newName: "SalesDateTime");

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SaleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleItems_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_InventoryId",
                table: "SaleItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.RenameColumn(
                name: "SalesDateTime",
                table: "Sales",
                newName: "SalesDate");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Sales",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
