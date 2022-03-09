using Microsoft.EntityFrameworkCore;

namespace MyBook.Entities
{
    public partial class MyBookContext : DbContext
    {
        public MyBookContext()
        { }

        public MyBookContext(DbContextOptions<MyBookContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<BookCenter> BookCenters { get; set; }
        public DbSet<BookDescription> BookDescriptions { get; set; }
        public DbSet<DownloadLink> DownloadLinks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<ImgLink> ImgLinks { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserSubscriptions> UsersSubscriptions { get; set; }
        public DbSet<FavGenre> FavGenres { get; set; }
        public DbSet<FavAuthor> FavAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.Id).HasColumnName("author_id").HasIdentityOptions(0, 1, 0, null, null, null); ;

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("user_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.UserInfo)
               .WithOne(p => p.User).HasForeignKey<User>(d => d.InfoId);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("user_info");

                entity.Property(e => e.Id)
                    .HasColumnName("user_info_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);
            });

            modelBuilder.Entity<AuthorBook>(entity =>
            {
                entity.ToTable("author_book");

                entity.Property(e => e.Id)
                    .HasColumnName("author_book_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(e => e.AuthorId);

                entity.HasOne(d => d.Book)
                .WithMany(p => p.Authors)
                .HasForeignKey(e => e.BookId);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.Id)
                    .HasColumnName("book_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.Rating)
                .WithOne(p => p.Book)
                .HasForeignKey<Book>(e => e.RatingId);

                entity.HasOne(d => d.Description)
                .WithOne(p => p.Book)
                .HasForeignKey<Book>(e => e.DescriptionId);
            });

            modelBuilder.Entity<BookCenter>(entity =>
            {
                entity.ToTable("book_center");

                entity.Property(e => e.Id)
                    .HasColumnName("book_center_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);
            });

            modelBuilder.Entity<BookDescription>(entity =>
            {
                entity.ToTable("book_desc");

                entity.Property(e => e.Id)
                    .HasColumnName("book_desc_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.ToTable("book_genre");

                entity.Property(e => e.Id)
                    .HasColumnName("book_genre_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.Genre)
                .WithMany(p => p.Books)
                .HasForeignKey(e => e.GenreId);

                entity.HasOne(d => d.Book)
                .WithMany(p => p.Genres)
                .HasForeignKey(e => e.BookId);
            });

            modelBuilder.Entity<DownloadLink>(entity =>
            {
                entity.ToTable("download_link");

                entity.Property(e => e.Id)
                    .HasColumnName("download_link_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.BookDesc)
                .WithMany(p => p.DownloadLinks)
                .HasForeignKey(e => e.BookDescId);
            });

            modelBuilder.Entity<FavAuthor>(entity =>
            {
                entity.ToTable("fav_author");

                entity.Property(e => e.Id)
                    .HasColumnName("fav_author_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.User)
                .WithMany(p => p.FavAuthors)
                .HasForeignKey(e => e.UserId);

                entity.HasOne(d => d.Author)
                .WithMany(p => p.Fans)
                .HasForeignKey(e => e.AuthorId);
            });

            modelBuilder.Entity<FavGenre>(entity =>
            {
                entity.ToTable("fav_genre");

                entity.Property(e => e.Id)
                    .HasColumnName("fav_genre_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.User)
                .WithMany(p => p.FavGenres)
                .HasForeignKey(e => e.UserId);

                entity.HasOne(d => d.Genre)
                .WithMany(p => p.Fans)
                .HasForeignKey(e => e.GenreId);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id)
                    .HasColumnName("genre_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.Property(e => e.Id)
                    .HasColumnName("history_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.User)
                .WithMany(p => p.History)
                .HasForeignKey(e => e.UserId);

                entity.HasOne(d => d.Book)
                .WithMany(p => p.Readers)
                .HasForeignKey(e => e.BookId);
            });

            modelBuilder.Entity<ImgLink>(entity =>
            {
                entity.ToTable("img_link");

                entity.Property(e => e.Id)
                    .HasColumnName("img_link_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.Author)
                .WithMany(p => p.Images)
                .HasForeignKey(e => e.AuthorId);

                entity.HasOne(d => d.Book)
               .WithMany(p => p.Images)
               .HasForeignKey(e => e.BookId);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating");

                entity.Property(e => e.Id)
                    .HasColumnName("rating_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.User)
                .WithMany(p => p.Marks)
                .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscription");

                entity.Property(e => e.Id)
                    .HasColumnName("subscr_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.Type)
                .WithOne(p => p.Subscription)
                .HasForeignKey<Subscription>(e => e.TypeId);
            });

            modelBuilder.Entity<SubscriptionType>(entity =>
            {
                entity.ToTable("subscr_type");

                entity.Property(e => e.Id)
                    .HasColumnName("subscr_type_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.Genre)
                .WithMany(p => p.Followers)
                .HasForeignKey(e => e.GenreId);

                entity.HasOne(d => d.Author)
                .WithMany(p => p.Followers)
                .HasForeignKey(e => e.AuthorId);
            });

            modelBuilder.Entity<UserSubscriptions>(entity =>
            {
                entity.ToTable("user_subscr");

                entity.Property(e => e.Id)
                    .HasColumnName("user_subscr_id")
                    .HasIdentityOptions(0, 1, 0, null, null, null);

                entity.HasOne(d => d.User)
                .WithMany(p => p.Subscriptions)
                .HasForeignKey(e => e.UserId);

                entity.HasOne(d => d.Subscription)
                .WithOne(p => p.User)
                .HasForeignKey<UserSubscriptions>(e => e.SubscriptionId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
