using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALEfDB.Migrations
{
    /// <inheritdoc />
    public partial class AddFilmAdaptations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmAdaptationOfId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FilmAdaptationOfId",
                table: "Movies",
                column: "FilmAdaptationOfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Books_FilmAdaptationOfId",
                table: "Movies",
                column: "FilmAdaptationOfId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Books_FilmAdaptationOfId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_FilmAdaptationOfId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "FilmAdaptationOfId",
                table: "Movies");
        }
    }
}
