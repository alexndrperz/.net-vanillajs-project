using Datos.DTOs;
using Datos.Entities;
using Negocio.Contracts;
using Microsoft.AspNetCore.Mvc;


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
        public async Task<ActionResult> registrarUsuarioAsync([FromBody] UsuarioCreateDTO user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            bool result = await _usersService.crearUsuarioClienteAsync(user);
            if (result) return Ok(new { msg = "El usuario fue registrado" });
            return StatusCode(503, new { msg = "Sucedio un error en el servidor" });
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> autenticarUsuario([FromBody] UsuarioAuthDTO userCred)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            MsgServerMD result =await  _usersService.autenticarUsuarioAsync(userCred);
            if (result.success) return Ok(result.data);
            return StatusCode(result.status, result.data);
        }

        [HttpGet("info/{user_id}")]
        public async Task<ActionResult<Usuario>> ObtenerInfoUsuario(int user_id)
        {
            Usuario? usuario =await _usersService.getUsuarioAsync(user_id);   
            if (usuario == null) return Unauthorized(new { msg = "No deberias estar aqui" });
            usuario.Password = "#####";
            return Ok(usuario);
        }
    }
}
