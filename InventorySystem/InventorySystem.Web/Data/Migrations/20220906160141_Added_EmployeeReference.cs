using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Web.Data.Migrations
{
    public partial class Added_EmployeeReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AspNetUsers");
        }
    }
}
