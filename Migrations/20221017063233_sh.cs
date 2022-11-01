using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineHotelManagementAPI.Migrations
{
    public partial class sh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NIC",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Staffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NIC",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
