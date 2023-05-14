using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleInterface.Migrations
{
    /// <inheritdoc />
    public partial class FixMatchesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_FirstTeamTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_SecondTeamTeamId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SecondTeamTeamId",
                table: "Matches",
                newName: "SecondTeamId");

            migrationBuilder.RenameColumn(
                name: "FirstTeamTeamId",
                table: "Matches",
                newName: "FirstTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SecondTeamTeamId",
                table: "Matches",
                newName: "IX_Matches_SecondTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_FirstTeamTeamId",
                table: "Matches",
                newName: "IX_Matches_FirstTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_FirstTeamId",
                table: "Matches",
                column: "FirstTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_SecondTeamId",
                table: "Matches",
                column: "SecondTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_FirstTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_SecondTeamId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SecondTeamId",
                table: "Matches",
                newName: "SecondTeamTeamId");

            migrationBuilder.RenameColumn(
                name: "FirstTeamId",
                table: "Matches",
                newName: "FirstTeamTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SecondTeamId",
                table: "Matches",
                newName: "IX_Matches_SecondTeamTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_FirstTeamId",
                table: "Matches",
                newName: "IX_Matches_FirstTeamTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_FirstTeamTeamId",
                table: "Matches",
                column: "FirstTeamTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_SecondTeamTeamId",
                table: "Matches",
                column: "SecondTeamTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
