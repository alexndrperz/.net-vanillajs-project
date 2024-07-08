using API_Practice.DTOs;
using API_Practice.Models;
using API_Practice.Services.Contracts;
using AutoMapper;
using Newtonsoft.Json;

namespace API_Practice.Services.Mockups
{
    public class ContactsService : IContactsService
    {
        private readonly IJsonHandler _jsonRepo;
        private readonly IMapper _mapper;
        private readonly IUsersService _usersServ;
        public ContactsService(IJsonHandler jsonRepo, IMapper mapper, IUsersService usersServ)
        {
            _jsonRepo = jsonRepo;
            _mapper = mapper;
            _usersServ = usersServ;
        }
        public object? createContact(ContactsCreateDTO contact)
        {
            List<Contactos>? contactos = getContactsByUser(contact.user_id);
            if (contactos == null) return null;
            Contactos ent = _mapper.Map<Contactos>(contact);
            ent.Id = generateId(contactos);
            contactos.Add(ent);
            object? msg = UserAndContactConnection(contact.user_id, contactos);
            return msg;


        }

        public object? deleteContact(int user_id, int contact_id)
        {
            List<Contactos>? contactos = getContactsByUser(user_id);
            if (contactos == null) return null;
            Contactos? contact = contactos.FirstOrDefault(co => co.Id == contact_id);
            if (contact == null) return null;
            contactos.Remove(contact);
            object? msg = UserAndContactConnection(user_id, contactos);
            return msg;

        }

        private int generateId(List<Contactos> contactos)
        {
            if (contactos.Count == 0)
            {
                return 1;
            }
            else
            {
                int contId = contactos.Last().Id;
                return contId + 1;
            }
        }

        public List<Contactos>? getContactsByUser(int user_id)
        {
            string json = _jsonRepo.readJson();
            List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();
            Usuario? user = usuarios.FirstOrDefault(us => us.Id == user_id);
            if (user == null)
            {
                return null;
            }
            return user.contactos;
        }

        public object? updateContact(ContactsCreateDTO contact, int contact_id)
        {
            List<Contactos>? contactos = getContactsByUser(contact.user_id);
            if (contactos == null) return null;
            Contactos? contactEnt = contactos.FirstOrDefault(co => co.Id == contact_id);
            if (contactEnt == null) return null;
            _mapper.Map(contact, contactEnt);
            int index = contactos.IndexOf(contactEnt);
            contactos[index] = contactEnt;
            object? msg = UserAndContactConnection(contact.user_id, contactos);
            return msg;

        }

        private object? UserAndContactConnection(int user_id, List<Contactos> contactos)
        {
            Usuario? user = _usersServ.getUsuario(user_id);
            if (user == null) return null;
            user.contactos = contactos;
            _usersServ.actualizarUsuario(user);
            return new { msg = "Exito" };
        }
    }
}
