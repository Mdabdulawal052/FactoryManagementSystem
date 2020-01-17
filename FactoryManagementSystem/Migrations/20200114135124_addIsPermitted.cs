using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryManagementSystem.Migrations
{
    public partial class addIsPermitted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPermitted",
                table: "PermissionMaps",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPermitted",
                table: "PermissionMaps");
        }
    }
}
