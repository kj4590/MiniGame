using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minigames.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameSummary_HangmanGameResult_TimesPlayed = table.Column<int>(type: "int", nullable: false),
                    GameSummary_HangmanGameResult_TimesWon = table.Column<int>(type: "int", nullable: false),
                    GameSummary_FormulaGameResult_TimesPlayed = table.Column<int>(type: "int", nullable: false),
                    GameSummary_FormulaGameResult_BestDifference = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
