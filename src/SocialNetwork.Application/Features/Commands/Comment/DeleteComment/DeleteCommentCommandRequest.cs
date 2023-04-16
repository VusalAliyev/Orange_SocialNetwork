using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandRequest:IRequest<DeleteCommentCommandResponse>
    {
        public int Id { get; set; }
    }
}
