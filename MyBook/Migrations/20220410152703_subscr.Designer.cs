﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBook.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBook.Migrations
{
    [DbContext(typeof(MyBookContext))]
    [Migration("20220410152703_subscr")]
    partial class subscr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("BirthDate")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.AuthorBook", b =>
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

            modelBuilder.Entity("MyBook.Entities.Book", b =>
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

                    b.Property<string>("PublishedDate")
                        .HasColumnType("text");

                    b.HasKey("BookId");

                    b.HasIndex("DescriptionId")
                        .IsUnique();

                    b.ToTable("book", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.BookCenter", b =>
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

            modelBuilder.Entity("MyBook.Entities.BookDesc", b =>
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

            modelBuilder.Entity("MyBook.Entities.BookGenre", b =>
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

            modelBuilder.Entity("MyBook.Entities.DownloadLink", b =>
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

            modelBuilder.Entity("MyBook.Entities.FavAuthor", b =>
                {
                    b.Property<int>("FavAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("fav_author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FavAuthorId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FavAuthorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("fav_author", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.FavGenre", b =>
                {
                    b.Property<int>("FavGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("fav_genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FavGenreId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FavGenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("UserId");

                    b.ToTable("fav_genre", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.Genre", b =>
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

            modelBuilder.Entity("MyBook.Entities.History", b =>
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("HistoryId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("history", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.ImgLink", b =>
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

            modelBuilder.Entity("MyBook.Entities.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("rating_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RatingId"));

                    b.Property<int>("FK_rating_book_bookId")
                        .HasColumnType("integer");

                    b.Property<string>("FK_rating_user_userId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Points")
                        .HasColumnType("double precision");

                    b.HasKey("RatingId");

                    b.HasIndex("FK_rating_book_bookId");

                    b.HasIndex("FK_rating_user_userId");

                    b.ToTable("rating", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.SubscrAuthor", b =>
                {
                    b.Property<int>("SubscrAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subscr_author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubscrAuthorId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.HasKey("SubscrAuthorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("subscr_author", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.SubscrGenre", b =>
                {
                    b.Property<int>("SubscrGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subscr_genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubscrGenreId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.HasKey("SubscrGenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("subsc_genre", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subscr_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubscriptionId"));

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FK_subscr_user_subscr_user_subscr_id")
                        .HasColumnType("integer");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("FK_subscr_user_subscr_user_subscr_id")
                        .IsUnique();

                    b.ToTable("subscription", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.SubscrType", b =>
                {
                    b.Property<int>("SubscrTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subscr_type_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubscrTypeId"));

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("SubscrTypeId");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("TypeId");

                    b.ToTable("subscr_type", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("type_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TypeId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TypeId");

                    b.ToTable("types", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.UserSubscr", b =>
                {
                    b.Property<int>("UserSubscrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_subscr_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserSubscrId"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserSubscrId");

                    b.HasIndex("UserId");

                    b.ToTable("user_subscr", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyBook.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyBook.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyBook.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBook.Entities.AuthorBook", b =>
                {
                    b.HasOne("MyBook.Entities.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("MyBook.Entities.Book", b =>
                {
                    b.HasOne("MyBook.Entities.BookDesc", "Description")
                        .WithOne("Book")
                        .HasForeignKey("MyBook.Entities.Book", "DescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Description");
                });

            modelBuilder.Entity("MyBook.Entities.BookGenre", b =>
                {
                    b.HasOne("MyBook.Entities.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MyBook.Entities.DownloadLink", b =>
                {
                    b.HasOne("MyBook.Entities.BookDesc", "BookDesc")
                        .WithMany("DownloadLinks")
                        .HasForeignKey("BookDescId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookDesc");
                });

            modelBuilder.Entity("MyBook.Entities.FavAuthor", b =>
                {
                    b.HasOne("MyBook.Entities.Author", "Author")
                        .WithMany("FavAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.User", "User")
                        .WithMany("FavAuthors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBook.Entities.FavGenre", b =>
                {
                    b.HasOne("MyBook.Entities.Genre", "Genre")
                        .WithMany("FavGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.User", "User")
                        .WithMany("FavGenres")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBook.Entities.History", b =>
                {
                    b.HasOne("MyBook.Entities.Book", "Book")
                        .WithMany("Histories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.User", "User")
                        .WithMany("Histories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBook.Entities.ImgLink", b =>
                {
                    b.HasOne("MyBook.Entities.Author", "Author")
                        .WithMany("ImgLinks")
                        .HasForeignKey("AuthorId");

                    b.HasOne("MyBook.Entities.Book", "Book")
                        .WithMany("ImgLinks")
                        .HasForeignKey("BookId");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("MyBook.Entities.Rating", b =>
                {
                    b.HasOne("MyBook.Entities.Book", "Book")
                        .WithMany("Ratings")
                        .HasForeignKey("FK_rating_book_bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("FK_rating_user_userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBook.Entities.SubscrAuthor", b =>
                {
                    b.HasOne("MyBook.Entities.Author", "Author")
                        .WithMany("SubscrAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.Subscription", "Subscr")
                        .WithMany("SubscrAuthors")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Subscr");
                });

            modelBuilder.Entity("MyBook.Entities.SubscrGenre", b =>
                {
                    b.HasOne("MyBook.Entities.Genre", "Genre")
                        .WithMany("SubscrGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.Subscription", "Subscr")
                        .WithMany("SubscrGenres")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Subscr");
                });

            modelBuilder.Entity("MyBook.Entities.Subscription", b =>
                {
                    b.HasOne("MyBook.Entities.UserSubscr", "UserSubscr")
                        .WithOne("Subscription")
                        .HasForeignKey("MyBook.Entities.Subscription", "FK_subscr_user_subscr_user_subscr_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserSubscr");
                });

            modelBuilder.Entity("MyBook.Entities.SubscrType", b =>
                {
                    b.HasOne("MyBook.Entities.Subscription", "Subscription")
                        .WithMany("SubscrTypes")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.Type", "Type")
                        .WithMany("SubscrTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("MyBook.Entities.UserSubscr", b =>
                {
                    b.HasOne("MyBook.Entities.User", "User")
                        .WithMany("UserSubscrs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBook.Entities.Author", b =>
                {
                    b.Navigation("AuthorBooks");

                    b.Navigation("FavAuthors");

                    b.Navigation("ImgLinks");

                    b.Navigation("SubscrAuthors");
                });

            modelBuilder.Entity("MyBook.Entities.Book", b =>
                {
                    b.Navigation("AuthorBooks");

                    b.Navigation("BookGenres");

                    b.Navigation("Histories");

                    b.Navigation("ImgLinks");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("MyBook.Entities.BookDesc", b =>
                {
                    b.Navigation("Book")
                        .IsRequired();

                    b.Navigation("DownloadLinks");
                });

            modelBuilder.Entity("MyBook.Entities.Genre", b =>
                {
                    b.Navigation("BookGenres");

                    b.Navigation("FavGenres");

                    b.Navigation("SubscrGenres");
                });

            modelBuilder.Entity("MyBook.Entities.Subscription", b =>
                {
                    b.Navigation("SubscrAuthors");

                    b.Navigation("SubscrGenres");

                    b.Navigation("SubscrTypes");
                });

            modelBuilder.Entity("MyBook.Entities.Type", b =>
                {
                    b.Navigation("SubscrTypes");
                });

            modelBuilder.Entity("MyBook.Entities.User", b =>
                {
                    b.Navigation("FavAuthors");

                    b.Navigation("FavGenres");

                    b.Navigation("Histories");

                    b.Navigation("Ratings");

                    b.Navigation("UserSubscrs");
                });

            modelBuilder.Entity("MyBook.Entities.UserSubscr", b =>
                {
                    b.Navigation("Subscription")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
