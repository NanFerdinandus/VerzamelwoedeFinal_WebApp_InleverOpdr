namespace WebApp_TestApp_W3_InlvrOpdr.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string? CategorieNaam { get; set; }
        public string? Beschrijving { get; set; }
        public Postzegel? Postzegel { get; set; }
        public int? PostzegelId { get; set; }
        public Gebruiker? Eigenaar { get; set; }
    }
}
