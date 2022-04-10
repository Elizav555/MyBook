using MyBook.Entities;

namespace MyBook.Models
{
    public class BuySubscrViewModel
    {
        public List<Subscription> Subscriptions { get; set; } = new();
        public List<Genre> Genres { get; set; } = new();
        public List<Author> Authors { get; set; } = new();
    }
}
