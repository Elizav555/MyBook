using System;
using System.Collections.Generic;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyBook;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasIdentityOptions(null, null, 0L);
            });

            modelBuilder.Entity<AuthorBook>(entity =>
            {
                entity.ToTable("author_book");

                entity.HasIndex(e => e.AuthorId, "IX_author_book_AuthorId");

                entity.HasIndex(e => e.BookId, "IX_author_book_BookId");

                entity.Property(e => e.AuthorBookId)
                    .HasColumnName("author_book_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorBooks)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorBooks)
                    .HasForeignKey(d => d.BookId);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.HasIndex(e => e.DescriptionId, "IX_book_DescriptionId")
                    .IsUnique();

                entity.HasIndex(e => e.RatingId, "IX_book_RatingId")
                    .IsUnique();

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Description)
                    .WithOne(p => p.Book)
                    .HasForeignKey<Book>(d => d.DescriptionId);

                entity.HasOne(d => d.Rating)
                    .WithOne(p => p.Book)
                    .HasForeignKey<Book>(d => d.RatingId);
            });

            modelBuilder.Entity<BookCenter>(entity =>
            {
                entity.ToTable("book_center");

                entity.Property(e => e.BookCenterId)
                    .HasColumnName("book_center_id")
                    .HasIdentityOptions(null, null, 0L);
            });

            modelBuilder.Entity<BookDesc>(entity =>
            {
                entity.ToTable("book_desc");

                entity.Property(e => e.BookDescId)
                    .HasColumnName("book_desc_id")
                    .HasIdentityOptions(null, null, 0L);
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.ToTable("book_genre");

                entity.HasIndex(e => e.BookId, "IX_book_genre_BookId");

                entity.HasIndex(e => e.GenreId, "IX_book_genre_GenreId");

                entity.Property(e => e.BookGenreId)
                    .HasColumnName("book_genre_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.BookId);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.GenreId);
            });

            modelBuilder.Entity<DownloadLink>(entity =>
            {
                entity.ToTable("download_link");

                entity.HasIndex(e => e.BookDescId, "IX_download_link_BookDescId");

                entity.Property(e => e.DownloadLinkId)
                    .HasColumnName("download_link_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.BookDesc)
                    .WithMany(p => p.DownloadLinks)
                    .HasForeignKey(d => d.BookDescId);
            });

            modelBuilder.Entity<FavAuthor>(entity =>
            {
                entity.ToTable("fav_author");

                entity.HasIndex(e => e.AuthorId, "IX_fav_author_AuthorId");

                entity.HasIndex(e => e.UserId, "IX_fav_author_UserId");

                entity.Property(e => e.FavAuthorId)
                    .HasColumnName("fav_author_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.FavAuthors)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavAuthors)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<FavGenre>(entity =>
            {
                entity.ToTable("fav_genre");

                entity.HasIndex(e => e.GenreId, "IX_fav_genre_GenreId");

                entity.HasIndex(e => e.UserId, "IX_fav_genre_UserId");

                entity.Property(e => e.FavGenreId)
                    .HasColumnName("fav_genre_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.FavGenres)
                    .HasForeignKey(d => d.GenreId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavGenres)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasIdentityOptions(null, null, 0L);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.HasIndex(e => e.BookId, "IX_history_BookId");

                entity.HasIndex(e => e.UserId, "IX_history_UserId");

                entity.Property(e => e.HistoryId)
                    .HasColumnName("history_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.BookId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ImgLink>(entity =>
            {
                entity.ToTable("img_link");

                entity.HasIndex(e => e.AuthorId, "IX_img_link_AuthorId");

                entity.HasIndex(e => e.BookId, "IX_img_link_BookId");

                entity.Property(e => e.ImgLinkId)
                    .HasColumnName("img_link_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.ImgLinks)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ImgLinks)
                    .HasForeignKey(d => d.BookId);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating");

                entity.HasIndex(e => e.UserId, "IX_rating_UserId");

                entity.Property(e => e.RatingId)
                    .HasColumnName("rating_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<SubscrType>(entity =>
            {
                entity.ToTable("subscr_type");

                entity.HasIndex(e => e.AuthorId, "IX_subscr_type_AuthorId");

                entity.HasIndex(e => e.GenreId, "IX_subscr_type_GenreId");

                entity.Property(e => e.SubscrTypeId)
                    .HasColumnName("subscr_type_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.SubscrTypes)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.SubscrTypes)
                    .HasForeignKey(d => d.GenreId);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.SubscrId);

                entity.ToTable("subscription");

                entity.HasIndex(e => e.TypeId, "IX_subscription_TypeId")
                    .IsUnique();

                entity.Property(e => e.SubscrId)
                    .HasColumnName("subscr_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Type)
                    .WithOne(p => p.Subscription)
                    .HasForeignKey<Subscription>(d => d.TypeId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.InfoId, "IX_user_InfoId")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Info)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.InfoId);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("user_info");

                entity.Property(e => e.UserInfoId)
                    .HasColumnName("user_info_id")
                    .HasIdentityOptions(null, null, 0L);
            });

            modelBuilder.Entity<UserSubscr>(entity =>
            {
                entity.ToTable("user_subscr");

                entity.HasIndex(e => e.SubscriptionId, "IX_user_subscr_SubscriptionId")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_user_subscr_UserId");

                entity.Property(e => e.UserSubscrId)
                    .HasColumnName("user_subscr_id")
                    .HasIdentityOptions(null, null, 0L);

                entity.HasOne(d => d.Subscription)
                    .WithOne(p => p.UserSubscr)
                    .HasForeignKey<UserSubscr>(d => d.SubscriptionId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSubscrs)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
