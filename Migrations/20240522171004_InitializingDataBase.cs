using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarCLoudTaskBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitializingDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarCloudUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarCloudUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarCloudUserEntityStockEntity",
                columns: table => new
                {
                    RegisteredStockId = table.Column<int>(type: "int", nullable: false),
                    SubscribedUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarCloudUserEntityStockEntity", x => new { x.RegisteredStockId, x.SubscribedUsersId });
                    table.ForeignKey(
                        name: "FK_BarCloudUserEntityStockEntity_BarCloudUser_SubscribedUsersId",
                        column: x => x.SubscribedUsersId,
                        principalTable: "BarCloudUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarCloudUserEntityStockEntity_Stock_RegisteredStockId",
                        column: x => x.RegisteredStockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockAggregate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClosePrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    HighestPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    LowestPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    NumberOfTransactions = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    OpenPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    otc = table.Column<bool>(type: "bit", nullable: false),
                    StartOfTheAggregateWindow = table.Column<int>(type: "int", nullable: false),
                    TradingVolume = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAggregate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAggregate_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarCloudUser_Email",
                table: "BarCloudUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BarCloudUserEntityStockEntity_SubscribedUsersId",
                table: "BarCloudUserEntityStockEntity",
                column: "SubscribedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Ticker",
                table: "Stock",
                column: "Ticker",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockAggregate_StockId",
                table: "StockAggregate",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarCloudUserEntityStockEntity");

            migrationBuilder.DropTable(
                name: "StockAggregate");

            migrationBuilder.DropTable(
                name: "BarCloudUser");

            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
