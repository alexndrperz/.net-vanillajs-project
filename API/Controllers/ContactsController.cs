using API_Practice.DTOs;
using API_Practice.Models;
using API_Practice.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice.Controllers
{
    [Route("/contacts")]
    public class ContactsController : Controller
    {
        private readonly IContactsService _contactServ;

        public ContactsController(IContactsService contactsServ)
        {
            _contactServ = contactsServ;
        }

        [HttpGet("user/{user_id}")]
        public IActionResult GetContactsByUser(int user_id)
        {
            List<Contactos>? contactos = _contactServ.getContactsByUser(user_id);
            if (contactos == null) return NotFound(new { msg = "Usuario no encontrado" }); 
            return Ok(contactos);
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] ContactsCreateDTO contact)
        {
            object? msg = _contactServ.createContact(contact);
            if (msg == null) { return BadRequest(new {msg =  "Existen errores en su solicitud al servidor"}); }
            return Ok(msg);
        }

        [HttpPut("{contact_id}")]
        public IActionResult UpdateContact(int contact_id, [FromBody] ContactsCreateDTO contact)
        {
            object? msg = _contactServ.updateContact(contact, contact_id);
            if (msg == null) { return BadRequest(new { msg = "Existen errores en su solicitud al servidor"}); }
            return Ok(msg);
        }

        [HttpDelete("user/{user_id}/{contact_id}")]
        public IActionResult DeleteContact(int contact_id, int user_id )
        {
            object? msg = _contactServ.deleteContact(user_id, contact_id);
            if (msg == null) { return BadRequest(new { msg = "Existen errores en su solicitud al servidor" }); }
            return Ok(msg);
        }

    }
}
