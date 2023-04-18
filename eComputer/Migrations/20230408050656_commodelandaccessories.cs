using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComputer.Migrations
{
    /// <inheritdoc />
    public partial class commodelandaccessories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelPrice = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_ComModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComModels_Accessories_ModelDefaultAntivirus",
                        column: x => x.ModelDefaultAntivirus,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComModels_Accessories_ModelDefaultCPU",
                        column: x => x.ModelDefaultCPU,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComModels_Accessories_ModelDefaultHDD",
                        column: x => x.ModelDefaultHDD,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComModels_Accessories_ModelDefaultMemory",
                        column: x => x.ModelDefaultMemory,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComModels_Accessories_ModelDefaultOS",
                        column: x => x.ModelDefaultOS,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComModels_Accessories_ModelDefaultSSD",
                        column: x => x.ModelDefaultSSD,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComModels_Accessories_ModelDefaultVGA",
                        column: x => x.ModelDefaultVGA,
                        principalTable: "Accessories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComModels_Accessories",
                columns: table => new
                {
                    ComModelId = table.Column<int>(type: "int", nullable: false),
                    AccessoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComModels_Accessories", x => new { x.ComModelId, x.AccessoryId });
                    table.ForeignKey(
                        name: "FK_ComModels_Accessories_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComModels_Accessories_ComModels_ComModelId",
                        column: x => x.ComModelId,
                        principalTable: "ComModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_ModelDefaultAntivirus",
                table: "ComModels",
                column: "ModelDefaultAntivirus");

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_ModelDefaultCPU",
                table: "ComModels",
                column: "ModelDefaultCPU");

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_ModelDefaultHDD",
                table: "ComModels",
                column: "ModelDefaultHDD");

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_ModelDefaultMemory",
                table: "ComModels",
                column: "ModelDefaultMemory");

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_ModelDefaultOS",
                table: "ComModels",
                column: "ModelDefaultOS");

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_ModelDefaultSSD",
                table: "ComModels",
                column: "ModelDefaultSSD");

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_ModelDefaultVGA",
                table: "ComModels",
                column: "ModelDefaultVGA");

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_Accessories_AccessoryId",
                table: "ComModels_Accessories",
                column: "AccessoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComModels_Accessories");

            migrationBuilder.DropTable(
                name: "ComModels");
        }
    }
}
