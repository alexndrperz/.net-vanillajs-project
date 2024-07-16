using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs
{
    public  class UsuarioAuthDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }

    public class UsuarioCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
