using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Inzynierski.Data.Migrations
{
    public partial class attention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttentionTest",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    GameName = table.Column<string>(nullable: true),
                    CorrectAns = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttentionTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttentionTest_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttentionTest_ApplicationUserId",
                table: "AttentionTest",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttentionTest");
        }
    }
}
