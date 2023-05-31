using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addwishlistmigrationupdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_wishItems",
                table: "wishItems");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "wishItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wishItems",
                table: "wishItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_wishItems_prodID",
                table: "wishItems",
                column: "prodID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_wishItems",
                table: "wishItems");

            migrationBuilder.DropIndex(
                name: "IX_wishItems_prodID",
                table: "wishItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "wishItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wishItems",
                table: "wishItems",
                columns: new[] { "prodID", "whishlstID" });
        }
    }
}
