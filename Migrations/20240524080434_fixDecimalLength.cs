using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarCLoudTaskBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class fixDecimalLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "StartOfTheAggregateWindow",
                table: "StockAggregate",
                type: "decimal(20,2)",
                precision: 20,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "StartOfTheAggregateWindow",
                table: "StockAggregate",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,2)",
                oldPrecision: 20,
                oldScale: 2);
        }
    }
}
