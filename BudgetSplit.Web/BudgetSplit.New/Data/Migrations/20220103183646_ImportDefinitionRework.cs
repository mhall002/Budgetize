using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetSplit.New.Data.Migrations
{
    public partial class ImportDefinitionRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportType",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "ImportDefinitionId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportDefinitionId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "ImportType",
                table: "Accounts",
                type: "int",
                nullable: true);
        }
    }
}
