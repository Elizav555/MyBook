using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBook.Migrations
{
    public partial class subscrChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subsc_genre");

            migrationBuilder.DropTable(
                name: "subscr_author");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "subscription",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "subscription",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subscription_AuthorId",
                table: "subscription",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_GenreId",
                table: "subscription",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_subscription_author_AuthorId",
                table: "subscription",
                column: "AuthorId",
                principalTable: "author",
                principalColumn: "author_id");

            migrationBuilder.AddForeignKey(
                name: "FK_subscription_genre_GenreId",
                table: "subscription",
                column: "GenreId",
                principalTable: "genre",
                principalColumn: "genre_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscription_author_AuthorId",
                table: "subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_subscription_genre_GenreId",
                table: "subscription");

            migrationBuilder.DropIndex(
                name: "IX_subscription_AuthorId",
                table: "subscription");

            migrationBuilder.DropIndex(
                name: "IX_subscription_GenreId",
                table: "subscription");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "subscription");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "subscription");

            migrationBuilder.CreateTable(
                name: "subsc_genre",
                columns: table => new
                {
                    subscr_genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subsc_genre", x => x.subscr_genre_id);
                    table.ForeignKey(
                        name: "FK_subsc_genre_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subsc_genre_subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "subscription",
                        principalColumn: "subscr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscr_author",
                columns: table => new
                {
                    subscr_author_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscr_author", x => x.subscr_author_id);
                    table.ForeignKey(
                        name: "FK_subscr_author_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subscr_author_subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "subscription",
                        principalColumn: "subscr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subsc_genre_GenreId",
                table: "subsc_genre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_subsc_genre_SubscriptionId",
                table: "subsc_genre",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_subscr_author_AuthorId",
                table: "subscr_author",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_subscr_author_SubscriptionId",
                table: "subscr_author",
                column: "SubscriptionId");
        }
    }
}
