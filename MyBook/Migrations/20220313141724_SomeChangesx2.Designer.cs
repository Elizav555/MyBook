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
    [Migration("20220313141724_SomeChangesx2")]
    partial class SomeChangesx2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Russian_Russia.1251")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyBook.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.AuthorBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("author_book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("author_book", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

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

                    b.Property<int>("RatingId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId")
                        .IsUnique();

                    b.HasIndex("RatingId")
                        .IsUnique();

                    b.ToTable("book", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.BookCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_center_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

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

                    b.HasKey("Id");

                    b.ToTable("book_center", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.BookDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_desc_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("PagesCount")
                        .HasColumnType("integer");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("book_desc", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.BookGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("book_genre", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.DownloadLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("download_link_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<int>("BookDescId")
                        .HasColumnType("integer");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookDescId");

                    b.ToTable("download_link", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.FavAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("fav_author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("fav_author", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.FavGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("fav_genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("UserId");

                    b.ToTable("fav_genre", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("genre", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("history_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("history", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.ImgLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("img_link_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int?>("BookId")
                        .HasColumnType("integer");

                    b.Property<string>("Resolution")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("img_link", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("rating_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<double>("Points")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("rating", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subscr_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

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

                    b.HasKey("Id");

                    b.HasIndex("TypeId")
                        .IsUnique();

                    b.ToTable("subscription", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.SubscriptionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subscr_type_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<bool>("ForPaid")
                        .HasColumnType("boolean");

                    b.Property<int?>("GenreId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("subscr_type", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

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

                    b.HasKey("Id");

                    b.HasIndex("InfoId")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_info_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("user_info", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.UserSubscriptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_subscr_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 0L, null, 0L, null, null, null);

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("user_subscr", (string)null);
                });

            modelBuilder.Entity("MyBook.Entities.AuthorBook", b =>
                {
                    b.HasOne("MyBook.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.Book", "Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("MyBook.Entities.Book", b =>
                {
                    b.HasOne("MyBook.Entities.BookDescription", "Description")
                        .WithOne("Book")
                        .HasForeignKey("MyBook.Entities.Book", "DescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.Rating", "Rating")
                        .WithOne("Book")
                        .HasForeignKey("MyBook.Entities.Book", "RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Description");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("MyBook.Entities.BookGenre", b =>
                {
                    b.HasOne("MyBook.Entities.Book", "Book")
                        .WithMany("Genres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MyBook.Entities.DownloadLink", b =>
                {
                    b.HasOne("MyBook.Entities.BookDescription", "BookDesc")
                        .WithMany("DownloadLinks")
                        .HasForeignKey("BookDescId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookDesc");
                });

            modelBuilder.Entity("MyBook.Entities.FavAuthor", b =>
                {
                    b.HasOne("MyBook.Entities.Author", "Author")
                        .WithMany("Fans")
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
                        .WithMany("Fans")
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
                        .WithMany("Readers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.User", "User")
                        .WithMany("History")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBook.Entities.ImgLink", b =>
                {
                    b.HasOne("MyBook.Entities.Author", "Author")
                        .WithMany("Images")
                        .HasForeignKey("AuthorId");

                    b.HasOne("MyBook.Entities.Book", "Book")
                        .WithMany("Images")
                        .HasForeignKey("BookId");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("MyBook.Entities.Rating", b =>
                {
                    b.HasOne("MyBook.Entities.User", "User")
                        .WithMany("Marks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBook.Entities.Subscription", b =>
                {
                    b.HasOne("MyBook.Entities.SubscriptionType", "Type")
                        .WithOne("Subscription")
                        .HasForeignKey("MyBook.Entities.Subscription", "TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("MyBook.Entities.SubscriptionType", b =>
                {
                    b.HasOne("MyBook.Entities.Author", "Author")
                        .WithMany("Followers")
                        .HasForeignKey("AuthorId");

                    b.HasOne("MyBook.Entities.Genre", "Genre")
                        .WithMany("Followers")
                        .HasForeignKey("GenreId");

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MyBook.Entities.User", b =>
                {
                    b.HasOne("MyBook.Entities.UserInfo", "UserInfo")
                        .WithOne("User")
                        .HasForeignKey("MyBook.Entities.User", "InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("MyBook.Entities.UserSubscriptions", b =>
                {
                    b.HasOne("MyBook.Entities.Subscription", "Subscription")
                        .WithOne("User")
                        .HasForeignKey("MyBook.Entities.UserSubscriptions", "SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Entities.User", "User")
                        .WithMany("Subscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBook.Entities.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Fans");

                    b.Navigation("Followers");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("MyBook.Entities.Book", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Genres");

                    b.Navigation("Images");

                    b.Navigation("Readers");
                });

            modelBuilder.Entity("MyBook.Entities.BookDescription", b =>
                {
                    b.Navigation("Book")
                        .IsRequired();

                    b.Navigation("DownloadLinks");
                });

            modelBuilder.Entity("MyBook.Entities.Genre", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Fans");

                    b.Navigation("Followers");
                });

            modelBuilder.Entity("MyBook.Entities.Rating", b =>
                {
                    b.Navigation("Book")
                        .IsRequired();
                });

            modelBuilder.Entity("MyBook.Entities.Subscription", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("MyBook.Entities.SubscriptionType", b =>
                {
                    b.Navigation("Subscription")
                        .IsRequired();
                });

            modelBuilder.Entity("MyBook.Entities.User", b =>
                {
                    b.Navigation("FavAuthors");

                    b.Navigation("FavGenres");

                    b.Navigation("History");

                    b.Navigation("Marks");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("MyBook.Entities.UserInfo", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
