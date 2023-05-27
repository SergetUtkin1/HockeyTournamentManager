using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleInterface.Migrations
{
    /// <inheritdoc />
    public partial class FixMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamStatistics_TeamStatisticId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamStatId",
                table: "Teams");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamStatisticId",
                table: "Teams",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "Players",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamStatistics_TeamStatisticId",
                table: "Teams",
                column: "TeamStatisticId",
                principalTable: "TeamStatistics",
                principalColumn: "TeamStatisticId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamStatistics_TeamStatisticId",
                table: "Teams");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamStatisticId",
                table: "Teams",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeamStatId",
                table: "Teams",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "Players",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamStatistics_TeamStatisticId",
                table: "Teams",
                column: "TeamStatisticId",
                principalTable: "TeamStatistics",
                principalColumn: "TeamStatisticId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
