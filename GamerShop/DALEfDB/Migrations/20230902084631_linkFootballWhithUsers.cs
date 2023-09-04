using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALEfDB.Migrations
{
    /// <inheritdoc />
    public partial class linkFootballWhithUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "FootballClubs");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "FootballClubs",
                newName: "UserCreatorId");

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "FootballClubs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FootballLeagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballLeagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballLeagues_Users_UserCreatorId",
                        column: x => x.UserCreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballClubs_LeagueId",
                table: "FootballClubs",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballClubs_UserCreatorId",
                table: "FootballClubs",
                column: "UserCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballLeagues_UserCreatorId",
                table: "FootballLeagues",
                column: "UserCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballClubs_FootballLeagues_LeagueId",
                table: "FootballClubs",
                column: "LeagueId",
                principalTable: "FootballLeagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballClubs_Users_UserCreatorId",
                table: "FootballClubs",
                column: "UserCreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballClubs_FootballLeagues_LeagueId",
                table: "FootballClubs");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballClubs_Users_UserCreatorId",
                table: "FootballClubs");

            migrationBuilder.DropTable(
                name: "FootballLeagues");

            migrationBuilder.DropIndex(
                name: "IX_FootballClubs_LeagueId",
                table: "FootballClubs");

            migrationBuilder.DropIndex(
                name: "IX_FootballClubs_UserCreatorId",
                table: "FootballClubs");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "FootballClubs");

            migrationBuilder.RenameColumn(
                name: "UserCreatorId",
                table: "FootballClubs",
                newName: "Creator");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "FootballClubs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
