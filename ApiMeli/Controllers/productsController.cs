using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMeli.Models;

namespace APIMeli.Controllers
{
    [Route("Lista")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly Models.Products products;
        public productsController(Models.Products products)
        {
            this.products = products;
        }

        [HttpGet()]
        public async Task<IActionResult> Search(string search)
        {
            var results = await products.Search(search);

            if (results == null)
            {
                return NotFound();
            }

            return Ok(results);
        }
    }
}