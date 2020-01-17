using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryManagementSystem.Migrations
{
    public partial class removeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PermissionMaps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PermissionMaps",
                nullable: true);
        }
    }
}
