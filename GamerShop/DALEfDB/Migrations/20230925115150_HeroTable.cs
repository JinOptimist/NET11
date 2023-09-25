using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALEfDB.Migrations
{
    /// <inheritdoc />
    public partial class HeroTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Class_ClassId",
                table: "Heros");

            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Race_RaceId",
                table: "Heros");

            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Subrace_SubraceId",
                table: "Heros");

            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Users_UserCreatorId",
                table: "Heros");

            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Оrigin_ОriginId",
                table: "Heros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heros",
                table: "Heros");

            migrationBuilder.RenameTable(
                name: "Heros",
                newName: "Hero");

            migrationBuilder.RenameIndex(
                name: "IX_Heros_UserCreatorId",
                table: "Hero",
                newName: "IX_Hero_UserCreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Heros_SubraceId",
                table: "Hero",
                newName: "IX_Hero_SubraceId");

            migrationBuilder.RenameIndex(
                name: "IX_Heros_RaceId",
                table: "Hero",
                newName: "IX_Hero_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Heros_ClassId",
                table: "Hero",
                newName: "IX_Hero_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Heros_ОriginId",
                table: "Hero",
                newName: "IX_Hero_ОriginId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hero",
                table: "Hero",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_Class_ClassId",
                table: "Hero",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_Race_RaceId",
                table: "Hero",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_Subrace_SubraceId",
                table: "Hero",
                column: "SubraceId",
                principalTable: "Subrace",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_Users_UserCreatorId",
                table: "Hero",
                column: "UserCreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_Оrigin_ОriginId",
                table: "Hero",
                column: "ОriginId",
                principalTable: "Оrigin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hero_Class_ClassId",
                table: "Hero");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero_Race_RaceId",
                table: "Hero");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero_Subrace_SubraceId",
                table: "Hero");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero_Users_UserCreatorId",
                table: "Hero");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero_Оrigin_ОriginId",
                table: "Hero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hero",
                table: "Hero");

            migrationBuilder.RenameTable(
                name: "Hero",
                newName: "Heros");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_UserCreatorId",
                table: "Heros",
                newName: "IX_Heros_UserCreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_SubraceId",
                table: "Heros",
                newName: "IX_Heros_SubraceId");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_RaceId",
                table: "Heros",
                newName: "IX_Heros_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_ClassId",
                table: "Heros",
                newName: "IX_Heros_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_ОriginId",
                table: "Heros",
                newName: "IX_Heros_ОriginId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heros",
                table: "Heros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Class_ClassId",
                table: "Heros",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Race_RaceId",
                table: "Heros",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Subrace_SubraceId",
                table: "Heros",
                column: "SubraceId",
                principalTable: "Subrace",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Users_UserCreatorId",
                table: "Heros",
                column: "UserCreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Оrigin_ОriginId",
                table: "Heros",
                column: "ОriginId",
                principalTable: "Оrigin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
