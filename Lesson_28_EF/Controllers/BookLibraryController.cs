using System.Data.Entity;
using Lesson_28_EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_28_EF.Controllers;

[ApiController]
[Route("[controller]")]
public class BookLibraryController : ControllerBase
{
    private readonly ILogger<BookLibraryController> _logger;
    private readonly BookLibraryDbContext _libraryContext;

    public BookLibraryController(BookLibraryDbContext libraryContext, ILogger<BookLibraryController> logger)
    {
        _logger = logger;
        _libraryContext = libraryContext;
    }

    // endpoint or action method
    // Universal Resource Locator (URL) / URI (Identifier) – http://[domen][:port][/path][?query]

    // GET http://127.0.0.1:5127/booklibrary
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        return Ok(new {
            countries = _libraryContext.Countries.ToArray(),
            books = _libraryContext.Books.ToArray(),
            authors = _libraryContext.Authors.ToArray(),
            publisher = _libraryContext.Publishers.ToArray(),
        });
    }
}
