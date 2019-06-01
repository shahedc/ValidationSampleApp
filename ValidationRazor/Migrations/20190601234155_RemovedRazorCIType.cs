using Microsoft.EntityFrameworkCore.Migrations;

namespace ValidationRazor.Migrations
{
    public partial class RemovedRazorCIType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CIType",
                table: "CinematicItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CIType",
                table: "CinematicItem",
                nullable: false,
                defaultValue: 0);
        }
    }
}
