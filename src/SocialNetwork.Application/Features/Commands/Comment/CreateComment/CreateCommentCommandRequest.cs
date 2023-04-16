using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandRequest:IRequest<CreateCommentCommandResponse>
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
    }
}
