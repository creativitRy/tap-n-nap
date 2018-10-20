using Microsoft.EntityFrameworkCore.Migrations;

namespace TapNap.Migrations
{
    public partial class Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BedRating_Bed_BedID",
                table: "BedRating");

            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Bed_BedID",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_Rented_Bed_BedID",
                table: "Rented");

            migrationBuilder.DropForeignKey(
                name: "FK_TimePeriod_Bed_BedID",
                table: "TimePeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bed",
                table: "Bed");

            migrationBuilder.RenameTable(
                name: "Bed",
                newName: "Beds");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerHour",
                table: "Beds",
                type: "decimal(7, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beds",
                table: "Beds",
                column: "BedID");

            migrationBuilder.AddForeignKey(
                name: "FK_BedRating_Beds_BedID",
                table: "BedRating",
                column: "BedID",
                principalTable: "Beds",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Beds_BedID",
                table: "Picture",
                column: "BedID",
                principalTable: "Beds",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rented_Beds_BedID",
                table: "Rented",
                column: "BedID",
                principalTable: "Beds",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimePeriod_Beds_BedID",
                table: "TimePeriod",
                column: "BedID",
                principalTable: "Beds",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BedRating_Beds_BedID",
                table: "BedRating");

            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Beds_BedID",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_Rented_Beds_BedID",
                table: "Rented");

            migrationBuilder.DropForeignKey(
                name: "FK_TimePeriod_Beds_BedID",
                table: "TimePeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beds",
                table: "Beds");

            migrationBuilder.RenameTable(
                name: "Beds",
                newName: "Bed");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerHour",
                table: "Bed",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bed",
                table: "Bed",
                column: "BedID");

            migrationBuilder.AddForeignKey(
                name: "FK_BedRating_Bed_BedID",
                table: "BedRating",
                column: "BedID",
                principalTable: "Bed",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Bed_BedID",
                table: "Picture",
                column: "BedID",
                principalTable: "Bed",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rented_Bed_BedID",
                table: "Rented",
                column: "BedID",
                principalTable: "Bed",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimePeriod_Bed_BedID",
                table: "TimePeriod",
                column: "BedID",
                principalTable: "Bed",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
