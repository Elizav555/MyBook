namespace MyBook.Models
{
    public class ModalsViewModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public string? CurrentPage { get; set; } = null;
        public string? UserId { get; set; } = null;
        public int? BookId { get; set; } = null;
        public int? AuthorId { get; set; } = null;
    }
}
