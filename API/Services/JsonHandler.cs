using API_Practice.Models;
using Newtonsoft.Json;

namespace API_Practice.Services
{
    public class JsonHandler : IJsonHandler
    {
        // TODO: Logica id
        public bool crearUsuario(Usuario user)
        {
            try
            {
                string path = fullPathDB();
                var userList = readUsers();
                user.Id = generateId(userList);
                userList.Add(user);
                string json = JsonConvert.SerializeObject(userList);
                File.WriteAllText(path, json);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
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
        private string fullPathDB()
        {
            string directProyecto = Directory.GetCurrentDirectory();
            string path = Path.Combine(directProyecto, "db.json");
            return path;
        }

        public List<Usuario> readUsers()
        {
            string path = fullPathDB();
            var jsonData = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Usuario>>(jsonData)
                             ?? new List<Usuario>();
        }
    }
}
