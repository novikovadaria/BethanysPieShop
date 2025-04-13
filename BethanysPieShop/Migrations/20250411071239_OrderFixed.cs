using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BethanysPieShop.Migrations
{
    /// <inheritdoc />
    public partial class OrderFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Orders",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Orders",
                newName: "CustomerName");
        }
    }
}
