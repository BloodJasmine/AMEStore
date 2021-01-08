using Microsoft.EntityFrameworkCore.Migrations;

namespace AMEStore.Migrations
{
    public partial class StoreCartFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopCartId",
                table: "StoreCartItem");

            migrationBuilder.AddColumn<string>(
                name: "StoreCartId",
                table: "StoreCartItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreCartId",
                table: "StoreCartItem");

            migrationBuilder.AddColumn<string>(
                name: "ShopCartId",
                table: "StoreCartItem",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
