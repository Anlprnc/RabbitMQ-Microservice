using CommentService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentService.Services.CommentService
{
    public class CommentServices : ICommentService
    {
        private readonly AppDbContext _context;

        public CommentServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            if (comment is not null)
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            return comment;
        }

        public async Task<Post> ExistPost(string postId)
        {
            return await _context.Posts.SingleOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<IEnumerable<Comment>> GetCommentByPostId(string postId)
        {
            return await _context.Comments.Where(x => x.PostId == postId).ToListAsync();
        }
    }
}