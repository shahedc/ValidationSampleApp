using Microsoft.EntityFrameworkCore.Migrations;

namespace ValidationMvc.Data.Migrations
{
    public partial class UpdateCinematicItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "CinematicItem");

            migrationBuilder.AddColumn<int>(
                name: "CIType",
                table: "CinematicItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CIType",
                table: "CinematicItem");

            migrationBuilder.AddColumn<int>(
                name: "ItemType",
                table: "CinematicItem",
                nullable: false,
                defaultValue: 0);
        }
    }
}
