namespace MyBook.Entities
{
    public partial class ImgLink
    {
        public int ImgLinkId { get; set; }
        public string? Resolution { get; set; }
        public string Url { get; set; } = null!;

        public virtual Author? Author { get; set; }
        public virtual Book? Book { get; set; }
    }
}
