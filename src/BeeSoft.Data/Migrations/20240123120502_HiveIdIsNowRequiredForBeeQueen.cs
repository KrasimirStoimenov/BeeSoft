using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class HiveIdIsNowRequiredForBeeQueen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeeQueens_Hives_HiveId",
                table: "BeeQueens");

            migrationBuilder.AlterColumn<int>(
                name: "HiveId",
                table: "BeeQueens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BeeQueens_Hives_HiveId",
                table: "BeeQueens",
                column: "HiveId",
                principalTable: "Hives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeeQueens_Hives_HiveId",
                table: "BeeQueens");

            migrationBuilder.AlterColumn<int>(
                name: "HiveId",
                table: "BeeQueens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BeeQueens_Hives_HiveId",
                table: "BeeQueens",
                column: "HiveId",
                principalTable: "Hives",
                principalColumn: "Id");
        }
    }
}
