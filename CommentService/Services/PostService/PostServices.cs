using CommentService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentService.Services.PostService
{
    public class PostServices : IPostService
    {
        private readonly AppDbContext _context;

        public PostServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Post> AddPost(Post post)
        {
            if (post is not null)
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
            }
            return post;
        }

        public async Task<Post> GetPostById(string Id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}