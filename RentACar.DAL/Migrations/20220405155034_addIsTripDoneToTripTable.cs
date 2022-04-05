using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.DAL.Migrations
{
    public partial class addIsTripDoneToTripTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTripDone",
                table: "Trips",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTripDone",
                table: "Trips");
        }
    }
}
