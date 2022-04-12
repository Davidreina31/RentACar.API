using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.DAL.Migrations
{
    public partial class addImageUrlToDesktopTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Desktops",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Desktops");
        }
    }
}
