using API_Practice.DTOs;
using API_Practice.Models;

namespace API_Practice.Services.Contracts
{
    public interface IUsersService
    {
        List<Usuario> GetUsuarios();
        bool actualizarUsuario(Usuario usuario);
        Usuario? getUsuario(int id);
        bool crearUsuario(Usuario usuario);
        MsgServerMD autenticarUsuario(UsuarioAuth userCred);
    }
}
