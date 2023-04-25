using SocialNetwork.Application.Features.Commands.Post.CreatePost;
using SocialNetwork.Domain.Entites;

namespace SocialNetwork.UI.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAll();
        Task<bool> CreatePost(CreatePostCommandRequest createPostCommandRequest);
    }
}
