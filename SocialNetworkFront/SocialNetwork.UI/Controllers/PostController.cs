using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Commands.Post.CreatePost;
using SocialNetwork.Application.Features.Queries.Post.GetAllPost;
using SocialNetwork.Domain.Entites;
using SocialNetwork.UI.Services.Interfaces;

namespace SocialNetwork.UI.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        public async Task<IActionResult> Index()
        {
            List<Post> posts;

            try
            {
                posts = await _postService.GetAll();
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }

            return View(posts);
        }

           
        public async Task<IActionResult> AddPost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(CreatePostCommandRequest createPostCommandRequest)
        {
            _postService.CreatePost(createPostCommandRequest);

            return RedirectToAction(nameof(Index));
        }

    }
}
