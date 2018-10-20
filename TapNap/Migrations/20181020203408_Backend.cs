using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TapNap.Migrations
{
    public partial class Backend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SumOfRatings",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numRatings",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bed",
                columns: table => new
                {
                    BedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PricePerHour = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.BedID);
                });

            migrationBuilder.CreateTable(
                name: "BedRating",
                columns: table => new
                {
                    BedRatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    BedID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedRating", x => x.BedRatingID);
                    table.ForeignKey(
                        name: "FK_BedRating_Bed_BedID",
                        column: x => x.BedID,
                        principalTable: "Bed",
                        principalColumn: "BedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    PictureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Src = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BedID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.PictureID);
                    table.ForeignKey(
                        name: "FK_Picture_Bed_BedID",
                        column: x => x.BedID,
                        principalTable: "Bed",
                        principalColumn: "BedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rented",
                columns: table => new
                {
                    RentedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    BedID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rented", x => x.RentedID);
                    table.ForeignKey(
                        name: "FK_Rented_Bed_BedID",
                        column: x => x.BedID,
                        principalTable: "Bed",
                        principalColumn: "BedID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rented_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimePeriod",
                columns: table => new
                {
                    TimePeriodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    BedID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePeriod", x => x.TimePeriodID);
                    table.ForeignKey(
                        name: "FK_TimePeriod_Bed_BedID",
                        column: x => x.BedID,
                        principalTable: "Bed",
                        principalColumn: "BedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BedRating_BedID",
                table: "BedRating",
                column: "BedID");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_BedID",
                table: "Picture",
                column: "BedID");

            migrationBuilder.CreateIndex(
                name: "IX_Rented_BedID",
                table: "Rented",
                column: "BedID");

            migrationBuilder.CreateIndex(
                name: "IX_Rented_UserID",
                table: "Rented",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TimePeriod_BedID",
                table: "TimePeriod",
                column: "BedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BedRating");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Rented");

            migrationBuilder.DropTable(
                name: "TimePeriod");

            migrationBuilder.DropTable(
                name: "Bed");

            migrationBuilder.DropColumn(
                name: "SumOfRatings",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "numRatings",
                table: "AspNetUsers");
        }
    }
}
