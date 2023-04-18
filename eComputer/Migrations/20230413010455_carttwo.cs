using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComputer.Migrations
{
    /// <inheritdoc />
    public partial class carttwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ComModels_comModelId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "comModelId",
                table: "ShoppingCartItems",
                newName: "comOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_comModelId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_comOrderId");

            migrationBuilder.CreateTable(
                name: "ComOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelPrice = table.Column<double>(type: "float", nullable: false),
                    BasePrice = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SeriesId = table.Column<int>(type: "int", nullable: true),
                    ModelDefaultCPU = table.Column<int>(type: "int", nullable: true),
                    ModelDefaultMemory = table.Column<int>(type: "int", nullable: true),
                    ModelDefaultHDD = table.Column<int>(type: "int", nullable: true),
                    ModelDefaultSSD = table.Column<int>(type: "int", nullable: true),
                    ModelDefaultVGA = table.Column<int>(type: "int", nullable: true),
                    ModelDefaultOS = table.Column<int>(type: "int", nullable: true),
                    ModelDefaultAntivirus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComOrder_Accessories_ModelDefaultAntivirus",
                        column: x => x.ModelDefaultAntivirus,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComOrder_Accessories_ModelDefaultCPU",
                        column: x => x.ModelDefaultCPU,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComOrder_Accessories_ModelDefaultHDD",
                        column: x => x.ModelDefaultHDD,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComOrder_Accessories_ModelDefaultMemory",
                        column: x => x.ModelDefaultMemory,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComOrder_Accessories_ModelDefaultOS",
                        column: x => x.ModelDefaultOS,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComOrder_Accessories_ModelDefaultSSD",
                        column: x => x.ModelDefaultSSD,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComOrder_Accessories_ModelDefaultVGA",
                        column: x => x.ModelDefaultVGA,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComOrder_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComOrder_Serieses_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Serieses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComOrder_CategoryId",
                table: "ComOrder",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ComOrder_ModelDefaultAntivirus",
                table: "ComOrder",
                column: "ModelDefaultAntivirus");

            migrationBuilder.CreateIndex(
                name: "IX_ComOrder_ModelDefaultCPU",
                table: "ComOrder",
                column: "ModelDefaultCPU");

            migrationBuilder.CreateIndex(
                name: "IX_ComOrder_ModelDefaultHDD",
                table: "ComOrder",
                column: "ModelDefaultHDD");

            migrationBuilder.CreateIndex(
                name: "IX_ComOrder_ModelDefaultMemory",
                table: "ComOrder",
                column: "ModelDefaultMemory");

            migrationBuilder.CreateIndex(
                name: "IX_ComOrder_ModelDefaultOS",
                table: "ComOrder",
                column: "ModelDefaultOS");

            migrationBuilder.CreateIndex(
                name: "IX_ComOrder_ModelDefaultSSD",
                table: "ComOrder",
                column: "ModelDefaultSSD");

            migrationBuilder.CreateIndex(
                name: "IX_ComOrder_ModelDefaultVGA",
                table: "ComOrder",
                column: "ModelDefaultVGA");

            migrationBuilder.CreateIndex(
                name: "IX_ComOrder_SeriesId",
                table: "ComOrder",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ComOrder_comOrderId",
                table: "ShoppingCartItems",
                column: "comOrderId",
                principalTable: "ComOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ComOrder_comOrderId",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "ComOrder");

            migrationBuilder.RenameColumn(
                name: "comOrderId",
                table: "ShoppingCartItems",
                newName: "comModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_comOrderId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_comModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ComModels_comModelId",
                table: "ShoppingCartItems",
                column: "comModelId",
                principalTable: "ComModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
