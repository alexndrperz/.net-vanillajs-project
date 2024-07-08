namespace API_Practice.DTOs
{
    public class ContactsCreateDTO
    {
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public int user_id { get; set; }    
    }

}
