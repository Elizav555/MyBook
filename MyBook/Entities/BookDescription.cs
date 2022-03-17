namespace MyBook.Entities
{
    public class BookDescription
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int PagesCount { get; set; }
        public string? Price { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<DownloadLink> DownloadLinks { get; set; }
    }
}

