using MyBook.Entities;

namespace MyBook.Models.Admin
{
    public class AdminViewModel
    {
        public string CurrentPage { get; set; } = "Subscription";
        public List<User> Users { get; set; }
        public List<MyBook.Entities.Type> SubscrTypes { get; set; } = new();
        public List<BookCenter> Centers { get; set; }
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; } = new();
    }
}
