using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALEfDB.Migrations
{
    /// <inheritdoc />
    public partial class linkedFootLeaguesWhithFootClubs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "FootballClubs");

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "FootballClubs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FootballClubs_LeagueId",
                table: "FootballClubs",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballClubs_FootballLeagues_LeagueId",
                table: "FootballClubs",
                column: "LeagueId",
                principalTable: "FootballLeagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballClubs_FootballLeagues_LeagueId",
                table: "FootballClubs");

            migrationBuilder.DropIndex(
                name: "IX_FootballClubs_LeagueId",
                table: "FootballClubs");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "FootballClubs");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "FootballClubs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
