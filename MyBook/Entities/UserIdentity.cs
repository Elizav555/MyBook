using Microsoft.AspNetCore.Identity;

namespace MyBook.Entities
{
    public class UserIdentity : IdentityUser
    {
        public virtual User User { get; set; } = null!;
    }
}
