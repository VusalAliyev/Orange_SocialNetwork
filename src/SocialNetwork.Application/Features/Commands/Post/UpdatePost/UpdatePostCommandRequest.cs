using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Post.UpdatePost
{
    public class UpdatePostCommandRequest:IRequest<UpdatePostCommandResponse>
    {
        public int Id { get; set; }
        public string ContentText { get; set; }
        public string ContentPhoto { get; set; }
    }
}
