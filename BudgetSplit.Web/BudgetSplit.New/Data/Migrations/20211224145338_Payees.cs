using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetSplit.New.Data.Migrations
{
    public partial class Payees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imports_People_PayeeId",
                table: "Imports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_People_PayeeId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropIndex(
                name: "IX_Imports_PayeeId",
                table: "Imports");

            migrationBuilder.AddColumn<int>(
                name: "HumanId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HumanId",
                table: "Imports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payees",
                columns: table => new
                {
                    PayeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payees", x => x.PayeeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_HumanId",
                table: "Transactions",
                column: "HumanId");

            migrationBuilder.CreateIndex(
                name: "IX_Imports_HumanId",
                table: "Imports",
                column: "HumanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imports_Humans_HumanId",
                table: "Imports",
                column: "HumanId",
                principalTable: "Humans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Humans_HumanId",
                table: "Transactions",
                column: "HumanId",
                principalTable: "Humans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Payees_PayeeId",
                table: "Transactions",
                column: "PayeeId",
                principalTable: "Payees",
                principalColumn: "PayeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imports_Humans_HumanId",
                table: "Imports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Humans_HumanId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Payees_PayeeId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.DropTable(
                name: "Payees");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_HumanId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Imports_HumanId",
                table: "Imports");

            migrationBuilder.DropColumn(
                name: "HumanId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "HumanId",
                table: "Imports");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imports_PayeeId",
                table: "Imports",
                column: "PayeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imports_People_PayeeId",
                table: "Imports",
                column: "PayeeId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_People_PayeeId",
                table: "Transactions",
                column: "PayeeId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
