using BlogPlatformAPI.Models;

namespace BlogPlatformAPI.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<object>> CommentNumberPerAuthor();
    }
}
