using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryManagementSystem.Migrations
{
    public partial class addEmpRelateTabSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpLedgerTitles",
                columns: table => new
                {
                    LedgerTitleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LedgerTitle = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpLedgerTitles", x => x.LedgerTitleID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLedgers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    LedgerTitleID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Debit = table.Column<decimal>(nullable: false),
                    Credit = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLedgers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeLedgers_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLedgers_EmpLedgerTitles_LedgerTitleID",
                        column: x => x.LedgerTitleID,
                        principalTable: "EmpLedgerTitles",
                        principalColumn: "LedgerTitleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLedgers_EmployeeID",
                table: "EmployeeLedgers",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLedgers_LedgerTitleID",
                table: "EmployeeLedgers",
                column: "LedgerTitleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLedgers");

            migrationBuilder.DropTable(
                name: "EmpLedgerTitles");
        }
    }
}
