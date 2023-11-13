using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_31_HTML_Forms.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    private readonly ILogger<ContactsController> _logger;
    private readonly Services.IContactsBookService _contactsBookService;

    public ContactsController(
        Services.IContactsBookService contactsBookService, ILogger<ContactsController> logger)
    {
        _contactsBookService = contactsBookService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromForm] ContactFormDto contact)
    {
        _logger.LogInformation("Form data received");

        bool success = _contactsBookService.AddContact(contact);

        return success
            ? Redirect("/")
            : StatusCode(500, new { status = "Something went wrong" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(_contactsBookService.GetAllContacts());
    }
}
