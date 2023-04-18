using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ApiMeli.Models; 

namespace ApiMeli
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string url = "https://api.mercadolibre.com/sites/MCO/search?q=corps";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Results result = JsonConvert.DeserializeObject<Results>(content);
                foreach (var item in result.results)
                {
                    Console.WriteLine("ID: " + item.Id);
                    Console.WriteLine("Título: " + item.Title);
                    Console.WriteLine("Precio: " + item.Price);
                    Console.WriteLine("Link: " + item.Permalink);
                    Console.WriteLine("------------------------");
                }
            }

            Console.ReadLine();
        }
    }
}
