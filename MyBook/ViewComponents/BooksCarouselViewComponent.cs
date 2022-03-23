using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;

namespace MyBook.ViewComponents;

public class BooksCarouselViewComponent: ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(List<Book> book)
    {
        return View(book);
    }
}