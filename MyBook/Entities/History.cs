namespace MyBook.Entities
{
    public class History
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
