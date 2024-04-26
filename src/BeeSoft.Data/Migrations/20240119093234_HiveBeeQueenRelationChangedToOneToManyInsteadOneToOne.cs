using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class HiveBeeQueenRelationChangedToOneToManyInsteadOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hives_BeeQueens_BeeQueenId",
                table: "Hives");

            migrationBuilder.DropIndex(
                name: "IX_Hives_BeeQueenId",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "BeeQueenId",
                table: "Hives");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeeQueenId",
                table: "Hives",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hives_BeeQueenId",
                table: "Hives",
                column: "BeeQueenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hives_BeeQueens_BeeQueenId",
                table: "Hives",
                column: "BeeQueenId",
                principalTable: "BeeQueens",
                principalColumn: "Id");
        }
    }
}
