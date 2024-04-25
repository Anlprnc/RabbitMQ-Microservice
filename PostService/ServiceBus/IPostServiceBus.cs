using PostService.Models;

namespace PostService.ServiceBus
{
    public interface IPostServiceBus
    {
        void PublishNewPost(Post post);
    }
}