using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BooksParcer.Migrations
{
    public partial class InitialMiggration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "book_center",
                columns: table => new
                {
                    book_center_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_center", x => x.book_center_id);
                });

            migrationBuilder.CreateTable(
                name: "book_desc",
                columns: table => new
                {
                    book_desc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PagesCount = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_desc", x => x.book_desc_id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "user_info",
                columns: table => new
                {
                    user_info_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_info", x => x.user_info_id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    PublishedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsForAdult = table.Column<bool>(type: "boolean", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    DescriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_book_book_desc_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "book_desc",
                        principalColumn: "book_desc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "download_link",
                columns: table => new
                {
                    download_link_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Format = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    BookDescId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_download_link", x => x.download_link_id);
                    table.ForeignKey(
                        name: "FK_download_link_book_desc_BookDescId",
                        column: x => x.BookDescId,
                        principalTable: "book_desc",
                        principalColumn: "book_desc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscr_type",
                columns: table => new
                {
                    subscr_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ForPaid = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: true),
                    GenreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscr_type", x => x.subscr_type_id);
                    table.ForeignKey(
                        name: "FK_subscr_type_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "author_id");
                    table.ForeignKey(
                        name: "FK_subscr_type_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "genre_id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    InfoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_user_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "user_info",
                        principalColumn: "user_info_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "author_book",
                columns: table => new
                {
                    author_book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author_book", x => x.author_book_id);
                    table.ForeignKey(
                        name: "FK_author_book_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_author_book_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_genre",
                columns: table => new
                {
                    book_genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_genre", x => x.book_genre_id);
                    table.ForeignKey(
                        name: "FK_book_genre_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_genre_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "img_link",
                columns: table => new
                {
                    img_link_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Resolution = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: true),
                    BookId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_img_link", x => x.img_link_id);
                    table.ForeignKey(
                        name: "FK_img_link_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "author_id");
                    table.ForeignKey(
                        name: "FK_img_link_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "book_id");
                });

            migrationBuilder.CreateTable(
                name: "subscription",
                columns: table => new
                {
                    subscr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription", x => x.subscr_id);
                    table.ForeignKey(
                        name: "FK_subscription_subscr_type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "subscr_type",
                        principalColumn: "subscr_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fav_author",
                columns: table => new
                {
                    fav_author_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fav_author", x => x.fav_author_id);
                    table.ForeignKey(
                        name: "FK_fav_author_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fav_author_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fav_genre",
                columns: table => new
                {
                    fav_genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fav_genre", x => x.fav_genre_id);
                    table.ForeignKey(
                        name: "FK_fav_genre_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fav_genre_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    history_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history", x => x.history_id);
                    table.ForeignKey(
                        name: "FK_history_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_history_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    rating_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Points = table.Column<double>(type: "double precision", nullable: false),
                    FK_rating_user_userId = table.Column<int>(type: "integer", nullable: false),
                    FK_rating_book_bookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.rating_id);
                    table.ForeignKey(
                        name: "FK_rating_book_FK_rating_book_bookId",
                        column: x => x.FK_rating_book_bookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rating_user_FK_rating_user_userId",
                        column: x => x.FK_rating_user_userId,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_subscr",
                columns: table => new
                {
                    user_subscr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_subscr", x => x.user_subscr_id);
                    table.ForeignKey(
                        name: "FK_user_subscr_subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "subscription",
                        principalColumn: "subscr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_subscr_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_author_book_AuthorId",
                table: "author_book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_author_book_BookId",
                table: "author_book",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_book_DescriptionId",
                table: "book",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_BookId",
                table: "book_genre",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_GenreId",
                table: "book_genre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_download_link_BookDescId",
                table: "download_link",
                column: "BookDescId");

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

            migrationBuilder.CreateIndex(
                name: "IX_history_BookId",
                table: "history",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_history_UserId",
                table: "history",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_img_link_AuthorId",
                table: "img_link",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_img_link_BookId",
                table: "img_link",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_rating_FK_rating_book_bookId",
                table: "rating",
                column: "FK_rating_book_bookId");

            migrationBuilder.CreateIndex(
                name: "IX_rating_FK_rating_user_userId",
                table: "rating",
                column: "FK_rating_user_userId");

            migrationBuilder.CreateIndex(
                name: "IX_subscr_type_AuthorId",
                table: "subscr_type",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_subscr_type_GenreId",
                table: "subscr_type",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_TypeId",
                table: "subscription",
                column: "TypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_InfoId",
                table: "user",
                column: "InfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_subscr_SubscriptionId",
                table: "user_subscr",
                column: "SubscriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_subscr_UserId",
                table: "user_subscr",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author_book");

            migrationBuilder.DropTable(
                name: "book_center");

            migrationBuilder.DropTable(
                name: "book_genre");

            migrationBuilder.DropTable(
                name: "download_link");

            migrationBuilder.DropTable(
                name: "fav_author");

            migrationBuilder.DropTable(
                name: "fav_genre");

            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "img_link");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "user_subscr");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "subscription");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "book_desc");

            migrationBuilder.DropTable(
                name: "subscr_type");

            migrationBuilder.DropTable(
                name: "user_info");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "genre");
        }
    }
}
