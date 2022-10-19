using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string? Titolo { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string? Testo { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [EmailAddress]
        public string? Email { get; set; }

        public Message()
        {

        }
    }
}
