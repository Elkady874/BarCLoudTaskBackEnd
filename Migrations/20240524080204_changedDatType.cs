using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarCLoudTaskBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class changedDatType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "StartOfTheAggregateWindow",
                table: "StockAggregate",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StartOfTheAggregateWindow",
                table: "StockAggregate",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
