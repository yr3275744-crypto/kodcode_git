using BlogPlatformAPI.Models;

namespace BlogPlatformAPI.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<PostDto>> GetPostsTreeAsync();
    Task<IEnumerable<PostDto>> SearchPublishedPosts(
        int? authorId,
        DateTime? minPublishedDate,
        DateTime? maxPublishedDate
        );
    Task<IEnumerable<PostDto>> Sort(
        bool? title,
        bool? publishedDate,
        bool? descending);
    Task<IEnumerable<object>> TitleAndCommentCountPerPost();

    Task<IEnumerable<PostDto>> Pagination(int page, int pageLength);

}