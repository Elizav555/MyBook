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

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
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
        public virtual DbSet<SubscGenre> SubscGenres { get; set; } = null!;
        public virtual DbSet<SubscrAuthor> SubscrAuthors { get; set; } = null!;
        public virtual DbSet<SubscrType> SubscrTypes { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
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
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");
            });

            modelBuilder.Entity<AuthorBook>(entity =>
            {
                entity.ToTable("author_book");

                entity.HasIndex(e => e.AuthorId, "IX_author_book_AuthorId");

                entity.HasIndex(e => e.BookId, "IX_author_book_BookId");

                entity.Property(e => e.AuthorBookId).HasColumnName("author_book_id");

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

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.HasOne(d => d.Description)
                    .WithOne(p => p.Book)
                    .HasForeignKey<Book>(d => d.DescriptionId);
            });

            modelBuilder.Entity<BookCenter>(entity =>
            {
                entity.ToTable("book_center");

                entity.Property(e => e.BookCenterId).HasColumnName("book_center_id");
            });

            modelBuilder.Entity<BookDesc>(entity =>
            {
                entity.ToTable("book_desc");

                entity.Property(e => e.BookDescId).HasColumnName("book_desc_id");
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.ToTable("book_genre");

                entity.HasIndex(e => e.BookId, "IX_book_genre_BookId");

                entity.HasIndex(e => e.GenreId, "IX_book_genre_GenreId");

                entity.Property(e => e.BookGenreId).HasColumnName("book_genre_id");

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

                entity.Property(e => e.DownloadLinkId).HasColumnName("download_link_id");

                entity.HasOne(d => d.BookDesc)
                    .WithMany(p => p.DownloadLinks)
                    .HasForeignKey(d => d.BookDescId);
            });

            modelBuilder.Entity<FavAuthor>(entity =>
            {
                entity.ToTable("fav_author");

                entity.HasIndex(e => e.AuthorId, "IX_fav_author_AuthorId");

                entity.HasIndex(e => e.UserId, "IX_fav_author_UserId");

                entity.Property(e => e.FavAuthorId).HasColumnName("fav_author_id");

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

                entity.Property(e => e.FavGenreId).HasColumnName("fav_genre_id");

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

                entity.Property(e => e.GenreId).HasColumnName("genre_id");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.HasIndex(e => e.BookId, "IX_history_BookId");

                entity.HasIndex(e => e.UserId, "IX_history_UserId");

                entity.Property(e => e.HistoryId).HasColumnName("history_id");

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

                entity.Property(e => e.ImgLinkId).HasColumnName("img_link_id");

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

                entity.HasIndex(e => e.FkRatingBookBookId, "IX_rating_FK_rating_book_bookId");

                entity.HasIndex(e => e.FkRatingUserUserId, "IX_rating_FK_rating_user_userId");

                entity.Property(e => e.RatingId).HasColumnName("rating_id");

                entity.Property(e => e.FkRatingBookBookId).HasColumnName("FK_rating_book_bookId");

                entity.Property(e => e.FkRatingUserUserId).HasColumnName("FK_rating_user_userId");

                entity.HasOne(d => d.FkRatingBookBook)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.FkRatingBookBookId);

                entity.HasOne(d => d.FkRatingUserUser)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.FkRatingUserUserId);
            });

            modelBuilder.Entity<SubscGenre>(entity =>
            {
                entity.HasKey(e => e.SubscrGenreId);

                entity.ToTable("subsc_genre");

                entity.HasIndex(e => e.GenreId, "IX_subsc_genre_GenreId");

                entity.HasIndex(e => e.SubscriptionId, "IX_subsc_genre_SubscriptionId");

                entity.Property(e => e.SubscrGenreId).HasColumnName("subscr_genre_id");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.SubscGenres)
                    .HasForeignKey(d => d.GenreId);

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscGenres)
                    .HasForeignKey(d => d.SubscriptionId);
            });

            modelBuilder.Entity<SubscrAuthor>(entity =>
            {
                entity.ToTable("subscr_author");

                entity.HasIndex(e => e.AuthorId, "IX_subscr_author_AuthorId");

                entity.HasIndex(e => e.SubscriptionId, "IX_subscr_author_SubscriptionId");

                entity.Property(e => e.SubscrAuthorId).HasColumnName("subscr_author_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.SubscrAuthors)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscrAuthors)
                    .HasForeignKey(d => d.SubscriptionId);
            });

            modelBuilder.Entity<SubscrType>(entity =>
            {
                entity.ToTable("subscr_type");

                entity.HasIndex(e => e.SubscriptionId, "IX_subscr_type_SubscriptionId");

                entity.HasIndex(e => e.TypeId, "IX_subscr_type_TypeId");

                entity.Property(e => e.SubscrTypeId).HasColumnName("subscr_type_id");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscrTypes)
                    .HasForeignKey(d => d.SubscriptionId);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.SubscrTypes)
                    .HasForeignKey(d => d.TypeId);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.SubscrId);

                entity.ToTable("subscription");

                entity.HasIndex(e => e.FkSubscrUserSubscrUserSubscrId, "IX_subscription_FK_subscr_user_subscr_user_subscr_id")
                    .IsUnique();

                entity.Property(e => e.SubscrId).HasColumnName("subscr_id");

                entity.Property(e => e.FkSubscrUserSubscrUserSubscrId).HasColumnName("FK_subscr_user_subscr_user_subscr_id");

                entity.HasOne(d => d.FkSubscrUserSubscrUserSubscr)
                    .WithOne(p => p.Subscription)
                    .HasForeignKey<Subscription>(d => d.FkSubscrUserSubscrUserSubscrId)
                    .HasConstraintName("FK_subscription_user_subscr_FK_subscr_user_subscr_user_subscr_~");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("types");

                entity.Property(e => e.TypeId).HasColumnName("type_id");
            });

            modelBuilder.Entity<UserSubscr>(entity =>
            {
                entity.ToTable("user_subscr");

                entity.HasIndex(e => e.UserId, "IX_user_subscr_UserId");

                entity.Property(e => e.UserSubscrId).HasColumnName("user_subscr_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSubscrs)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
