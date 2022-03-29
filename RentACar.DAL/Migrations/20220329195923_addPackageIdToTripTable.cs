using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.DAL.Migrations
{
    public partial class addPackageIdToTripTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Package_Id",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Package_Id",
                table: "Trips",
                column: "Package_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Packages_Package_Id",
                table: "Trips",
                column: "Package_Id",
                principalTable: "Packages",
                principalColumn: "Package_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Packages_Package_Id",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_Package_Id",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Package_Id",
                table: "Trips");
        }
    }
}
