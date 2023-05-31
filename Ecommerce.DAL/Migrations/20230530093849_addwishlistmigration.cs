using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addwishlistmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishItem_WishList_WishListID",
                table: "WishItem");

            migrationBuilder.DropIndex(
                name: "IX_WishItem_WishListID",
                table: "WishItem");

            migrationBuilder.DropColumn(
                name: "WishListID",
                table: "WishItem");

            migrationBuilder.RenameColumn(
                name: "whishlistID",
                table: "WishItem",
                newName: "whishlstID");

            migrationBuilder.CreateIndex(
                name: "IX_WishItem_whishlstID",
                table: "WishItem",
                column: "whishlstID");

            migrationBuilder.AddForeignKey(
                name: "FK_WishItem_WishList_whishlstID",
                table: "WishItem",
                column: "whishlstID",
                principalTable: "WishList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishItem_WishList_whishlstID",
                table: "WishItem");

            migrationBuilder.DropIndex(
                name: "IX_WishItem_whishlstID",
                table: "WishItem");

            migrationBuilder.RenameColumn(
                name: "whishlstID",
                table: "WishItem",
                newName: "whishlistID");

            migrationBuilder.AddColumn<int>(
                name: "WishListID",
                table: "WishItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishItem_WishListID",
                table: "WishItem",
                column: "WishListID");

            migrationBuilder.AddForeignKey(
                name: "FK_WishItem_WishList_WishListID",
                table: "WishItem",
                column: "WishListID",
                principalTable: "WishList",
                principalColumn: "ID");
        }
    }
}
