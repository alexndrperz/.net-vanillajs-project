using API_Practice.DTOs;
using API_Practice.Models;
using AutoMapper;

namespace API_Practice.Profiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<ContactsCreateDTO, Contactos>();
        }
    }
}
