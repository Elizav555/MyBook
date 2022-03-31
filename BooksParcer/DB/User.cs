using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class User
    {
        public User()
        {
            FavAuthors = new HashSet<FavAuthor>();
            FavGenres = new HashSet<FavGenre>();
            Histories = new HashSet<History>();
            Ratings = new HashSet<Rating>();
            UserSubscrs = new HashSet<UserSubscr>();
        }

        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
        public string? FkUserIdentityUserUserId { get; set; }

        public virtual AspNetUser? FkUserIdentityUserUser { get; set; }
        public virtual UserInfo UserInfo { get; set; } = null!;
        public virtual ICollection<FavAuthor> FavAuthors { get; set; }
        public virtual ICollection<FavGenre> FavGenres { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<UserSubscr> UserSubscrs { get; set; }
    }
}
