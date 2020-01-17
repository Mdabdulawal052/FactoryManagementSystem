using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryManagementSystem.Migrations
{
    public partial class TblPermissionMapAndURole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionMapPermissionId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PermissionMaps",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionMaps", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PermissionMapPermissionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_PermissionMaps_PermissionMapPermissionId",
                        column: x => x.PermissionMapPermissionId,
                        principalTable: "PermissionMaps",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PermissionMapPermissionId",
                table: "AspNetUsers",
                column: "PermissionMapPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_PermissionMapPermissionId",
                table: "UserRoles",
                column: "PermissionMapPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PermissionMaps_PermissionMapPermissionId",
                table: "AspNetUsers",
                column: "PermissionMapPermissionId",
                principalTable: "PermissionMaps",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PermissionMaps_PermissionMapPermissionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "PermissionMaps");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PermissionMapPermissionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PermissionMapPermissionId",
                table: "AspNetUsers");
        }
    }
}
