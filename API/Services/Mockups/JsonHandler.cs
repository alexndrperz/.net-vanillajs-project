using API_Practice.Models;
using API_Practice.Services.Contracts;
using Newtonsoft.Json;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Cryptography.X509Certificates;

namespace API_Practice.Services.Mockups
{
    public class JsonHandler : IJsonHandler
    {
        private string fullPathDB()
        {
            string directProyecto = Directory.GetCurrentDirectory();
            string path = Path.Combine(directProyecto, "db.json");
            return path;
        }

        public string readJson()
        {
            string path = fullPathDB();
            var jsonData = File.ReadAllText(path);
            return jsonData;
        }

        public bool writeObject(object obj)
        {
            try
            {
                string path = fullPathDB();
                string json = JsonConvert.SerializeObject(obj);
                File.WriteAllText(path, json);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
