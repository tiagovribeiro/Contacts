namespace Contacts.Models;
public static class ContactRepository
{
    private static List<Contact> _contacts = [
            new Contact() { Id = 1, Name = "John Doe", Email="jd@email.com" },
            new Contact() { Id = 2, Name = "John Apple", Email="jdola@email.com" },
            new Contact() { Id = 3, Name = "John Ela", Email="jdeela@email.com" },
            new Contact() { Id = 4, Name = "John Duck", Email="jdck@email.com" }];

    public static IEnumerable<Contact> Get()
    {
        return _contacts;
    }

    public static Contact? Get(int id)
    {
        var contact = _contacts.FirstOrDefault(x => x.Id.Equals(id));

        if (contact != null)
        {
            return new Contact()
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                Address = contact.Address,
            };
        }

        return null;
    }

    public static void Update(int id, Contact updatedContact)
    {
        if (id != updatedContact.Id)
        {
            return;
        }

        var contact = _contacts.FirstOrDefault(x => x.Id.Equals(id));

        if (contact != null)
        {
            contact.Id = updatedContact.Id;
            contact.Name = updatedContact.Name;
            contact.Email = updatedContact.Email;
            contact.Phone = updatedContact.Phone;
            contact.Address = updatedContact.Address;
        }
    }
    public static void Add(Contact contact)
    {
        var id = _contacts.LastOrDefault()?.Id + 1;

        if (id != null)
        {
            _contacts.Add(new Contact()
            {
                Id = id.Value,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                Address = contact.Address,
            });
        }
    }
    public static void Delete(int id)
    {
        _contacts.RemoveAll(x => x.Id.Equals(id));
    }

    internal static IEnumerable<Contact> Search(string text)
    {
        return _contacts.Where(x =>
        {
            if (
                x.Name.Contains(text, StringComparison.InvariantCultureIgnoreCase) ||
                x.Email.Contains(text, StringComparison.InvariantCultureIgnoreCase) ||
                (x.Phone != null && x.Phone.Contains(text, StringComparison.InvariantCultureIgnoreCase)) ||
                (x.Address != null && x.Address.Contains(text, StringComparison.InvariantCultureIgnoreCase))
                )
            {
                return true;
            }

            return false;
        });
    }
}

