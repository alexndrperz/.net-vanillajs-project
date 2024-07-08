using API_Practice.DTOs;
using API_Practice.Models;
using API_Practice.Services.Contracts;
using Newtonsoft.Json;

namespace API_Practice.Services.Mockups
{
    public class UsersService : IUsersService
    {
        private readonly IJsonHandler _jsonRepo;
        public UsersService(IJsonHandler jsonRepo)
        {
            _jsonRepo = jsonRepo;
        }

        public MsgServerMD autenticarUsuario(UsuarioAuth userCred)
        {
            List<Usuario> usersColl = GetUsuarios();
            Usuario? user = usersColl.FirstOrDefault(us => us.username == userCred.username);
            if (user == null) return MsgServerMD.errorMsg(401, "Usuario no encontrado");
            if (user.password != userCred.password) return MsgServerMD.errorMsg(401, "Contraseña incorrecta");
            return MsgServerMD.resulMsg(201, new { user_id = user.Id });
        }

        public bool crearUsuario(Usuario usuario)
        {
                var userList = GetUsuarios();
                usuario.Id = generateId(userList);
                userList.Add(usuario);
                bool wasStored = _jsonRepo.writeObject(userList);
                return wasStored;
        }

        private int generateId(List<Usuario> usersList)
        {
            if (usersList.Count == 0)
            {
                return 1;
            }
            else
            {
                int userId = usersList.Last().Id;
                return userId + 1;
            }
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
            return usuarios.FirstOrDefault(us => us.Id == id);
        }

        public bool actualizarUsuario(Usuario usObj)
        {
            Usuario? usuario = getUsuario(usObj.Id);
            List<Usuario> usuarios = GetUsuarios();
            if (usuario == null)
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
