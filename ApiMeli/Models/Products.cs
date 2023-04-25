using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIMeli.Models
{
    public class Products

    {
        private readonly string baseUrl = "https://api.mercadolibre.com/sites/MCO/search?q=";


        public async Task<IEnumerable<Results>> Search(string search)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseUrl + search);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<JObject>(json)["results"].Select(item => new Results
                {
                    Id = item.Value<string>("id"),
                    Title = item.Value<string>("title"),
                    Price = item.Value<decimal>("price"),
                    Permalink = item.Value<string>("permalink")
                });

                return results;
            }
        }
    }
}
