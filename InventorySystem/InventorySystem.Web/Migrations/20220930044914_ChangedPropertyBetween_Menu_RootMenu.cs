using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Web.Migrations
{
    public partial class ChangedPropertyBetween_Menu_RootMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "RootMenus");

            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "RootMenus");

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "Menus");

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                table: "RootMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "RootMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
