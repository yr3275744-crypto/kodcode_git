using ECommerceApi.Models;

namespace ECommerceApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllWithCategoryAsync();
    Task<IEnumerable<Category>> GetCategoriesWithFullTreeAsync();
    Task<IEnumerable<Product>> SearchAsync(string? searchTerm, int?
    categoryId, decimal? minPrice, decimal? maxPrice);
    //Task<IEnumerable<Product>> GetSortedAsync(string? sortBy, bool descending);
    //Task<IEnumerable<object>> GetProductRatingsAsync();
    //Task<IEnumerable<object>> GetProductCountByCategoryAsync();
    //Task<(IEnumerable<Product> Products, int TotalCount)> GetPagedAsync(int 
    //    page, int pageSize);
}