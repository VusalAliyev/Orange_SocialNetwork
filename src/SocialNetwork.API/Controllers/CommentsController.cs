using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Commands.Comment.CreateComment;
using SocialNetwork.Application.Features.Commands.Comment.UpdateComment;
using SocialNetwork.Application.Features.Commands.Post.DeletePost;
using SocialNetwork.Application.Features.Queries.Comment.GetAllComment;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCommentQueryRequest requestModel)
        {
            List<GetAllCommentQueryResponse> comments = await _mediator.Send(requestModel);
            return Ok(comments);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCommentCommandRequest requestModel)
        {
            CreateCommentCommandResponse comment = await _mediator.Send(requestModel);
            return Ok(comment);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentCommandRequest requestModel)
        {
            UpdateCommentCommandResponse comment = await _mediator.Send(requestModel);
            return Ok(comment);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeletePostCommandRequest requestModel)
        {
            DeletePostCommandResponse comment = await _mediator.Send(requestModel);
            return Ok(comment);
        }
    }
}
