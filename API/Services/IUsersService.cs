using API_Practice.Models;

namespace API_Practice.Services
{
    public interface IUsersService
    {
        List<Usuario> GetUsuarios();
        bool actualizarUsuario(Usuario usuario);
        Usuario? getUsuario(int id);
        object? crearUsuario(Usuario usuario);
        object? autenticarUsuario(UsuarioAuth usuario);
    }
}
