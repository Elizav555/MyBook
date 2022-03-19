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
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public int InfoId { get; set; }
        public virtual UserInfo Info { get; set; } = null!;
        public virtual ICollection<FavAuthor> FavAuthors { get; set; }
        public virtual ICollection<FavGenre> FavGenres { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<UserSubscr> UserSubscrs { get; set; }
    }
}
