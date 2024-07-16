using Datos.DTOs;
using Datos.Entities;

namespace Negocio.Contracts
{
    public interface IContactsService
    {
        Task<List<ContactsRetrieveDTO>?> getContactsByUser(int user_id);
        Task<object?> createContact(ContactsCreateDTO contact);
        Task<object?> updateContact(ContactsCreateDTO contact, int contact_id);
        Task<object?> deleteContactAsync(int user_id, int contact_id);

    }
}
