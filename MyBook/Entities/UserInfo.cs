namespace MyBook.Entities
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateOnly BirthDate { get; set; }

        public virtual User User { get; set; }
    }
}
