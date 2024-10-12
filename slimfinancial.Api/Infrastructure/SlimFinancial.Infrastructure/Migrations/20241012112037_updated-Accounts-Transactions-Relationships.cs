using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlimFinancial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedAccountsTransactionsRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransaction");

            migrationBuilder.AddColumn<string>(
                name: "SourceAccountId",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "337f5059-c404-4d22-8128-f8297258856f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9849095-d0f1-4c97-9d42-5adf79ace250", "AQAAAAIAAYagAAAAEK6nmtSgbgnrUJJC12+Ng2JmKNOV97xc1A3tfCDDqNz8bwrFBMMnA6jg7qDHBUMm8w==", "c1adb0fd-6af7-4789-8071-4fb4b92fe6fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb7bc11e-4de9-44a5-b770-d4be2e20bc29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa295537-ee73-4811-92bf-42e24d261b74", "AQAAAAIAAYagAAAAEIkruPB62dxyRnvNbWgWcbOyNeKYpVY5QgObDR/nu3rG5JVJV/L+1x9Xux+DVs+1AQ==", "37681bfc-4a74-416e-82b4-cf6776e30df0" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_SourceAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SourceAccountId",
                table: "Transactions");

            migrationBuilder.CreateTable(
                name: "AccountTransaction",
                columns: table => new
                {
                    SourceAccountId = table.Column<string>(type: "TEXT", nullable: false),
                    TransactionsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransaction", x => new { x.SourceAccountId, x.TransactionsId });
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Accounts_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Transactions_TransactionsId",
                        column: x => x.TransactionsId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "337f5059-c404-4d22-8128-f8297258856f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9944d66a-62b1-4a0c-b0bb-72995c6acede", "AQAAAAIAAYagAAAAEMRUswEUGMSD/hW6gB62wUC6MmHdspgFkWst4aEl7skGsQn63kJIMH3PLyF8DApzxw==", "b4094f87-aa02-4092-a4f8-c801479564ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb7bc11e-4de9-44a5-b770-d4be2e20bc29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26e942d4-bac3-4f30-9aae-496e0f462740", "AQAAAAIAAYagAAAAEMS11D0jcKNRZSjKMcM7eaZI6oe6BxjC9JOmOBGeFVJJ8SSC2DOngBvKzWKD0xn1/w==", "2f2c06af-9353-4a69-a01e-ee7f352471b2" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_TransactionsId",
                table: "AccountTransaction",
                column: "TransactionsId");
        }
    }
}
