using Datos.Entities;
using Datos.DTOs;
namespace Negocio.Services.Contracts
{
    public interface IUsersService
    {
        List<Usuario> GetUsuarios();
        bool actualizarUsuario(Usuario usuario);
        Usuario? getUsuario(int id);
        bool crearUsuario(Usuario usuario);
        MsgServerMD autenticarUsuario(UsuarioAuthDTO userCred);
    }
}
