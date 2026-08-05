using ECommerceApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using ECommerceApi.Models;

namespace ECommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;
    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var result = await _repository.GetCategoriesWithFullTreeAsync();
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Product>>> Search(
        [FromQuery] string? searchTerm,
        [FromQuery] int? categoryId,
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice)
    {
        var result = await _repository.SearchAsync(searchTerm, categoryId, minPrice, maxPrice);
        return Ok(result);
    }

}
