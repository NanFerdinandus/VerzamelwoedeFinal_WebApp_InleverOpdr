namespace WebApp_TestApp_W3_InlvrOpdr.Models
{
    public class Postzegel
    {
        public int Id { get; set; }
        public string LandVanHerkomst { get; set; }
        public string Conditie { get; set; }
        public int Uitgiftejaar { get; set; }
        public decimal Waarde { get; set; }

        // Navigatie-eigenschap voor de eigenaar van de postzegel
        public Gebruiker Eigenaar { get; set; }
        public bool IsFavoriet { get; set; }
        public int EigenaarId { get; set; }
       //public ICollection<Categorie> Categorieën { get; set; }

    }
}