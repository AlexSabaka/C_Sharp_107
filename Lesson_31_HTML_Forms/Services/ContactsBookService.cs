using DTO;

namespace Services;

public interface IContactsBookService
{
    bool AddContact(DTO.ContactFormDto contact);
    IEnumerable<DTO.ContactFormDto> GetAllContacts();
}

public class JsonContactsBookService : IContactsBookService
{
    public const string ContactsFile = "contacts.json";

    public bool AddContact(DTO.ContactFormDto contact)
    {
        try
        {
            var allContacts = new List<DTO.ContactFormDto>(GetAllContacts());
            allContacts.Add(contact);
            string json = System.Text.Json.JsonSerializer.Serialize(allContacts);
            File.WriteAllText(ContactsFile, json);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<DTO.ContactFormDto> GetAllContacts()
    {
        if (!File.Exists(ContactsFile)) {
            return Enumerable.Empty<DTO.ContactFormDto>();
        }

        string json = File.ReadAllText(ContactsFile);
        var allContacts = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<DTO.ContactFormDto>>(json);

        return allContacts;
    }
}

public class XmlContactsBookService : IContactsBookService
{
    public bool AddContact(ContactFormDto contact)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ContactFormDto> GetAllContacts()
    {
        throw new NotImplementedException();
    }
}

public class DbContactsBookService : IContactsBookService
{
    public bool AddContact(ContactFormDto contact)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ContactFormDto> GetAllContacts()
    {
        throw new NotImplementedException();
    }
}