﻿// <auto-generated />
using System;
using BooksParcer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BooksParcer.Migrations
{
    [DbContext(typeof(MyBookContext))]
    [Migration("20220325191822_InitialMiggration")]
    partial class InitialMiggration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BooksParcer.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorId"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("BooksParcer.AuthorBook", b =>
                {
                    b.Property<int>("AuthorBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("author_book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorBookId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.HasKey("AuthorBookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("author_book", (string)null);
                });

            modelBuilder.Entity("BooksParcer.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookId"));

                    b.Property<int>("DescriptionId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsForAdult")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly?>("PublishedDate")
                        .HasColumnType("date");

                    b.HasKey("BookId");

                    b.HasIndex("DescriptionId")
                        .IsUnique();

                    b.ToTable("book", (string)null);
                });

            modelBuilder.Entity("BooksParcer.BookCenter", b =>
                {
                    b.Property<int>("BookCenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_center_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookCenterId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookCenterId");

                    b.ToTable("book_center", (string)null);
                });

            modelBuilder.Entity("BooksParcer.BookDesc", b =>
                {
                    b.Property<int>("BookDescId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_desc_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookDescId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("PagesCount")
                        .HasColumnType("integer");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.HasKey("BookDescId");

                    b.ToTable("book_desc", (string)null);
                });

            modelBuilder.Entity("BooksParcer.BookGenre", b =>
                {
                    b.Property<int>("BookGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookGenreId"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.HasKey("BookGenreId");

                    b.HasIndex("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("book_genre", (string)null);
                });

            modelBuilder.Entity("BooksParcer.DownloadLink", b =>
                {
                    b.Property<int>("DownloadLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("download_link_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DownloadLinkId"));

                    b.Property<int>("BookDescId")
                        .HasColumnType("integer");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DownloadLinkId");

                    b.HasIndex("BookDescId");

                    b.ToTable("download_link", (string)null);
                });

            modelBuilder.Entity("BooksParcer.FavAuthor", b =>
                {
                    b.Property<int>("FavAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("fav_author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FavAuthorId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("FavAuthorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("fav_author", (string)null);
                });

            modelBuilder.Entity("BooksParcer.FavGenre", b =>
                {
                    b.Property<int>("FavGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("fav_genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FavGenreId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("FavGenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("UserId");

                    b.ToTable("fav_genre", (string)null);
                });

            modelBuilder.Entity("BooksParcer.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GenreId");

                    b.ToTable("genre", (string)null);
                });

            modelBuilder.Entity("BooksParcer.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("history_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HistoryId"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("HistoryId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("history", (string)null);
                });

            modelBuilder.Entity("BooksParcer.ImgLink", b =>
                {
                    b.Property<int>("ImgLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("img_link_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ImgLinkId"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int?>("BookId")
                        .HasColumnType("integer");

                    b.Property<string>("Resolution")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ImgLinkId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("img_link", (string)null);
                });

            modelBuilder.Entity("BooksParcer.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("rating_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RatingId"));

                    b.Property<int>("FK_rating_book_bookId")
                        .HasColumnType("integer");

                    b.Property<int>("FK_rating_user_userId")
                        .HasColumnType("integer");

                    b.Property<double>("Points")
                        .HasColumnType("double precision");

                    b.HasKey("RatingId");

                    b.HasIndex("FK_rating_book_bookId");

                    b.HasIndex("FK_rating_user_userId");

                    b.ToTable("rating", (string)null);
                });

            modelBuilder.Entity("BooksParcer.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subscr_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubscriptionId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("TypeId")
                        .IsUnique();

                    b.ToTable("subscription", (string)null);
                });

            modelBuilder.Entity("BooksParcer.SubscrType", b =>
                {
                    b.Property<int>("SubscrTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subscr_type_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubscrTypeId"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<bool>("ForPaid")
                        .HasColumnType("boolean");

                    b.Property<int?>("GenreId")
                        .HasColumnType("integer");

                    b.HasKey("SubscrTypeId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("subscr_type", (string)null);
                });

            modelBuilder.Entity("BooksParcer.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<int>("InfoId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("InfoId")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("BooksParcer.UserInfo", b =>
                {
                    b.Property<int>("UserInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_info_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserInfoId"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserInfoId");

                    b.ToTable("user_info", (string)null);
                });

            modelBuilder.Entity("BooksParcer.UserSubscr", b =>
                {
                    b.Property<int>("UserSubscrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_subscr_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserSubscrId"));

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserSubscrId");

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("user_subscr", (string)null);
                });

            modelBuilder.Entity("BooksParcer.AuthorBook", b =>
                {
                    b.HasOne("BooksParcer.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksParcer.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BooksParcer.Book", b =>
                {
                    b.HasOne("BooksParcer.BookDesc", "Description")
                        .WithOne("Book")
                        .HasForeignKey("BooksParcer.Book", "DescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Description");
                });

            modelBuilder.Entity("BooksParcer.BookGenre", b =>
                {
                    b.HasOne("BooksParcer.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksParcer.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BooksParcer.DownloadLink", b =>
                {
                    b.HasOne("BooksParcer.BookDesc", "BookDesc")
                        .WithMany("DownloadLinks")
                        .HasForeignKey("BookDescId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookDesc");
                });

            modelBuilder.Entity("BooksParcer.FavAuthor", b =>
                {
                    b.HasOne("BooksParcer.Author", "Author")
                        .WithMany("FavAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksParcer.User", "User")
                        .WithMany("FavAuthors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BooksParcer.FavGenre", b =>
                {
                    b.HasOne("BooksParcer.Genre", "Genre")
                        .WithMany("FavGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksParcer.User", "User")
                        .WithMany("FavGenres")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BooksParcer.History", b =>
                {
                    b.HasOne("BooksParcer.Book", "Book")
                        .WithMany("Histories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksParcer.User", "User")
                        .WithMany("Histories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BooksParcer.ImgLink", b =>
                {
                    b.HasOne("BooksParcer.Author", "Author")
                        .WithMany("ImgLinks")
                        .HasForeignKey("AuthorId");

                    b.HasOne("BooksParcer.Book", "Book")
                        .WithMany("ImgLinks")
                        .HasForeignKey("BookId");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BooksParcer.Rating", b =>
                {
                    b.HasOne("BooksParcer.Book", "Book")
                        .WithMany("Ratings")
                        .HasForeignKey("FK_rating_book_bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksParcer.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("FK_rating_user_userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BooksParcer.Subscription", b =>
                {
                    b.HasOne("BooksParcer.SubscrType", "Type")
                        .WithOne("Subscription")
                        .HasForeignKey("BooksParcer.Subscription", "TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("BooksParcer.SubscrType", b =>
                {
                    b.HasOne("BooksParcer.Author", "Author")
                        .WithMany("SubscrTypes")
                        .HasForeignKey("AuthorId");

                    b.HasOne("BooksParcer.Genre", "Genre")
                        .WithMany("SubscrTypes")
                        .HasForeignKey("GenreId");

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BooksParcer.User", b =>
                {
                    b.HasOne("BooksParcer.UserInfo", "Info")
                        .WithOne("User")
                        .HasForeignKey("BooksParcer.User", "InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Info");
                });

            modelBuilder.Entity("BooksParcer.UserSubscr", b =>
                {
                    b.HasOne("BooksParcer.Subscription", "Subscription")
                        .WithOne("UserSubscr")
                        .HasForeignKey("BooksParcer.UserSubscr", "SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksParcer.User", "User")
                        .WithMany("UserSubscrs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BooksParcer.Author", b =>
                {
                    b.Navigation("AuthorBooks");

                    b.Navigation("FavAuthors");

                    b.Navigation("ImgLinks");

                    b.Navigation("SubscrTypes");
                });

            modelBuilder.Entity("BooksParcer.Book", b =>
                {
                    b.Navigation("AuthorBooks");

                    b.Navigation("BookGenres");

                    b.Navigation("Histories");

                    b.Navigation("ImgLinks");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("BooksParcer.BookDesc", b =>
                {
                    b.Navigation("Book")
                        .IsRequired();

                    b.Navigation("DownloadLinks");
                });

            modelBuilder.Entity("BooksParcer.Genre", b =>
                {
                    b.Navigation("BookGenres");

                    b.Navigation("FavGenres");

                    b.Navigation("SubscrTypes");
                });

            modelBuilder.Entity("BooksParcer.Subscription", b =>
                {
                    b.Navigation("UserSubscr")
                        .IsRequired();
                });

            modelBuilder.Entity("BooksParcer.SubscrType", b =>
                {
                    b.Navigation("Subscription")
                        .IsRequired();
                });

            modelBuilder.Entity("BooksParcer.User", b =>
                {
                    b.Navigation("FavAuthors");

                    b.Navigation("FavGenres");

                    b.Navigation("Histories");

                    b.Navigation("Ratings");

                    b.Navigation("UserSubscrs");
                });

            modelBuilder.Entity("BooksParcer.UserInfo", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}