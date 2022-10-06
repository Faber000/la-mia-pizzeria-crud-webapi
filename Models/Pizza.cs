using System.ComponentModel.DataAnnotations;

public class Pizza
{
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(25,ErrorMessage = "Il nome non può essere più grande di 25 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(100, ErrorMessage = "la descriziome non può essere più grande di 100 caratteri")]
        public string Descrizione { get; set; }
        
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Immagine { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(4, 15, ErrorMessage = "Il prezzo non è valido")]
        public double Prezzo { get; set; }

        public Pizza()
        {

        }
        public Pizza(string nome, string descrizione, string immagine, double prezzo)
        {
            Nome = nome;
            Descrizione = descrizione;
            Immagine = immagine;
            Prezzo = prezzo;
        }
}
