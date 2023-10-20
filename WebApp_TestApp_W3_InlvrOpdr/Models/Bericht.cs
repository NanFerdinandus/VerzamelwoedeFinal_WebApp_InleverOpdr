namespace WebApp_TestApp_W3_InlvrOpdr.Models
{
    public class Bericht
    {
        public int Id { get; set; }

        public Gebruiker? Auteur { get; set; }
        public string? Inhoud { get; set; }
        public DateTime? Datum { get; set; }
        public Forum? Forum { get; set; }
    }
}