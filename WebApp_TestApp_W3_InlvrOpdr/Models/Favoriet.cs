namespace WebApp_TestApp_W3_InlvrOpdr.Models
{
    public class Favoriet
    {
        public int Id { get; set; }

        public int GebruikerId { get; set; } // Dit is de GebruikerId eigenschap
        public Gebruiker Eigenaar { get; set; }
        public ICollection<Postzegel> FavorietePostzegels { get; set; } = new HashSet<Postzegel>();
    }
}
