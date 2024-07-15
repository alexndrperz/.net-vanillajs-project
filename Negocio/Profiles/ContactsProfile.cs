using Datos.DTOs;
using Datos.Entities;
using AutoMapper;

namespace Negocio.Profiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<ContactsCreateDTO, Contacto>();
        }
    }
}
