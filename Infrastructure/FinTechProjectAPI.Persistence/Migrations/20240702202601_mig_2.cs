using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinTechProjectAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseTransactions_expenseCategories_ExpenseCategoryId",
                table: "ExpenseTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeTransactions_IncomeCategories_IncomeCategoryId",
                table: "IncomeTransactions");

            migrationBuilder.DropTable(
                name: "expenseCategories");

            migrationBuilder.DropTable(
                name: "IncomeCategories");

            migrationBuilder.RenameColumn(
                name: "IncomeCategoryId",
                table: "IncomeTransactions",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeTransactions_IncomeCategoryId",
                table: "IncomeTransactions",
                newName: "IX_IncomeTransactions_CategoryId");

            migrationBuilder.RenameColumn(
                name: "ExpenseCategoryId",
                table: "ExpenseTransactions",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseTransactions_ExpenseCategoryId",
                table: "ExpenseTransactions",
                newName: "IX_ExpenseTransactions_CategoryId");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseTransactions_Categories_CategoryId",
                table: "ExpenseTransactions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeTransactions_Categories_CategoryId",
                table: "IncomeTransactions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseTransactions_Categories_CategoryId",
                table: "ExpenseTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeTransactions_Categories_CategoryId",
                table: "IncomeTransactions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "IncomeTransactions",
                newName: "IncomeCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeTransactions_CategoryId",
                table: "IncomeTransactions",
                newName: "IX_IncomeTransactions_IncomeCategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ExpenseTransactions",
                newName: "ExpenseCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseTransactions_CategoryId",
                table: "ExpenseTransactions",
                newName: "IX_ExpenseTransactions_ExpenseCategoryId");

            migrationBuilder.CreateTable(
                name: "expenseCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseTransactions_expenseCategories_ExpenseCategoryId",
                table: "ExpenseTransactions",
                column: "ExpenseCategoryId",
                principalTable: "expenseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeTransactions_IncomeCategories_IncomeCategoryId",
                table: "IncomeTransactions",
                column: "IncomeCategoryId",
                principalTable: "IncomeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
