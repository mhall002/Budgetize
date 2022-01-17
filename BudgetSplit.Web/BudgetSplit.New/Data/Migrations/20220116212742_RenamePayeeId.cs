using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetSplit.New.Data.Migrations
{
    public partial class RenamePayeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayeeId",
                table: "Payees",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payees",
                newName: "PayeeId");
        }
    }
}
