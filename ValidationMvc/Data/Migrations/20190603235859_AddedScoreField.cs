using Microsoft.EntityFrameworkCore.Migrations;

namespace ValidationMvc.Data.Migrations
{
    public partial class AddedScoreField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "CinematicItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "CinematicItem");
        }
    }
}
