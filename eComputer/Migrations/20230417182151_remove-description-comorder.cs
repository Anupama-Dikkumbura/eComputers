using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComputer.Migrations
{
    /// <inheritdoc />
    public partial class removedescriptioncomorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelDescription",
                table: "ComOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModelDescription",
                table: "ComOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
