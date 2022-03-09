namespace MyBook.Entities
{
    public class ImgLink
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? AuthorId { get; set; }
        public string? Resolution { get; set; }
        public string Url { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Book? Book { get; set; }
    }
}
