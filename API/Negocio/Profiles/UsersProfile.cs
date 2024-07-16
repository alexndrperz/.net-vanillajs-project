using AutoMapper;
using Datos.DTOs;
using Datos.Entities;


namespace Negocio.Profiles
{
    internal class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UsuarioCreateDTO, Usuario>();
        }
    }
}
