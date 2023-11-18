using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lesson_33_MVC.Data;
using Lesson_33_MVC.Data.Models;
using Lesson_33_MVC.DTO;
using Lesson_33_MVC.ViewModels;

namespace Lesson_33_MVC.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;
    private readonly ILogger<ContactsController> _logger;

    public ContactsController(IMapper mapper, AppDbContext appDbContext, ILogger<ContactsController> logger)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
        _logger = logger;
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(GetContactDto[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> AllAsync(CancellationToken cancellationToken) => 
        Ok(await _mapper.ProjectTo<GetContactDto>(_appDbContext.Contacts).ToArrayAsync(cancellationToken));

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetContactDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var contact = await _appDbContext.Contacts.FindAsync(id, cancellationToken);
        return contact is null
            ? NotFound(id)
            : Ok(_mapper.Map<Contact, GetContactDto>(contact));
    }

    [HttpGet("{id}/avatar")]
    [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAvatarAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var contact = await _appDbContext.Contacts
            .Include(c => c.Avatar)
            .SingleAsync(c => c.Id == id, cancellationToken);

        if (contact is null || contact?.AvatarId is null)
        {
            return NotFound(id);
        }

        return File(contact.Avatar.ImageData, contact.Avatar.ImageType);
    }

    [HttpPost("")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromForm] CreateContactDto contactDto, CancellationToken cancellationToken)
    {
        Avatar? avatar = null;
        if (contactDto.AvatarFile is not null)
        {
            using var fileStream = contactDto.AvatarFile.OpenReadStream();
            using var memoryStream = new MemoryStream();

            await fileStream.CopyToAsync(memoryStream);

            var avatarEntity = await _appDbContext.Avatars.AddAsync(new Avatar {
                ImageType = contactDto.AvatarFile.ContentType,
                ImageData = memoryStream.ToArray(),
            });

            await _appDbContext.SaveChangesAsync(cancellationToken);

            avatar = avatarEntity.Entity;
        }

        var contact = _mapper.Map<CreateContactDto, Contact>(contactDto);
        contact.AvatarId = avatar?.Id;

        await _appDbContext.Contacts.AddAsync(contact);
        await _appDbContext.SaveChangesAsync(cancellationToken);

        return RedirectToAction("Index", "Home");
    }
}
