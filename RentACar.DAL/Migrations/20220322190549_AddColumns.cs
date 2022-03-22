using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.DAL.Migrations
{
    public partial class AddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Country_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Km_Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Country_Id);
                });

            migrationBuilder.CreateTable(
                name: "Desktops",
                columns: table => new
                {
                    Desktop_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desktops", x => x.Desktop_Id);
                    table.ForeignKey(
                        name: "FK_Desktops_Countries_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Countries",
                        principalColumn: "Country_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Car_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Km_Start = table.Column<long>(type: "bigint", nullable: false),
                    Km_End = table.Column<long>(type: "bigint", nullable: false),
                    Desktop_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Car_Id);
                    table.ForeignKey(
                        name: "FK_Cars_Desktops_Desktop_Id",
                        column: x => x.Desktop_Id,
                        principalTable: "Desktops",
                        principalColumn: "Desktop_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Package_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Km_Limit = table.Column<double>(type: "float", nullable: false),
                    Desktop_Start_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Desktop_StartDesktop_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Desktop_End_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Desktop_EndDesktop_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Package_Id);
                    table.ForeignKey(
                        name: "FK_Packages_Desktops_Desktop_EndDesktop_Id",
                        column: x => x.Desktop_EndDesktop_Id,
                        principalTable: "Desktops",
                        principalColumn: "Desktop_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Packages_Desktops_Desktop_StartDesktop_Id",
                        column: x => x.Desktop_StartDesktop_Id,
                        principalTable: "Desktops",
                        principalColumn: "Desktop_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Trip_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPackage = table.Column<bool>(type: "bit", nullable: false),
                    Car_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Desktop_Start_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Desktop_StartDesktop_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Desktop_End_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Desktop_EndDesktop_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Trip_Id);
                    table.ForeignKey(
                        name: "FK_Trips_Cars_Car_Id",
                        column: x => x.Car_Id,
                        principalTable: "Cars",
                        principalColumn: "Car_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Desktops_Desktop_EndDesktop_Id",
                        column: x => x.Desktop_EndDesktop_Id,
                        principalTable: "Desktops",
                        principalColumn: "Desktop_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Desktops_Desktop_StartDesktop_Id",
                        column: x => x.Desktop_StartDesktop_Id,
                        principalTable: "Desktops",
                        principalColumn: "Desktop_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Desktop_Id",
                table: "Cars",
                column: "Desktop_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Desktops_Country_Id",
                table: "Desktops",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Desktop_EndDesktop_Id",
                table: "Packages",
                column: "Desktop_EndDesktop_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Desktop_StartDesktop_Id",
                table: "Packages",
                column: "Desktop_StartDesktop_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Car_Id",
                table: "Trips",
                column: "Car_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Desktop_EndDesktop_Id",
                table: "Trips",
                column: "Desktop_EndDesktop_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Desktop_StartDesktop_Id",
                table: "Trips",
                column: "Desktop_StartDesktop_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Desktops");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
