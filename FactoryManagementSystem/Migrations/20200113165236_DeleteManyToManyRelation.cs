using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryManagementSystem.Migrations
{
    public partial class DeleteManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PermissionMaps_PermissionMapPermissionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_PermissionMaps_PermissionMapPermissionId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_PermissionMapPermissionId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PermissionMapPermissionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PermissionMapPermissionId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "PermissionMapPermissionId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionMapPermissionId",
                table: "UserRoles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PermissionMapPermissionId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_PermissionMapPermissionId",
                table: "UserRoles",
                column: "PermissionMapPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PermissionMapPermissionId",
                table: "AspNetUsers",
                column: "PermissionMapPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PermissionMaps_PermissionMapPermissionId",
                table: "AspNetUsers",
                column: "PermissionMapPermissionId",
                principalTable: "PermissionMaps",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_PermissionMaps_PermissionMapPermissionId",
                table: "UserRoles",
                column: "PermissionMapPermissionId",
                principalTable: "PermissionMaps",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
