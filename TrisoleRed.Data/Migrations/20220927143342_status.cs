using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrisoleRed.Data.Migrations
{
    public partial class status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "PropertiesDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PropertiesDetails");
        }
    }
}
