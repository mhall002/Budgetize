using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetSplit.New.Data.Migrations
{
    public partial class RenameDescToMemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Transactions",
                newName: "Memo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Memo",
                table: "Transactions",
                newName: "Description");
        }
    }
}
