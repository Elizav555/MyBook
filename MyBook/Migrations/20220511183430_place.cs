using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBook.Migrations
{
    public partial class place : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "book_center",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "book_center",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "book_center");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "book_center");
        }
    }
}
