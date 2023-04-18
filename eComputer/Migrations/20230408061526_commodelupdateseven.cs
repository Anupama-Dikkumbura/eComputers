using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComputer.Migrations
{
    /// <inheritdoc />
    public partial class commodelupdateseven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ComModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "ComModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_CategoryId",
                table: "ComModels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ComModels_SeriesId",
                table: "ComModels",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComModels_Categories_CategoryId",
                table: "ComModels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComModels_Serieses_SeriesId",
                table: "ComModels",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComModels_Categories_CategoryId",
                table: "ComModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ComModels_Serieses_SeriesId",
                table: "ComModels");

            migrationBuilder.DropIndex(
                name: "IX_ComModels_CategoryId",
                table: "ComModels");

            migrationBuilder.DropIndex(
                name: "IX_ComModels_SeriesId",
                table: "ComModels");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ComModels");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "ComModels");
        }
    }
}
