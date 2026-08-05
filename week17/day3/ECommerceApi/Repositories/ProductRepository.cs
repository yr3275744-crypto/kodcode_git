using ECommerceApi.Data;
using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;
        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await _context.products.Include(p => p.Category)
                .Include(p => p.Reviews)
                .ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetCategoriesWithFullTreeAsync()
        {
            return await _context.categories
                .Include(c => c.Products)
                .ThenInclude(p => p.Reviews)
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> SearchAsync(string? searchTerm, int?
            categoryId, decimal? minPrice, decimal? maxPrice)
        {
            IQueryable<Product> query = _context.products.Include(p => p.Category).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice);
            }
            if (maxPrice.HasValue)
            {
                query.Where(p => p.Price <= maxPrice);
            }
            return await query.ToListAsync();
        }

    }
}
