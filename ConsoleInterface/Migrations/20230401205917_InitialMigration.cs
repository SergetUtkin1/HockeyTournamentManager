using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleInterface.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infractions",
                columns: table => new
                {
                    InfractionId = table.Column<Guid>(type: "uuid", nullable: false),
                    InfractionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infractions", x => x.InfractionId);
                });

            migrationBuilder.CreateTable(
                name: "MatchStatistics",
                columns: table => new
                {
                    MatchStatisticId = table.Column<Guid>(type: "uuid", nullable: false),
                    WinType = table.Column<string>(type: "text", nullable: false),
                    Shots = table.Column<int>(type: "integer", nullable: false),
                    BlockedShots = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatistics", x => x.MatchStatisticId);
                });

            migrationBuilder.CreateTable(
                name: "TeamStatistics",
                columns: table => new
                {
                    TeamStatisticId = table.Column<Guid>(type: "uuid", nullable: false),
                    Scores = table.Column<int>(type: "integer", nullable: false),
                    WinsAtRegularTime = table.Column<int>(type: "integer", nullable: false),
                    WinsAtOT = table.Column<int>(type: "integer", nullable: false),
                    WinsAtShootOut = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStatistics", x => x.TeamStatisticId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TeamStatId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamStatisticId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_TeamStatistics_TeamStatisticId",
                        column: x => x.TeamStatisticId,
                        principalTable: "TeamStatistics",
                        principalColumn: "TeamStatisticId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstTeamTeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecondTeamTeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatOfFirstTeamMatchStatisticId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatOfSecondTeamMatchStatisticId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_MatchStatistics_StatOfFirstTeamMatchStatisticId",
                        column: x => x.StatOfFirstTeamMatchStatisticId,
                        principalTable: "MatchStatistics",
                        principalColumn: "MatchStatisticId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_MatchStatistics_StatOfSecondTeamMatchStatisticId",
                        column: x => x.StatOfSecondTeamMatchStatisticId,
                        principalTable: "MatchStatistics",
                        principalColumn: "MatchStatisticId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_FirstTeamTeamId",
                        column: x => x.FirstTeamTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_SecondTeamTeamId",
                        column: x => x.SecondTeamTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<Guid>(type: "uuid", nullable: false),
                    MatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsEven = table.Column<bool>(type: "boolean", nullable: false),
                    IsPowerPlay = table.Column<bool>(type: "boolean", nullable: false),
                    IsShorthanded = table.Column<bool>(type: "boolean", nullable: false),
                    MatchStatisticId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlayerId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_Goals_MatchStatistics_MatchStatisticId",
                        column: x => x.MatchStatisticId,
                        principalTable: "MatchStatistics",
                        principalColumn: "MatchStatisticId");
                    table.ForeignKey(
                        name: "FK_Goals_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goals_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Goals_Players_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                });

            migrationBuilder.CreateTable(
                name: "Penalties",
                columns: table => new
                {
                    PenaltyId = table.Column<Guid>(type: "uuid", nullable: false),
                    InfractionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Minutes = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    MatchStatisticId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalties", x => x.PenaltyId);
                    table.ForeignKey(
                        name: "FK_Penalties_Infractions_InfractionId",
                        column: x => x.InfractionId,
                        principalTable: "Infractions",
                        principalColumn: "InfractionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Penalties_MatchStatistics_MatchStatisticId",
                        column: x => x.MatchStatisticId,
                        principalTable: "MatchStatistics",
                        principalColumn: "MatchStatisticId");
                    table.ForeignKey(
                        name: "FK_Penalties_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_MatchId",
                table: "Goals",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_MatchStatisticId",
                table: "Goals",
                column: "MatchStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_PlayerId",
                table: "Goals",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_PlayerId1",
                table: "Goals",
                column: "PlayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstTeamTeamId",
                table: "Matches",
                column: "FirstTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SecondTeamTeamId",
                table: "Matches",
                column: "SecondTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StatOfFirstTeamMatchStatisticId",
                table: "Matches",
                column: "StatOfFirstTeamMatchStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StatOfSecondTeamMatchStatisticId",
                table: "Matches",
                column: "StatOfSecondTeamMatchStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_InfractionId",
                table: "Penalties",
                column: "InfractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_MatchStatisticId",
                table: "Penalties",
                column: "MatchStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_PlayerId",
                table: "Penalties",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamStatisticId",
                table: "Teams",
                column: "TeamStatisticId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Penalties");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Infractions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "MatchStatistics");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TeamStatistics");
        }
    }
}
