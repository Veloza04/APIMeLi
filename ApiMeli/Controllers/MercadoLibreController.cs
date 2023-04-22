using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MercadoLibreController : ControllerBase
{
    private readonly MercadoLibreAPI api;

    public MercadoLibreController(MercadoLibreAPI api)
    {
        this.api = api;
    }

    [HttpGet]
    public async Task<IEnumerable<MercadoLibreResult>> Search(string query)
    {
        var results = await api.Search(query);
        return results;
    }
}
