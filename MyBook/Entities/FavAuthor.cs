namespace MyBook.Entities
{
    public class FavAuthor
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Author Author { get; set; }
    }
}
