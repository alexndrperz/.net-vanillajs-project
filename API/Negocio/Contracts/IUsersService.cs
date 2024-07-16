using Datos.Entities;
using Datos.DTOs;
namespace Negocio.Contracts
{
    public interface IUsersService
    {
        Task<List<Usuario>> GetUsuarios();
        Task<bool> actualizarUsuario(int user_id, UsuarioCreateDTO usuario);
        Task<Usuario?> getUsuarioAsync(int id);
        Task<bool> crearUsuarioClienteAsync(UsuarioCreateDTO usuario);
        Task<MsgServerMD> autenticarUsuarioAsync(UsuarioAuthDTO userCred);
    }
}
