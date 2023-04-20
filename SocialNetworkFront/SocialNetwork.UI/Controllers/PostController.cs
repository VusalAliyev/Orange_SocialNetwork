using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Queries.Post.GetAllPost;
using SocialNetwork.Domain.Entites;
using SocialNetwork.UI.Services.Interfaces;

namespace SocialNetwork.UI.Controllers
{
    public class PostController : Controller
    {
        private readonly IApiService _apiService;

        public PostController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _apiService.GetAsync<List<GetAllPostQueryResponse>>("api/Posts");
            

            return View(data);
        }
    }
}
