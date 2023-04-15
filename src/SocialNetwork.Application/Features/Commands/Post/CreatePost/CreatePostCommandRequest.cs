using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Post.CreatePost
{
    public class CreatePostCommandRequest:IRequest<CreatePostCommandResponse>
    {
        public string ContentPhoto { get; set; }
        public string ContentText { get; set; }
        public string? UserId { get; set; }
    }
}
