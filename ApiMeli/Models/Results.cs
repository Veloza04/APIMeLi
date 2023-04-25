using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIMeli.Models
{
    public class Results
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Permalink { get; set; }

    }
}
