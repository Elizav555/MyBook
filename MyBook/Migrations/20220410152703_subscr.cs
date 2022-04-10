using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBook.Migrations
{
    public partial class subscr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "subscription");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "subscription");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "types",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "types",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "subscription",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "subscription",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "types");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "types");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "subscription",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "subscription",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "subscription",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "subscription",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
