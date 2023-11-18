using AutoMapper.Configuration.Annotations;

namespace Lesson_33_MVC.DTO;

public class CreateContactDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    [Ignore]
    public IFormFile? AvatarFile { get; set; }
}