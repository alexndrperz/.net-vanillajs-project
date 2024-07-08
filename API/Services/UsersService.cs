using API_Practice.Models;
using Newtonsoft.Json;

namespace API_Practice.Services
{
    public class UsersService : IUsersService
    {
        private readonly IJsonHandler _jsonRepo;
        public UsersService(IJsonHandler jsonRepo)
        {
            _jsonRepo = jsonRepo;
        }

        public object? autenticarUsuario(UsuarioAuth usuario)
        {
            throw new NotImplementedException();
        }

        public object? crearUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuarios()
        {
            string json = _jsonRepo.readJson();
            List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();
            return usuarios;
        }

        public Usuario? getUsuario(int id)
        {
            List<Usuario> usuarios = GetUsuarios();
            return usuarios.FirstOrDefault(us => us.Id ==id);
        }

        public bool actualizarUsuario( Usuario usObj)
        {
            Usuario? usuario = getUsuario(usObj.Id);
            List<Usuario>usuarios = GetUsuarios();
            if(usuario == null)
            {
                return false;
            }
            int index = usuarios.FindIndex(us => us.Id == usObj.Id);
            usuarios[index] = usObj;
            _jsonRepo.writeObject(usuarios);
            return true;
        }

    }
}
