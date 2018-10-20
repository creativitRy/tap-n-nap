using Microsoft.EntityFrameworkCore.Migrations;

namespace TapNap.Migrations
{
    public partial class MisspelledVar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "numRatings",
                table: "AspNetUsers",
                newName: "NumRatings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumRatings",
                table: "AspNetUsers",
                newName: "numRatings");
        }
    }
}
