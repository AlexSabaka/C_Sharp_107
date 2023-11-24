using System.Collections.Immutable;
using Lesson_33_MVC.Data.Models;

namespace Lesson_33_MVC.Services.Interfaces;

// DDD – Domain Driven Design

public interface IContactsBookService
{
    Task<IList<Data.Models.Contact>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Data.Models.Contact> GetByNameAsync(string searchName, CancellationToken cancellationToken = default);
    Task<Data.Models.Contact> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<int> AddAsync(Data.Models.Contact contact, CancellationToken cancellationToken = default);
    Task<Avatar> GetAvatarAsync(int id, CancellationToken cancellationToken = default);
    Task<int> AddAvatarAsync(Stream avatarStream, string contentType, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> EditAsync(Data.Models.Contact contact, CancellationToken cancellationToken = default);
}
