using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBook.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public virtual ICollection<FavAuthor> FavAuthors { get; set; }
        public virtual ICollection<FavGenre> FavGenres { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<UserSubscr> UserSubscrs { get; set; }
    }
}