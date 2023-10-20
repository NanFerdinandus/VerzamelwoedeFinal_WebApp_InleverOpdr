namespace WebApp_TestApp_W3_InlvrOpdr.Models
{
    public class Forum
    {
        public int Id { get; set; }

        public string? Naam { get; set; }
        public string? Beschrijving { get; set; }
        public ICollection<Bericht>? Berichten { get; set; } = new HashSet<Bericht>();
    }
}
