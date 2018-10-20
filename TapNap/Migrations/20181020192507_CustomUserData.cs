using Microsoft.EntityFrameworkCore.Migrations;

namespace TapNap.Migrations
{
    public partial class CustomUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRenter",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRenter",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
