using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class MercadoLibreAPI
{
    private readonly string baseUrl = "https://api.mercadolibre.com/sites/MCO/search?q=";

    public async Task<IEnumerable<MercadoLibreResult>> Search(string query)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(baseUrl + query);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<JObject>(json)["results"]
                .Select(item => new MercadoLibreResult
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
