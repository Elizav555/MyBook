using System.ComponentModel.DataAnnotations.Schema;

namespace MyBook.Entities
{
    public partial class UserInfo
    {
        public int UserInfoId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        [ForeignKey("FK_user_info_user_userId")]
        public virtual User User { get; set; } = null!;
    }
}
