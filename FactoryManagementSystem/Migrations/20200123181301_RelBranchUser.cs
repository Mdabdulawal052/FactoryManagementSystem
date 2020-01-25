using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryManagementSystem.Migrations
{
    public partial class RelBranchUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Branches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ApplicationUserId",
                table: "Branches",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_AspNetUsers_ApplicationUserId",
                table: "Branches",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_AspNetUsers_ApplicationUserId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_ApplicationUserId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Branches");
        }
    }
}
