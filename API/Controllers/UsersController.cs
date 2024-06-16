using API_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_Practice.Controllers
{
    [Route("/users")]
    public class UsersController : Controller
    {
        [HttpPost("registrar")]   
       public ActionResult registrarUsuario()
       {
            string directProyecto = Directory.GetCurrentDirectory();

            //string path = Path.Combine(directProyecto, "db.json");
            //Usuario user = new Usuario() { 
            //    name = "Alan Alexander Perez",
            //    username = "alesner",
            //    password = "12345",
            //    descripcion = "Un buen usuario",
            //    role = "Admin"
            //};
            //var jsonData = System.IO.File.ReadAllText(path);
            //var userList = JsonConvert.DeserializeObject<List<Usuario>>(jsonData)
            //          ?? new List<Usuario>();
            //userList.Add(user);

            //string json = JsonConvert.SerializeObject(userList);
            //System.IO.File.WriteAllText(path, json);
            return Ok(new {msg = "El usuario fue registrado"});
       }

        [HttpPost("autenticar")]
        public ActionResult autenticarUsuario()
        {
            return Ok();
        }

        [HttpGet("info")]
        public ActionResult obtenerInfoUsuario()
        {
            return Ok();   
        }
    }
}
