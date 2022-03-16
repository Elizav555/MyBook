using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBook.Migrations
{
    public partial class SomeChangesx2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "author");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "author");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PublishedDate",
                table: "book",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "author",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "author");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PublishedDate",
                table: "book",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "author",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "author",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
