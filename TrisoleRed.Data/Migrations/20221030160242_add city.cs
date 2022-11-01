using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrisoleRed.Data.Migrations
{
    public partial class addcity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PropertiesDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "PropertiesDetails");
        }
    }
}
