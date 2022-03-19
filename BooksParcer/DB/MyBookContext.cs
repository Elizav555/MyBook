using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BooksParcer
{
    public partial class MyBookContext : DbContext
    {
        public MyBookContext()
        {
        }

        public MyBookContext(DbContextOptions<MyBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<AuthorBook> AuthorBooks { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookCenter> BookCenters { get; set; } = null!;
        public virtual DbSet<BookDesc> BookDescs { get; set; } = null!;
        public virtual DbSet<BookGenre> BookGenres { get; set; } = null!;
        public virtual DbSet<DownloadLink> DownloadLinks { get; set; } = null!;
        public virtual DbSet<FavAuthor> FavAuthors { get; set; } = null!;
        public virtual DbSet<FavGenre> FavGenres { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<ImgLink> ImgLinks { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<SubscrType> SubscrTypes { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;
        public virtual DbSet<UserSubscr> UserSubscrs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Port=5432;Database=MyBook;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    ;
            });

            modelBuilder.Entity<AuthorBook>(entity =>
            {
                entity.ToTable("author_book");

                entity.Property(e => e.AuthorBookId)
                    .HasColumnName("author_book_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorBooks);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorBooks);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id");

                entity.HasOne(d => d.Description)
                    .WithOne(p => p.Book)
                    .HasForeignKey<Book>(b => b.DescriptionId);
            });

            modelBuilder.Entity<BookCenter>(entity =>
            {
                entity.ToTable("book_center");

                entity.Property(e => e.BookCenterId)
                    .HasColumnName("book_center_id")
                    ;
            });

            modelBuilder.Entity<BookDesc>(entity =>
            {
                entity.ToTable("book_desc");

                entity.Property(e => e.BookDescId)
                    .HasColumnName("book_desc_id")
                    ;
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.ToTable("book_genre");

                entity.Property(e => e.BookGenreId)
                    .HasColumnName("book_genre_id")
                    ;

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookGenres);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BookGenres);
            });

            modelBuilder.Entity<DownloadLink>(entity =>
            {
                entity.ToTable("download_link");

                entity.Property(e => e.DownloadLinkId)
                    .HasColumnName("download_link_id")
                    ;

                entity.HasOne(d => d.BookDesc)
                    .WithMany(p => p.DownloadLinks);
            });

            modelBuilder.Entity<FavAuthor>(entity =>
            {
                entity.ToTable("fav_author");

                entity.Property(e => e.FavAuthorId)
                    .HasColumnName("fav_author_id")
                    ;

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.FavAuthors);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavAuthors);
            });

            modelBuilder.Entity<FavGenre>(entity =>
            {
                entity.ToTable("fav_genre");

                entity.Property(e => e.FavGenreId)
                    .HasColumnName("fav_genre_id")
                    ;

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.FavGenres);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavGenres);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    ;
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.Property(e => e.HistoryId)
                    .HasColumnName("history_id")
                    ;

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Histories);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Histories);
            });

            modelBuilder.Entity<ImgLink>(entity =>
            {
                entity.ToTable("img_link");

                entity.Property(e => e.ImgLinkId)
                    .HasColumnName("img_link_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.ImgLinks);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ImgLinks);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating");

                entity.Property(e => e.RatingId)
                    .HasColumnName("rating_id");

                entity.HasOne(p => p.Book)
                    .WithMany(b => b.Ratings);

                entity.HasOne(p => p.User)
                    .WithMany(b => b.Ratings);
            });

            modelBuilder.Entity<SubscrType>(entity =>
            {
                entity.ToTable("subscr_type");

                entity.Property(e => e.SubscrTypeId)
                    .HasColumnName("subscr_type_id")
                    ;

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.SubscrTypes);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.SubscrTypes);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscription");

                entity.Property(e => e.SubscriptionId)
                    .HasColumnName("subscr_id")
                    ;

                entity.HasOne(d => d.Type)
                    .WithOne(p => p.Subscription)
                    .HasForeignKey<Subscription>(b => b.TypeId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    ;

                entity.HasOne(d => d.Info)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(u => u.InfoId);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("user_info");

                entity.Property(e => e.UserInfoId)
                    .HasColumnName("user_info_id")
                    ;
            });

            modelBuilder.Entity<UserSubscr>(entity =>
            {
                entity.ToTable("user_subscr");

                entity.Property(e => e.UserSubscrId)
                    .HasColumnName("user_subscr_id")
                    ;

                entity.HasOne(d => d.Subscription)
                    .WithOne(p => p.UserSubscr)
                    .HasForeignKey<UserSubscr>(s => s.SubscriptionId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSubscrs);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}