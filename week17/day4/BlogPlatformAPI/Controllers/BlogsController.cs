using BlogPlatformAPI.Models;
using BlogPlatformAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IPostRepository _postRepository;
    private readonly IAuthorRepository _authorRepository;
    public BlogsController(IPostRepository postRepository, IAuthorRepository authorRepository)
    {
        _postRepository = postRepository;
        _authorRepository = authorRepository;
    }
    [HttpGet]
    public async Task<IEnumerable<PostDto>> GetPostsTreeAsync()
    {
        return await _postRepository.GetPostsTreeAsync();
    }
    [HttpGet("seatch")]
    public async Task<IEnumerable<PostDto>> SearchPublishedPosts(
        int? authorId,
        DateTime? minPublishedDate,
        DateTime? maxPublishedDate
        )
    {
        return await _postRepository.SearchPublishedPosts(authorId, minPublishedDate, maxPublishedDate);
    }
    [HttpGet("sort")]
    public async Task<IEnumerable<PostDto>> Sort(
        bool? title,
        bool? publishedDate,
        bool? descending)
    {
        return await _postRepository.Sort(title, publishedDate, descending);
    }
    [HttpGet("AggregationPerItem")]
    public async Task<IEnumerable<object>> TitleAndCommentCountPerPost()
    {
        return await _postRepository.TitleAndCommentCountPerPost();
    }
    [HttpGet("CommentNumberPerAuthor")]
    public async Task<IEnumerable<object>> CommentNumberPerAuthor()
    {
        return await _authorRepository.CommentNumberPerAuthor();
    }
    [HttpGet("paging")]
    public async Task<IEnumerable<PostDto>> Pagination(int page, int pageLength)
    {
        return await _postRepository.Pagination(page, pageLength);
    }
}