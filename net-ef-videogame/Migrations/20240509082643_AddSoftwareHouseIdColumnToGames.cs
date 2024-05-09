using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftwareHouseIdColumnToGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "software_house_id",
                table: "games",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_games_software_house_id",
                table: "games",
                column: "software_house_id");

            migrationBuilder.AddForeignKey(
                name: "FK_games_software_house_software_house_id",
                table: "games",
                column: "software_house_id",
                principalTable: "software_house",
                principalColumn: "SoftwareHouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_games_software_house_software_house_id",
                table: "games");

            migrationBuilder.DropIndex(
                name: "IX_games_software_house_id",
                table: "games");

            migrationBuilder.DropColumn(
                name: "software_house_id",
                table: "games");
        }
    }
}
