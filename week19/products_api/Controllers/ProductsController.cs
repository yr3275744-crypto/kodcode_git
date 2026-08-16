using Microsoft.AspNetCore.Mvc;
using products_api.Models;
using products_api.Services;

namespace products_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProducteService _productService;
        public ProductsController(ProducteService producteService)
        {
            _productService = producteService;
        }
        [HttpGet]
        public async Task<List<Producte>> Get() =>
        await _productService.GetAsync();
        
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Producte>> Get(string id)
        {
            var book = await _productService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

    }
}
