namespace MyBook.Entities
{
    public partial class AuthorBook
    {
        public int AuthorBookId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}
