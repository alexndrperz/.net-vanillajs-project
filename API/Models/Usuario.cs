using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Practice.Models
{
    public class Usuario
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string username{ get; set; }
        [Required]
        public string password{ get; set; }
        [JsonIgnore]
        public string role { get; set; } = "cliente";
        public string descripcion { get; set; } = "";

        public List<Contactos> contactos { get; set; } = [];
    }


    public class UsuarioAuth
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
