using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Commands.Post.CreatePost;
using SocialNetwork.Application.Features.Commands.Post.DeletePost;
using SocialNetwork.Application.Features.Commands.Post.UpdatePost;
using SocialNetwork.Application.Features.Queries.Post.GetAllPost;
using SocialNetwork.Application.Features.Queries.Post.GetPostById;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPostQueryRequest requestModel)
        {
            List<GetAllPostQueryResponse> posts = await _mediator.Send(requestModel);
            return Ok(posts);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetPostByIdQueryRequest requestModel)
        {
            GetPostByIdQueryResponse post = await _mediator.Send(requestModel);
            return Ok(post);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostCommandRequest requestModel)
        {
            CreatePostCommandResponse post = await _mediator.Send(requestModel);
            return Ok(post);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeletePostCommandRequest requestModel)
        {
            DeletePostCommandResponse post= await _mediator.Send(requestModel);
            return Ok("Post Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdatePostCommandRequest requestModel)
        {
            UpdatePostCommandResponse post=await _mediator.Send(requestModel);
            return Ok(post);
        }
    }
}
