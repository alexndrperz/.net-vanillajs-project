using API_Practice.Models;
using API_Practice.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_Practice.Controllers
{
    [Route("/users")]
    public class UsersController : Controller
    {
        private readonly IJsonHandler _dbRepository;
        public UsersController(IJsonHandler dbRepository)
        {
            _dbRepository = dbRepository;
        }
        [HttpPost("registrar")]
        public ActionResult registrarUsuario([FromBody] Usuario user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = _dbRepository.crearUsuario(user);
            if (result)
            {
                return Ok(new { msg = "El usuario fue registrado" });
            }
            return StatusCode(503, new { msg = "Sucedio un error en el servidor" });
        }

        [HttpPost("autenticar")]
        public ActionResult autenticarUsuario([FromBody] UsuarioAuth userCred)
        {
            List<Usuario> usersColl = _dbRepository.readUsers();
            Usuario? user = usersColl.FirstOrDefault(us => us.username == userCred.username);
            if (user == null) return Unauthorized(new { msg = "El usuario buscado no existe" });
            if (user.password != userCred.password) return Unauthorized(new { msg = "Contraseña incorrecta" });
            return Ok(new {user_id = user.Id});
        }

        [HttpGet("info/{user_id}")]
        public ActionResult<Usuario> obtenerInfoUsuario(int user_id)
        {
            Usuario? usuario = _dbRepository.readUsers().FirstOrDefault(us => us.Id == user_id);
            if(usuario == null)
            {
                return Unauthorized(new { msg = "No deberias estar aqui" });
            }
            usuario.password = "#####";
            return Ok(usuario);
        }
    }
}
