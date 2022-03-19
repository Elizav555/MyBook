namespace MyBook.Entities
{
    public partial class FavAuthor
    {
        public int FavAuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
