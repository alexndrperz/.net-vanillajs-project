using Datos.DTOs;
using Datos.Entities;
using Negocio.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

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
        public async Task<IActionResult> GetContactsByUserAsync(int user_id)
        {
            List<ContactsRetrieveDTO>? contactos = await _contactServ.getContactsByUser(user_id);
            if (contactos == null) return NotFound(new { msg = "Usuario no encontrado" }); 
            return Ok(contactos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactsCreateDTO contact)
        {
            object? msg =await _contactServ.createContact(contact);
            if (msg == null) { return BadRequest(new {msg =  "Existen errores en su solicitud al servidor"}); }
            return Ok(msg);
        }

        [HttpPut("{contact_id}")]
        public async Task<IActionResult> UpdateContact(int contact_id, [FromBody] ContactsCreateDTO contact)
        {
            object? msg =await _contactServ.updateContact(contact, contact_id);
            if (msg == null) { return BadRequest(new { msg = "Existen errores en su solicitud al servidor"}); }
            return Ok(msg);
        }

        [HttpDelete("user/{user_id}/{contact_id}")]
        public async Task<IActionResult> DeleteContact(int contact_id, int user_id )
        {
            object? msg = await _contactServ.deleteContactAsync(user_id, contact_id);
            if (msg == null) { return BadRequest(new { msg = "Existen errores en su solicitud al servidor" }); }
            return Ok(msg);
        }

    }
}
