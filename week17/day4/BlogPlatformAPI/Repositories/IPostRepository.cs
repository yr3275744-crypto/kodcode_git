using BlogPlatformAPI.Models;

namespace BlogPlatformAPI.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetPostsTreeAsync();
    Task<IEnumerable<Post>> SearchPublishedPosts(
        int? authorId,
        DateTime? minPublishedDate,
        DateTime? maxPublishedDate
        );
    Task<IEnumerable<Post>> Sort(
        string? title,
        string? PublishedDate,
        bool? descending);
    Task<IEnumerable<Post>> TitleAndCommentCountPerPost();


}