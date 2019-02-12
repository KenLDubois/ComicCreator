using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicCreator.Migrations
{
    public partial class AddPanelsandPanelText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssueNumber",
                schema: "MU",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                schema: "MU",
                table: "Issues",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Panels",
                schema: "MU",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<int>(nullable: false),
                    PanelImageContent = table.Column<byte[]>(nullable: true),
                    PanelImageMimeType = table.Column<string>(maxLength: 256, nullable: true),
                    PanelImageFileName = table.Column<string>(maxLength: 100, nullable: true),
                    IssueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Panels_Issues_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "MU",
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PanelTexts",
                schema: "MU",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<int>(nullable: false),
                    TextContent = table.Column<string>(nullable: true),
                    TailX = table.Column<double>(nullable: true),
                    TailY = table.Column<double>(nullable: true),
                    TextClass = table.Column<string>(nullable: true),
                    PanelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanelTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PanelTexts_Panels_PanelId",
                        column: x => x.PanelId,
                        principalSchema: "MU",
                        principalTable: "Panels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Panels_IssueId",
                schema: "MU",
                table: "Panels",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_PanelTexts_PanelId",
                schema: "MU",
                table: "PanelTexts",
                column: "PanelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PanelTexts",
                schema: "MU");

            migrationBuilder.DropTable(
                name: "Panels",
                schema: "MU");

            migrationBuilder.DropColumn(
                name: "IssueNumber",
                schema: "MU",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                schema: "MU",
                table: "Issues");
        }
    }
}
