using BlogPlatformAPI.Data;
using BlogPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatformAPI.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BlogPlatformDbContext _dbContext;
    public AuthorRepository(BlogPlatformDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<object>> CommentNumberPerAuthor()
    {
        var query = _dbContext.Posts
            .GroupBy(p => p.AuthorId)
            .Select(g => new
            {
                AuthorId = g.Key,
                CommentsCount = g.Sum(p => p.Comments.Count)
            });
        return await query.ToListAsync();
    }
}