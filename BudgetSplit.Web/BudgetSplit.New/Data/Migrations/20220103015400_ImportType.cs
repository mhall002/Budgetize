using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetSplit.New.Data.Migrations
{
    public partial class ImportType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImportType",
                table: "Accounts",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportType",
                table: "Accounts");
        }
    }
}
