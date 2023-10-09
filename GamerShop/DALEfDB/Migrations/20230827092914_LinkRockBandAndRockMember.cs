using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALEfDB.Migrations
{
    /// <inheritdoc />
    public partial class LinkRockBandAndRockMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentBandId",
                table: "RockMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RockMembers_CurrentBandId",
                table: "RockMembers",
                column: "CurrentBandId");

            migrationBuilder.AddForeignKey(
                name: "FK_RockMembers_RockBands_CurrentBandId",
                table: "RockMembers",
                column: "CurrentBandId",
                principalTable: "RockBands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RockMembers_RockBands_CurrentBandId",
                table: "RockMembers");

            migrationBuilder.DropIndex(
                name: "IX_RockMembers_CurrentBandId",
                table: "RockMembers");

            migrationBuilder.DropColumn(
                name: "CurrentBandId",
                table: "RockMembers");
        }
    }
}
