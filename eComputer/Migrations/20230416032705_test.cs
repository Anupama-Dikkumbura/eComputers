using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComputer.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultAntivirus",
                table: "ComOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultCPU",
                table: "ComOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultHDD",
                table: "ComOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultMemory",
                table: "ComOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultOS",
                table: "ComOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultSSD",
                table: "ComOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultVGA",
                table: "ComOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrder_Categories_CategoryId",
                table: "ComOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrder_Serieses_SeriesId",
                table: "ComOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ComOrder_comOrderId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComOrder",
                table: "ComOrder");

            migrationBuilder.RenameTable(
                name: "ComOrder",
                newName: "ComOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrder_SeriesId",
                table: "ComOrders",
                newName: "IX_ComOrders_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrder_ModelDefaultVGA",
                table: "ComOrders",
                newName: "IX_ComOrders_ModelDefaultVGA");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrder_ModelDefaultSSD",
                table: "ComOrders",
                newName: "IX_ComOrders_ModelDefaultSSD");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrder_ModelDefaultOS",
                table: "ComOrders",
                newName: "IX_ComOrders_ModelDefaultOS");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrder_ModelDefaultMemory",
                table: "ComOrders",
                newName: "IX_ComOrders_ModelDefaultMemory");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrder_ModelDefaultHDD",
                table: "ComOrders",
                newName: "IX_ComOrders_ModelDefaultHDD");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrder_ModelDefaultCPU",
                table: "ComOrders",
                newName: "IX_ComOrders_ModelDefaultCPU");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrder_ModelDefaultAntivirus",
                table: "ComOrders",
                newName: "IX_ComOrders_ModelDefaultAntivirus");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrder_CategoryId",
                table: "ComOrders",
                newName: "IX_ComOrders_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ComModelId",
                table: "Accessories",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComOrders",
                table: "ComOrders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ComOrderId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_ComOrders_ComOrderId",
                        column: x => x.ComOrderId,
                        principalTable: "ComOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_ComModelId",
                table: "Accessories",
                column: "ComModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ComOrderId",
                table: "OrderItems",
                column: "ComOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_ComModels_ComModelId",
                table: "Accessories",
                column: "ComModelId",
                principalTable: "ComModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultAntivirus",
                table: "ComOrders",
                column: "ModelDefaultAntivirus",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultCPU",
                table: "ComOrders",
                column: "ModelDefaultCPU",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultHDD",
                table: "ComOrders",
                column: "ModelDefaultHDD",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultMemory",
                table: "ComOrders",
                column: "ModelDefaultMemory",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultOS",
                table: "ComOrders",
                column: "ModelDefaultOS",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultSSD",
                table: "ComOrders",
                column: "ModelDefaultSSD",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultVGA",
                table: "ComOrders",
                column: "ModelDefaultVGA",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_Categories_CategoryId",
                table: "ComOrders",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_Serieses_SeriesId",
                table: "ComOrders",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ComOrders_comOrderId",
                table: "ShoppingCartItems",
                column: "comOrderId",
                principalTable: "ComOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_ComModels_ComModelId",
                table: "Accessories");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultAntivirus",
                table: "ComOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultCPU",
                table: "ComOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultHDD",
                table: "ComOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultMemory",
                table: "ComOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultOS",
                table: "ComOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultSSD",
                table: "ComOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_Accessories_ModelDefaultVGA",
                table: "ComOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_Categories_CategoryId",
                table: "ComOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_Serieses_SeriesId",
                table: "ComOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ComOrders_comOrderId",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Accessories_ComModelId",
                table: "Accessories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComOrders",
                table: "ComOrders");

            migrationBuilder.DropColumn(
                name: "ComModelId",
                table: "Accessories");

            migrationBuilder.RenameTable(
                name: "ComOrders",
                newName: "ComOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrders_SeriesId",
                table: "ComOrder",
                newName: "IX_ComOrder_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrders_ModelDefaultVGA",
                table: "ComOrder",
                newName: "IX_ComOrder_ModelDefaultVGA");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrders_ModelDefaultSSD",
                table: "ComOrder",
                newName: "IX_ComOrder_ModelDefaultSSD");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrders_ModelDefaultOS",
                table: "ComOrder",
                newName: "IX_ComOrder_ModelDefaultOS");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrders_ModelDefaultMemory",
                table: "ComOrder",
                newName: "IX_ComOrder_ModelDefaultMemory");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrders_ModelDefaultHDD",
                table: "ComOrder",
                newName: "IX_ComOrder_ModelDefaultHDD");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrders_ModelDefaultCPU",
                table: "ComOrder",
                newName: "IX_ComOrder_ModelDefaultCPU");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrders_ModelDefaultAntivirus",
                table: "ComOrder",
                newName: "IX_ComOrder_ModelDefaultAntivirus");

            migrationBuilder.RenameIndex(
                name: "IX_ComOrders_CategoryId",
                table: "ComOrder",
                newName: "IX_ComOrder_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComOrder",
                table: "ComOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultAntivirus",
                table: "ComOrder",
                column: "ModelDefaultAntivirus",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultCPU",
                table: "ComOrder",
                column: "ModelDefaultCPU",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultHDD",
                table: "ComOrder",
                column: "ModelDefaultHDD",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultMemory",
                table: "ComOrder",
                column: "ModelDefaultMemory",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultOS",
                table: "ComOrder",
                column: "ModelDefaultOS",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultSSD",
                table: "ComOrder",
                column: "ModelDefaultSSD",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrder_Accessories_ModelDefaultVGA",
                table: "ComOrder",
                column: "ModelDefaultVGA",
                principalTable: "Accessories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrder_Categories_CategoryId",
                table: "ComOrder",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrder_Serieses_SeriesId",
                table: "ComOrder",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ComOrder_comOrderId",
                table: "ShoppingCartItems",
                column: "comOrderId",
                principalTable: "ComOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
