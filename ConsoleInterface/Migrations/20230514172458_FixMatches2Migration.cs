using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleInterface.Migrations
{
    /// <inheritdoc />
    public partial class FixMatches2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchStatistics_StatOfFirstTeamMatchStatisticId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchStatistics_StatOfSecondTeamMatchStatisticId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "StatOfSecondTeamMatchStatisticId",
                table: "Matches",
                newName: "SecondTeamStatisticMatchStatisticId");

            migrationBuilder.RenameColumn(
                name: "StatOfFirstTeamMatchStatisticId",
                table: "Matches",
                newName: "FirstTeamStatisticMatchStatisticId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_StatOfSecondTeamMatchStatisticId",
                table: "Matches",
                newName: "IX_Matches_SecondTeamStatisticMatchStatisticId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_StatOfFirstTeamMatchStatisticId",
                table: "Matches",
                newName: "IX_Matches_FirstTeamStatisticMatchStatisticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchStatistics_FirstTeamStatisticMatchStatisticId",
                table: "Matches",
                column: "FirstTeamStatisticMatchStatisticId",
                principalTable: "MatchStatistics",
                principalColumn: "MatchStatisticId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchStatistics_SecondTeamStatisticMatchStatisticId",
                table: "Matches",
                column: "SecondTeamStatisticMatchStatisticId",
                principalTable: "MatchStatistics",
                principalColumn: "MatchStatisticId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchStatistics_FirstTeamStatisticMatchStatisticId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchStatistics_SecondTeamStatisticMatchStatisticId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SecondTeamStatisticMatchStatisticId",
                table: "Matches",
                newName: "StatOfSecondTeamMatchStatisticId");

            migrationBuilder.RenameColumn(
                name: "FirstTeamStatisticMatchStatisticId",
                table: "Matches",
                newName: "StatOfFirstTeamMatchStatisticId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SecondTeamStatisticMatchStatisticId",
                table: "Matches",
                newName: "IX_Matches_StatOfSecondTeamMatchStatisticId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_FirstTeamStatisticMatchStatisticId",
                table: "Matches",
                newName: "IX_Matches_StatOfFirstTeamMatchStatisticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchStatistics_StatOfFirstTeamMatchStatisticId",
                table: "Matches",
                column: "StatOfFirstTeamMatchStatisticId",
                principalTable: "MatchStatistics",
                principalColumn: "MatchStatisticId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchStatistics_StatOfSecondTeamMatchStatisticId",
                table: "Matches",
                column: "StatOfSecondTeamMatchStatisticId",
                principalTable: "MatchStatistics",
                principalColumn: "MatchStatisticId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
