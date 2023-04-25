using SocialNetwork.Application.Features.Commands.Post.CreatePost;
using SocialNetwork.Domain.Entites;
using SocialNetwork.UI.Services.Interfaces;
using System.Text.Json;

namespace SocialNetwork.UI.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetAll()
        {
            var response = await _httpClient.GetAsync("http://localhost:3030/api/posts");
            var postJson = await response.Content.ReadAsStringAsync();

            var posts = JsonSerializer.Deserialize<List<Post>>(postJson);

            return posts;
        }
        public async Task<bool> CreatePost(CreatePostCommandRequest createPostCommandRequest)
        {

            var content=new StringContent(JsonSerializer.Serialize(createPostCommandRequest));

            var response = await _httpClient.PostAsync("http://localhost:5030/api/posts",content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<bool>(responseString);

            return responseData;
        }
    }
}
