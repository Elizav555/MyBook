namespace MyBook.Entities
{
    public class DownloadLink
    {
        public int Id { get; set; }
        public int BookDescId { get; set; }
        public string Format { get; set; }
        public string Url { get; set; }

        public virtual BookDescription BookDesc { get; set; }
    }
}
