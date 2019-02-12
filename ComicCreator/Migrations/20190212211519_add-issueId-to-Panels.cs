using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicCreator.Migrations
{
    public partial class addissueIdtoPanels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panels_Issues_IssueId",
                schema: "MU",
                table: "Panels");

            migrationBuilder.AlterColumn<int>(
                name: "IssueId",
                schema: "MU",
                table: "Panels",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Panels_Issues_IssueId",
                schema: "MU",
                table: "Panels",
                column: "IssueId",
                principalSchema: "MU",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panels_Issues_IssueId",
                schema: "MU",
                table: "Panels");

            migrationBuilder.AlterColumn<int>(
                name: "IssueId",
                schema: "MU",
                table: "Panels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Panels_Issues_IssueId",
                schema: "MU",
                table: "Panels",
                column: "IssueId",
                principalSchema: "MU",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
