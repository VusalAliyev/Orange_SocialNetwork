using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Queries.Post.GetAllPost
{
    public class GetAllPostQueryRequest : IRequest<List<GetAllPostQueryResponse>>
    {
    }
}
