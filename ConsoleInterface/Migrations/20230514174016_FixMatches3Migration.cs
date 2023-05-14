using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleInterface.Migrations
{
    /// <inheritdoc />
    public partial class FixMatches3Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchStatistics_FirstTeamStatisticMatchStatisticId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchStatistics_SecondTeamStatisticMatchStatisticId",
                table: "Matches");

            migrationBuilder.AlterColumn<Guid>(
                name: "SecondTeamStatisticMatchStatisticId",
                table: "Matches",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "FirstTeamStatisticMatchStatisticId",
                table: "Matches",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchStatistics_FirstTeamStatisticMatchStatisticId",
                table: "Matches",
                column: "FirstTeamStatisticMatchStatisticId",
                principalTable: "MatchStatistics",
                principalColumn: "MatchStatisticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchStatistics_SecondTeamStatisticMatchStatisticId",
                table: "Matches",
                column: "SecondTeamStatisticMatchStatisticId",
                principalTable: "MatchStatistics",
                principalColumn: "MatchStatisticId");
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

            migrationBuilder.AlterColumn<Guid>(
                name: "SecondTeamStatisticMatchStatisticId",
                table: "Matches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FirstTeamStatisticMatchStatisticId",
                table: "Matches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
    }
}
