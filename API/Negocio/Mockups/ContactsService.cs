using AutoMapper;
using Datos.DbContexts;
using Datos.DTOs;
using Datos.Entities;
using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;


namespace Negocio.Mockups
{
    public class ContactsService : IContactsService
    {
        private readonly IMapper _mapper;
        private readonly BdContext _dbContext;
        private readonly IUsersService _usersService;
        public ContactsService(IUsersService usersService, BdContext dbContext, IMapper mapper)
        {
            _usersService = usersService;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<object?> createContact(ContactsCreateDTO contact)
        {
           Usuario? user = await _dbContext.Usuarios.FirstOrDefaultAsync(us => us.Id == contact.user_id);
           if(user == null) return null;
           Contacto contacto= _mapper.Map<Contacto>(contact);
           await _dbContext.Contactos.AddAsync(contacto); 
           await _dbContext.SaveChangesAsync();
           return new { contact_id = contacto.Id };
        }

        public async Task<object?> deleteContactAsync(int user_id, int contact_id)
        {
            Contacto? contacto = await _dbContext.Contactos.FirstOrDefaultAsync(co => co.Id == contact_id);
            if(contacto == null) return null;
            _dbContext.Contactos.Remove(contacto);
            await _dbContext.SaveChangesAsync();
            return new { msg = "Borrado con exito" };
        }

        public async Task<List<ContactsRetrieveDTO>?> getContactsByUser(int user_id)
        {
            Usuario? user =await _dbContext.Usuarios.FirstOrDefaultAsync(us => us.Id == user_id);    
            if(user == null) return null;   
            List<Contacto> contactos = await _dbContext.Contactos.Where(co => co.user_id == user_id).ToListAsync();    
            return _mapper.Map<List<ContactsRetrieveDTO>>(contactos);
        }

        public async Task<object?> updateContact(ContactsCreateDTO contact, int contact_id)
        {
            Contacto? contacto = await _dbContext.Contactos.FirstOrDefaultAsync(co => co.Id == contact_id);
            if(contacto == null) return null;
            _mapper.Map(contact, contacto);
            await _dbContext.SaveChangesAsync();
            return new { msg = "Contacto actualizado" };
        }
    }
}
