using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Inzynierski.Data.Migrations
{
    public partial class tests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoordinationTest",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    GameName = table.Column<string>(nullable: true),
                    NumOfClick = table.Column<int>(nullable: false),
                    ReactionTime = table.Column<TimeSpan>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinationTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoordinationTest_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemoryTest",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    GameName = table.Column<string>(nullable: true),
                    NumOfClick = table.Column<int>(nullable: false),
                    GameTime = table.Column<TimeSpan>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemoryTest_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerceptionTest",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    GameName = table.Column<string>(nullable: true),
                    ReactionTime = table.Column<TimeSpan>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerceptionTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerceptionTest_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReasoningTest",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    GameName = table.Column<string>(nullable: true),
                    isWinner = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasoningTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasoningTest_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoordinationTest_ApplicationUserId",
                table: "CoordinationTest",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoryTest_ApplicationUserId",
                table: "MemoryTest",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PerceptionTest_ApplicationUserId",
                table: "PerceptionTest",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasoningTest_ApplicationUserId",
                table: "ReasoningTest",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoordinationTest");

            migrationBuilder.DropTable(
                name: "MemoryTest");

            migrationBuilder.DropTable(
                name: "PerceptionTest");

            migrationBuilder.DropTable(
                name: "ReasoningTest");
        }
    }
}
