using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALEfDB.Migrations
{
    /// <inheritdoc />
    public partial class AddPcBuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxMotherboardSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxCpuCollerHeight = table.Column<int>(type: "int", nullable: true),
                    MaxGpuLength = table.Column<int>(type: "int", nullable: true),
                    MaxPsuLength = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coolers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DissipatedPower = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coolers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gpus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PciExpressVersion = table.Column<int>(type: "int", nullable: true),
                    Chip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseFrequency = table.Column<float>(type: "real", nullable: true),
                    MaxFrequency = table.Column<float>(type: "real", nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryBusWidth = table.Column<int>(type: "int", nullable: true),
                    DirectXSupport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerConnectors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerConsumption = table.Column<int>(type: "int", nullable: true),
                    RecommendedPsuPowerConsumption = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hddss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadingSpeed = table.Column<int>(type: "int", nullable: true),
                    WritingSpeed = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hddss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemorySlotsCount = table.Column<int>(type: "int", nullable: true),
                    MaxMemoryCapacity = table.Column<int>(type: "int", nullable: true),
                    PciExVersion = table.Column<int>(type: "int", nullable: true),
                    M2SlotsCount = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoreCount = table.Column<int>(type: "int", nullable: true),
                    ThreadsCount = table.Column<int>(type: "int", nullable: true),
                    BaseFrequency = table.Column<float>(type: "real", nullable: true),
                    MaxFrequency = table.Column<float>(type: "real", nullable: true),
                    RamSupporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PciExVersion = table.Column<int>(type: "int", nullable: true),
                    Tdp = table.Column<int>(type: "int", nullable: true),
                    TechProcess = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Psus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Power = table.Column<int>(type: "int", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCount = table.Column<int>(type: "int", nullable: true),
                    KitCapacity = table.Column<int>(type: "int", nullable: true),
                    ModuleCapacity = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ssds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    ReadingSpeed = table.Column<int>(type: "int", nullable: true),
                    WritingSpeed = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ssds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Builds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isVirtual = table.Column<bool>(type: "bit", nullable: false),
                    PhotosPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    PasswordForViewing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessorId = table.Column<int>(type: "int", nullable: false),
                    MotherboardId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    CoolerId = table.Column<int>(type: "int", nullable: false),
                    PsuId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Builds_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Builds_Coolers_CoolerId",
                        column: x => x.CoolerId,
                        principalTable: "Coolers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Builds_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Builds_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Builds_Psus_PsuId",
                        column: x => x.PsuId,
                        principalTable: "Psus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Builds_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "BuildUser",
                columns: table => new
                {
                    LikedBuildsId = table.Column<int>(type: "int", nullable: false),
                    UsersWhoLikeItId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildUser", x => new { x.LikedBuildsId, x.UsersWhoLikeItId });
                    table.ForeignKey(
                        name: "FK_BuildUser_Builds_LikedBuildsId",
                        column: x => x.LikedBuildsId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildUser_Users_UsersWhoLikeItId",
                        column: x => x.UsersWhoLikeItId,
                        principalTable: "Users",
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
                name: "IX_Builds_CaseId",
                table: "Builds",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_CoolerId",
                table: "Builds",
                column: "CoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_CreatorId",
                table: "Builds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_MotherboardId",
                table: "Builds",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_ProcessorId",
                table: "Builds",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_PsuId",
                table: "Builds",
                column: "PsuId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildSsd_SsdsId",
                table: "BuildSsd",
                column: "SsdsId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildUser_UsersWhoLikeItId",
                table: "BuildUser",
                column: "UsersWhoLikeItId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildGpu");

            migrationBuilder.DropTable(
                name: "BuildHdd");

            migrationBuilder.DropTable(
                name: "BuildRam");

            migrationBuilder.DropTable(
                name: "BuildSsd");

            migrationBuilder.DropTable(
                name: "BuildUser");

            migrationBuilder.DropTable(
                name: "Gpus");

            migrationBuilder.DropTable(
                name: "Hddss");

            migrationBuilder.DropTable(
                name: "Rams");

            migrationBuilder.DropTable(
                name: "Ssds");

            migrationBuilder.DropTable(
                name: "Builds");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Coolers");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "Psus");
        }
    }
}
