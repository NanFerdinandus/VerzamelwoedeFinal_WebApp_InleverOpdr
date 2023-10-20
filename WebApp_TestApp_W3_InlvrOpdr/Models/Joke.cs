using System.Collections.Generic;

namespace WebApp_TestApp_W3_InlvrOpdr.Models
{
    public class Joke
    {
        public List<string>? categories { get; set; }
        public string? created_at { get; set; }
        public string? icon_url { get; set; }
        public string? id { get; set; }
        public string? updated_at { get; set; }
        public string? url { get; set; }
        public string? value { get; set; }
    }
}