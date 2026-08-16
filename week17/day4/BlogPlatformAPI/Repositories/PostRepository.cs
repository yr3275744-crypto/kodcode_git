using BlogPlatformAPI.Data;
using BlogPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatformAPI.Repositories;

public class PostRepository : IPostRepository
{
    private readonly BlogPlatformDbContext _dbContext;
    public PostRepository(BlogPlatformDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    private IQueryable<PostDto> CreatePostsDto(IQueryable<Post> posts)
    {
        return posts
            .Select(p => new PostDto
            (
                p.Id,
                p.AuthorId,
                p.Title,
                p.Body,
                new AuthorDto
                {
                    Id = p.Author.Id,
                    FullName = p.Author.FullName,
                    Email = p.Author.Email,
                    JoinedDate = p.Author.JoinedDate
                },
                p.Comments.Select(c => new CommentDto
                {
                    Id = c.Id,
                    CommenterName = c.CommenterName,
                    Text = c.Text,
                    CreatedAt = c.CreatedAt
                }
                )
                .ToList()
            )
            );
    }
    public async Task<IEnumerable<PostDto>> GetPostsTreeAsync()
    {
        IQueryable<Post> posts = _dbContext.Posts;
        return await CreatePostsDto(posts).ToListAsync();

    }
    public async Task<IEnumerable<PostDto>> SearchPublishedPosts(
    int? authorId,
    DateTime? minPublishedDate,
    DateTime? maxPublishedDate
    )
    {
        IQueryable<Post> postsQuery = _dbContext.Posts
            .Where(p => p.IsPublished == true);
        if (authorId.HasValue)
        {
            postsQuery = postsQuery
                .Where(p => p.AuthorId == authorId);
        }
        if (minPublishedDate.HasValue)
        {
            postsQuery = postsQuery
                .Where(p => p.PublishedDate >= minPublishedDate);
        }
        if (maxPublishedDate.HasValue)
        {
            postsQuery = postsQuery
                .Where(p => p.PublishedDate <= maxPublishedDate);
        }
        return await CreatePostsDto(postsQuery)
            .ToListAsync();
    }
    public async Task<IEnumerable<PostDto>> Sort(
        bool? title,
        bool? publishedDate,
        bool? descending)
    {
        IQueryable<Post> postsQuery = _dbContext.Posts;
        if (title == true && descending == true)
        {
            postsQuery = postsQuery
                .OrderByDescending(p => p.Title);
        }
        else if (title == true)
        {
            postsQuery = postsQuery
                .OrderBy(p => p.Title);
        }
        if (publishedDate == true && descending == true)
        {
            postsQuery = postsQuery
                .OrderByDescending(p => p.PublishedDate);
        }
        else if (publishedDate == true)
        {
            postsQuery = postsQuery
                .OrderBy(p => p.PublishedDate);
        }
        return await CreatePostsDto(postsQuery)
            .ToListAsync();
    }
    public async Task<IEnumerable<object>> TitleAndCommentCountPerPost()
    {
        var postsQuery = _dbContext.Posts
            .Select(p => new
            {
                Title = p.Title,
                CommentCount = p.Comments.Count
            });
        return await postsQuery.ToListAsync();
    }
    public async Task<IEnumerable<PostDto>> Pagination(int page, int pageLength)
    {
        IQueryable<Post> postsQuery = _dbContext.Posts
            .OrderBy(p => p.Id)
            .Skip((page - 1) * pageLength)
            .Take(pageLength);
        return await CreatePostsDto(postsQuery).ToListAsync();
    }

}