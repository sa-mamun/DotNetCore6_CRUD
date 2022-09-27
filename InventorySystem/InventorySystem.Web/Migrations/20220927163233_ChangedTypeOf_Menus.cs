using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Web.Migrations
{
    public partial class ChangedTypeOf_Menus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "ActionName",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_RootMenuId",
                table: "Menus",
                column: "RootMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_RootMenus_RootMenuId",
                table: "Menus",
                column: "RootMenuId",
                principalTable: "RootMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_RootMenus_RootMenuId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_RootMenuId",
                table: "Menus");

            migrationBuilder.AlterColumn<long>(
                name: "MenuName",
                table: "Menus",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "ActionName",
                table: "Menus",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
