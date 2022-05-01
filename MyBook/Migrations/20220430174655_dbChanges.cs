using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBook.Migrations
{
    public partial class dbChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fav_author");

            migrationBuilder.DropTable(
                name: "fav_genre");

            migrationBuilder.AddColumn<string>(
                name: "ReviewText",
                table: "rating",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DownloadsCount",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewText",
                table: "rating");

            migrationBuilder.DropColumn(
                name: "DownloadsCount",
                table: "book");

            migrationBuilder.CreateTable(
                name: "fav_author",
                columns: table => new
                {
                    fav_author_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fav_author", x => x.fav_author_id);
                    table.ForeignKey(
                        name: "FK_fav_author_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fav_author_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fav_genre",
                columns: table => new
                {
                    fav_genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fav_genre", x => x.fav_genre_id);
                    table.ForeignKey(
                        name: "FK_fav_genre_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fav_genre_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fav_author_AuthorId",
                table: "fav_author",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_fav_author_UserId",
                table: "fav_author",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_fav_genre_GenreId",
                table: "fav_genre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_fav_genre_UserId",
                table: "fav_genre",
                column: "UserId");
        }
    }
}
