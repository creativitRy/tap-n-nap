using Microsoft.EntityFrameworkCore.Migrations;

namespace TapNap.Migrations
{
    public partial class FixedForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rented_Beds_BedID",
                table: "Rented");

            migrationBuilder.DropForeignKey(
                name: "FK_Rented_AspNetUsers_UserID",
                table: "Rented");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rented",
                table: "Rented");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Rented",
                newName: "Renteds");

            migrationBuilder.RenameIndex(
                name: "IX_Rented_UserID",
                table: "Renteds",
                newName: "IX_Renteds_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Rented_BedID",
                table: "Renteds",
                newName: "IX_Renteds_BedID");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Beds",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Renteds",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "BedID",
                table: "Renteds",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Renteds",
                table: "Renteds",
                column: "RentedID");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_UserID",
                table: "Beds",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_AspNetUsers_UserID",
                table: "Beds",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Renteds_Beds_BedID",
                table: "Renteds",
                column: "BedID",
                principalTable: "Beds",
                principalColumn: "BedID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Renteds_AspNetUsers_UserID",
                table: "Renteds",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_AspNetUsers_UserID",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_Renteds_Beds_BedID",
                table: "Renteds");

            migrationBuilder.DropForeignKey(
                name: "FK_Renteds_AspNetUsers_UserID",
                table: "Renteds");

            migrationBuilder.DropIndex(
                name: "IX_Beds_UserID",
                table: "Beds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Renteds",
                table: "Renteds");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Beds");

            migrationBuilder.RenameTable(
                name: "Renteds",
                newName: "Rented");

            migrationBuilder.RenameIndex(
                name: "IX_Renteds_UserID",
                table: "Rented",
                newName: "IX_Rented_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Renteds_BedID",
                table: "Rented",
                newName: "IX_Rented_BedID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Picture",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Rented",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BedID",
                table: "Rented",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rented",
                table: "Rented",
                column: "RentedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rented_Beds_BedID",
                table: "Rented",
                column: "BedID",
                principalTable: "Beds",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rented_AspNetUsers_UserID",
                table: "Rented",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
