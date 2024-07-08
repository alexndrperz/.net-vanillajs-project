using API_Practice.DTOs;
using API_Practice.Models;
using API_Practice.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_Practice.Controllers
{
    [Route("/users")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController( IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpPost("registrar")]
        public ActionResult registrarUsuario([FromBody] Usuario user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            bool result = _usersService.crearUsuario(user);
            if (result) return Ok(new { msg = "El usuario fue registrado" });
            return StatusCode(503, new { msg = "Sucedio un error en el servidor" });
        }

        [HttpPost("autenticar")]
        public ActionResult autenticarUsuario([FromBody] UsuarioAuth userCred)
        {
            MsgServerMD result = _usersService.autenticarUsuario(userCred);
            if (result.success) return Ok(result.data);
            return StatusCode(result.status, result.data);
        }

        [HttpGet("info/{user_id}")]
        public ActionResult<Usuario> obtenerInfoUsuario(int user_id)
        {
            Usuario? usuario = _usersService.getUsuario(user_id);   
            if (usuario == null) return Unauthorized(new { msg = "No deberias estar aqui" });
            usuario.password = "#####";
            return Ok(usuario);
        }
    }
}
