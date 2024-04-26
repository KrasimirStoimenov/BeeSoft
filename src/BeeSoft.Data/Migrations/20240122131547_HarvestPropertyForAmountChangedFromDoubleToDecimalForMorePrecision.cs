using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class HarvestPropertyForAmountChangedFromDoubleToDecimalForMorePrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "HarvestedAmount",
                table: "Harvests",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "HarvestedAmount",
                table: "Harvests",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
