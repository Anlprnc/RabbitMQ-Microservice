using CommentService.Models;
using CommentService.Services.PostService;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CommentService.EventProcessing.PostProcessors
{
    public class AddPostEventProcessor : IAddPostEventProcessor
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public AddPostEventProcessor(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task ProcessAddPostEvent(string message)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var postService = scope.ServiceProvider.GetRequiredService<IPostService>();

                var result = DeserialzeMessage(message);

                if (result is not null)
                {
                    await postService.AddPost(result);
                    Console.WriteLine("Post has been added to the database table.");
                }
            }
        }

        private Post DeserialzeMessage(string message)
        {
            var desMes = JsonConvert.DeserializeObject<Post>(message);
            return desMes;
        }
    }
}