using Datos.DTOs;
using Datos.Entities;

namespace Negocio.Services.Contracts
{
    public interface IContactsService
    {
        List<Contacto>? getContactsByUser(int user_id);
        object? createContact(ContactsCreateDTO contact);
        object? updateContact(ContactsCreateDTO contact, int contact_id);
        object? deleteContact(int user_id, int contact_id);

    }
}
