using MyBook.Entities;

namespace MyBook.Models
{
    public class BuySubscrViewModel
    {
        public List<Genre> Genres { get; set; } = new();
        public List<Author> Authors { get; set; } = new();
    }
}
