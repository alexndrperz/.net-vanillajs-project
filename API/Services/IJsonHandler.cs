using API_Practice.Models;

namespace API_Practice.Services
{
    public interface IJsonHandler
    {
        List<Usuario> readUsers();
        Usuario crearUsuario();
    }
}
