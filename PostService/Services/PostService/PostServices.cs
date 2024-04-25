using PostService.Models;

namespace PostService.Services.PostService
{
    public class PostServices : IPostService
    {
        private readonly AppDbContext _context;

        public PostServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Post> Add(Post post)
        {
            if (post is not null)
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
            }
            return post;
        }

        public Post GetById(string id)
        {
            return _context.Posts.FirstOrDefault(x => x.Id == id);
        }
    }
}