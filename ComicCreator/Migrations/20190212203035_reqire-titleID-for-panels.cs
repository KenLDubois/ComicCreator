using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicCreator.Migrations
{
    public partial class reqiretitleIDforpanels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Titles_TitleId",
                schema: "MU",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                schema: "MU",
                table: "Issues",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Titles_TitleId",
                schema: "MU",
                table: "Issues",
                column: "TitleId",
                principalSchema: "MU",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Titles_TitleId",
                schema: "MU",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                schema: "MU",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Titles_TitleId",
                schema: "MU",
                table: "Issues",
                column: "TitleId",
                principalSchema: "MU",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
