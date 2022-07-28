using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addingstoreidtoitemsk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_items_StoreId",
                table: "items",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_items_stores_StoreId",
                table: "items",
                column: "StoreId",
                principalTable: "stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_stores_StoreId",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_StoreId",
                table: "items");
        }
    }
}
