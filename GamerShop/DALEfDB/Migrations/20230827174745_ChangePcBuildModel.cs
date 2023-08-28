using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALEfDB.Migrations
{
    /// <inheritdoc />
    public partial class ChangePcBuildModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Builds_Cases_CaseId",
                table: "Builds");

            migrationBuilder.DropTable(
                name: "BuildGpu");

            migrationBuilder.DropTable(
                name: "BuildHdd");

            migrationBuilder.DropTable(
                name: "BuildRam");

            migrationBuilder.DropTable(
                name: "BuildSsd");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "Builds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GpuId",
                table: "Builds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GpusCount",
                table: "Builds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HddCount",
                table: "Builds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HddId",
                table: "Builds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RamCount",
                table: "Builds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RamId",
                table: "Builds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SsdCount",
                table: "Builds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SsdId",
                table: "Builds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Builds_GpuId",
                table: "Builds",
                column: "GpuId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_HddId",
                table: "Builds",
                column: "HddId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_RamId",
                table: "Builds",
                column: "RamId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_SsdId",
                table: "Builds",
                column: "SsdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_Cases_CaseId",
                table: "Builds",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_Gpus_GpuId",
                table: "Builds",
                column: "GpuId",
                principalTable: "Gpus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_Hddss_HddId",
                table: "Builds",
                column: "HddId",
                principalTable: "Hddss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_Rams_RamId",
                table: "Builds",
                column: "RamId",
                principalTable: "Rams",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_Ssds_SsdId",
                table: "Builds",
                column: "SsdId",
                principalTable: "Ssds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Builds_Cases_CaseId",
                table: "Builds");

            migrationBuilder.DropForeignKey(
                name: "FK_Builds_Gpus_GpuId",
                table: "Builds");

            migrationBuilder.DropForeignKey(
                name: "FK_Builds_Hddss_HddId",
                table: "Builds");

            migrationBuilder.DropForeignKey(
                name: "FK_Builds_Rams_RamId",
                table: "Builds");

            migrationBuilder.DropForeignKey(
                name: "FK_Builds_Ssds_SsdId",
                table: "Builds");

            migrationBuilder.DropIndex(
                name: "IX_Builds_GpuId",
                table: "Builds");

            migrationBuilder.DropIndex(
                name: "IX_Builds_HddId",
                table: "Builds");

            migrationBuilder.DropIndex(
                name: "IX_Builds_RamId",
                table: "Builds");

            migrationBuilder.DropIndex(
                name: "IX_Builds_SsdId",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "GpuId",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "GpusCount",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "HddCount",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "HddId",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "RamCount",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "RamId",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "SsdCount",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "SsdId",
                table: "Builds");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "Builds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BuildGpu",
                columns: table => new
                {
                    BuildsId = table.Column<int>(type: "int", nullable: false),
                    GpusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildGpu", x => new { x.BuildsId, x.GpusId });
                    table.ForeignKey(
                        name: "FK_BuildGpu_Builds_BuildsId",
                        column: x => x.BuildsId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildGpu_Gpus_GpusId",
                        column: x => x.GpusId,
                        principalTable: "Gpus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BuildHdd",
                columns: table => new
                {
                    BuildsId = table.Column<int>(type: "int", nullable: false),
                    HddsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildHdd", x => new { x.BuildsId, x.HddsId });
                    table.ForeignKey(
                        name: "FK_BuildHdd_Builds_BuildsId",
                        column: x => x.BuildsId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildHdd_Hddss_HddsId",
                        column: x => x.HddsId,
                        principalTable: "Hddss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BuildRam",
                columns: table => new
                {
                    BuildsId = table.Column<int>(type: "int", nullable: false),
                    RamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildRam", x => new { x.BuildsId, x.RamsId });
                    table.ForeignKey(
                        name: "FK_BuildRam_Builds_BuildsId",
                        column: x => x.BuildsId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildRam_Rams_RamsId",
                        column: x => x.RamsId,
                        principalTable: "Rams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BuildSsd",
                columns: table => new
                {
                    BuildsId = table.Column<int>(type: "int", nullable: false),
                    SsdsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildSsd", x => new { x.BuildsId, x.SsdsId });
                    table.ForeignKey(
                        name: "FK_BuildSsd_Builds_BuildsId",
                        column: x => x.BuildsId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildSsd_Ssds_SsdsId",
                        column: x => x.SsdsId,
                        principalTable: "Ssds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildGpu_GpusId",
                table: "BuildGpu",
                column: "GpusId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildHdd_HddsId",
                table: "BuildHdd",
                column: "HddsId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildRam_RamsId",
                table: "BuildRam",
                column: "RamsId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildSsd_SsdsId",
                table: "BuildSsd",
                column: "SsdsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_Cases_CaseId",
                table: "Builds",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
