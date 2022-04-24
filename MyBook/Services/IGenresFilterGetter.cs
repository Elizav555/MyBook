using Microsoft.AspNetCore.Mvc.Rendering;
using MyBook.Infrastructure.Repositories;

namespace MyBook.Infrastructure.Services;

public interface IGenresFilterGetter
{
    List<SelectListItem> GetItems(EFGenreRepository repository);
}