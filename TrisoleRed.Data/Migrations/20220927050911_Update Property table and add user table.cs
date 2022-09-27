using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrisoleRed.Data.Migrations
{
    public partial class UpdatePropertytableandaddusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "images",
                table: "PropertiesDetails",
                newName: "Images");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "PropertiesDetails",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "area",
                table: "PropertiesDetails",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PropertiesDetails",
                newName: "PropertiesName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Images",
                table: "PropertiesDetails",
                newName: "images");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "PropertiesDetails",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "PropertiesDetails",
                newName: "area");

            migrationBuilder.RenameColumn(
                name: "PropertiesName",
                table: "PropertiesDetails",
                newName: "Name");
        }
    }
}
