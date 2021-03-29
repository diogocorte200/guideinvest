using Microsoft.EntityFrameworkCore.Migrations;

namespace Guide.Entity.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "varchar(3)", nullable: true),
                    Symbol = table.Column<string>(type: "varchar(15)", nullable: true),
                    ExchangeName = table.Column<string>(type: "varchar(15)", nullable: true),
                    InstrumentType = table.Column<string>(type: "varchar(15)", nullable: true),
                    FirstTradeDate = table.Column<int>(type: "int", nullable: false),
                    RegularMarketTime = table.Column<int>(type: "int", nullable: false),
                    Gmtoffset = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<string>(type: "varchar(5)", nullable: true),
                    ExchangeTimezoneName = table.Column<string>(type: "varchar(100)", nullable: true),
                    RegularMarketPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    ChartPreviousClose = table.Column<decimal>(type: "decimal", nullable: false),
                    PreviousClose = table.Column<decimal>(type: "decimal", nullable: false),
                    Scale = table.Column<int>(type: "int", nullable: false),
                    PriceHint = table.Column<int>(type: "int", nullable: false),
                    DataGranularity = table.Column<string>(type: "varchar(3)", nullable: true),
                    Range = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTradingPeriod",
                columns: table => new
                {
                    CurrentTradingPeriodEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFinance = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "varchar(30)", nullable: true),
                    Timezone = table.Column<string>(type: "varchar(5)", nullable: true),
                    Start = table.Column<int>(type: "int", nullable: false),
                    End = table.Column<int>(type: "int", nullable: false),
                    Gmtoffset = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTradingPeriod", x => x.CurrentTradingPeriodEntityId);
                    table.ForeignKey(
                        name: "FK_CurrentTradingPeriod_Finance_IdFinance",
                        column: x => x.IdFinance,
                        principalTable: "Finance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentTradingPeriod_IdFinance",
                table: "CurrentTradingPeriod",
                column: "IdFinance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTradingPeriod");

            migrationBuilder.DropTable(
                name: "Finance");
        }
    }
}
