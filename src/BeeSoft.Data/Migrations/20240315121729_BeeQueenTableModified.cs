using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class BeeQueenTableModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "BeeQueens",
                newName: "Year");

            migrationBuilder.AddColumn<string>(
                name: "ColorMark",
                table: "BeeQueens",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorMark",
                table: "BeeQueens");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "BeeQueens",
                newName: "Age");
        }
    }
}
