using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.DAL.Migrations
{
    public partial class addClientsDataToTripTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client_Email",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client_FirstName",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client_LastName",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client_Email",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Client_FirstName",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Client_LastName",
                table: "Trips");
        }
    }
}
