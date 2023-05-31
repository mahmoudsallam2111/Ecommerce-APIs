using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addwishlistmigrationupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishItem_Products_prodID",
                table: "WishItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WishItem_WishList_whishlstID",
                table: "WishItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_User_userID",
                table: "WishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishList",
                table: "WishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishItem",
                table: "WishItem");

            migrationBuilder.RenameTable(
                name: "WishList",
                newName: "wishLists");

            migrationBuilder.RenameTable(
                name: "WishItem",
                newName: "wishItems");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_userID",
                table: "wishLists",
                newName: "IX_wishLists_userID");

            migrationBuilder.RenameIndex(
                name: "IX_WishItem_whishlstID",
                table: "wishItems",
                newName: "IX_wishItems_whishlstID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wishLists",
                table: "wishLists",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wishItems",
                table: "wishItems",
                columns: new[] { "prodID", "whishlstID" });

            migrationBuilder.AddForeignKey(
                name: "FK_wishItems_Products_prodID",
                table: "wishItems",
                column: "prodID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wishItems_wishLists_whishlstID",
                table: "wishItems",
                column: "whishlstID",
                principalTable: "wishLists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wishLists_User_userID",
                table: "wishLists",
                column: "userID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wishItems_Products_prodID",
                table: "wishItems");

            migrationBuilder.DropForeignKey(
                name: "FK_wishItems_wishLists_whishlstID",
                table: "wishItems");

            migrationBuilder.DropForeignKey(
                name: "FK_wishLists_User_userID",
                table: "wishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wishLists",
                table: "wishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wishItems",
                table: "wishItems");

            migrationBuilder.RenameTable(
                name: "wishLists",
                newName: "WishList");

            migrationBuilder.RenameTable(
                name: "wishItems",
                newName: "WishItem");

            migrationBuilder.RenameIndex(
                name: "IX_wishLists_userID",
                table: "WishList",
                newName: "IX_WishList_userID");

            migrationBuilder.RenameIndex(
                name: "IX_wishItems_whishlstID",
                table: "WishItem",
                newName: "IX_WishItem_whishlstID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishList",
                table: "WishList",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishItem",
                table: "WishItem",
                columns: new[] { "prodID", "whishlstID" });

            migrationBuilder.AddForeignKey(
                name: "FK_WishItem_Products_prodID",
                table: "WishItem",
                column: "prodID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishItem_WishList_whishlstID",
                table: "WishItem",
                column: "whishlstID",
                principalTable: "WishList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_User_userID",
                table: "WishList",
                column: "userID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
