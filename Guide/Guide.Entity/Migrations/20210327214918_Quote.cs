using Microsoft.EntityFrameworkCore.Migrations;

namespace Guide.Entity.Migrations
{
    public partial class Quote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentTradingPeriodEntityId",
                table: "CurrentTradingPeriod",
                newName: "CurrentTradingPeriodId");

            migrationBuilder.CreateTable(
                name: "QuoteIndicator",
                columns: table => new
                {
                    QuoteIndicatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFinance = table.Column<int>(type: "int", nullable: false),
                    TimestampMeta = table.Column<int>(type: "int", nullable: true),
                    QuoteLow = table.Column<decimal>(type: "decimal", nullable: true),
                    QuoteHigh = table.Column<decimal>(type: "decimal", nullable: true),
                    QuoteOpen = table.Column<decimal>(type: "decimal", nullable: true),
                    QuoteClose = table.Column<decimal>(type: "decimal", nullable: true),
                    Volume = table.Column<decimal>(type: "decimal", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteIndicator", x => x.QuoteIndicatorId);
                    table.ForeignKey(
                        name: "FK_QuoteIndicator_Finance_IdFinance",
                        column: x => x.IdFinance,
                        principalTable: "Finance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteIndicator_IdFinance",
                table: "QuoteIndicator",
                column: "IdFinance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteIndicator");

            migrationBuilder.RenameColumn(
                name: "CurrentTradingPeriodId",
                table: "CurrentTradingPeriod",
                newName: "CurrentTradingPeriodEntityId");
        }
    }
}
