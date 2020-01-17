using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryManagementSystem.Migrations
{
    public partial class CreateVirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "PermissionMaps",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PermissionMaps",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMaps_ApplicationUserId",
                table: "PermissionMaps",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMaps_RoleId",
                table: "PermissionMaps",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMaps_AspNetUsers_ApplicationUserId",
                table: "PermissionMaps",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMaps_UserRoles_RoleId",
                table: "PermissionMaps",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMaps_AspNetUsers_ApplicationUserId",
                table: "PermissionMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMaps_UserRoles_RoleId",
                table: "PermissionMaps");

            migrationBuilder.DropIndex(
                name: "IX_PermissionMaps_ApplicationUserId",
                table: "PermissionMaps");

            migrationBuilder.DropIndex(
                name: "IX_PermissionMaps_RoleId",
                table: "PermissionMaps");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PermissionMaps");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "PermissionMaps",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
