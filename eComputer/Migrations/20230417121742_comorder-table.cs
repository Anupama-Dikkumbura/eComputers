using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComputer.Migrations
{
    /// <inheritdoc />
    public partial class comordertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_ComModels_ComModelId",
                table: "Accessories");

            migrationBuilder.DropIndex(
                name: "IX_Accessories_ComModelId",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "ComOrders");

            migrationBuilder.DropColumn(
                name: "ComModelId",
                table: "Accessories");

            migrationBuilder.AddColumn<int>(
                name: "ComModelId",
                table: "ComOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComOrders_ComModelId",
                table: "ComOrders",
                column: "ComModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComOrders_ComModels_ComModelId",
                table: "ComOrders",
                column: "ComModelId",
                principalTable: "ComModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComOrders_ComModels_ComModelId",
                table: "ComOrders");

            migrationBuilder.DropIndex(
                name: "IX_ComOrders_ComModelId",
                table: "ComOrders");

            migrationBuilder.DropColumn(
                name: "ComModelId",
                table: "ComOrders");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "ComOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ComModelId",
                table: "Accessories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_ComModelId",
                table: "Accessories",
                column: "ComModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_ComModels_ComModelId",
                table: "Accessories",
                column: "ComModelId",
                principalTable: "ComModels",
                principalColumn: "Id");
        }
    }
}
