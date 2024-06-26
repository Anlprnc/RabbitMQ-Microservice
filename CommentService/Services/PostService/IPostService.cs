using CommentService.Models;

namespace CommentService.Services.PostService
{
    public interface IPostService
    {
        Task<Post> AddPost(Post post);
        Task<Post> GetPostById(string Id);
    }
}