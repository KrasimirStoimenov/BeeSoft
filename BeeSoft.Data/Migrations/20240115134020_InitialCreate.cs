using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartOfHoneyCollectionPeriod = table.Column<DateOnly>(type: "date", nullable: true),
                    ProbableEndOfHoneyCollectionPeriod = table.Column<DateOnly>(type: "date", nullable: true),
                    TotalHoneyHarvested = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apiaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beehives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBought = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApiaryId = table.Column<int>(type: "int", nullable: false),
                    BeeQueenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beehives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beehives_Apiaries_ApiaryId",
                        column: x => x.ApiaryId,
                        principalTable: "Apiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeeQueens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false),
                    BeehiveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeeQueens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeeQueens_Beehives_BeehiveId",
                        column: x => x.BeehiveId,
                        principalTable: "Beehives",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beehives_ApiaryId",
                table: "Beehives",
                column: "ApiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Beehives_BeeQueenId",
                table: "Beehives",
                column: "BeeQueenId");

            migrationBuilder.CreateIndex(
                name: "IX_BeeQueens_BeehiveId",
                table: "BeeQueens",
                column: "BeehiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beehives_BeeQueens_BeeQueenId",
                table: "Beehives",
                column: "BeeQueenId",
                principalTable: "BeeQueens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beehives_Apiaries_ApiaryId",
                table: "Beehives");

            migrationBuilder.DropForeignKey(
                name: "FK_Beehives_BeeQueens_BeeQueenId",
                table: "Beehives");

            migrationBuilder.DropTable(
                name: "Apiaries");

            migrationBuilder.DropTable(
                name: "BeeQueens");

            migrationBuilder.DropTable(
                name: "Beehives");
        }
    }
}
