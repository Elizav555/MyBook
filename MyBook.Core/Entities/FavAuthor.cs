namespace MyBook.Entities
{
    public partial class FavAuthor
    {
        public int FavAuthorId { get; set; }
        public int AuthorId{ get; set; }

        public virtual Author Author { get; set; } = null!;
        public string UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
