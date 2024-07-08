using API_Practice.DTOs;
using API_Practice.Models;

namespace API_Practice.Services
{
    public interface IContactsService
    {
        List<Contactos>? getContactsByUser(int user_id);
        object? createContact(ContactsCreateDTO contact);
        object? updateContact(ContactsCreateDTO contact, int contact_id);
        object? deleteContact(int user_id, int contact_id);  

    }
}
