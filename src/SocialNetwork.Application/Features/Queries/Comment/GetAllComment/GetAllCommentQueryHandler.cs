using MediatR;
using SocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Queries.Comment.GetAllComment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQueryRequest, List<GetAllCommentQueryResponse>>
    {
        private readonly AppDbContext _context;

        public GetAllCommentQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllCommentQueryResponse>> Handle(GetAllCommentQueryRequest request, CancellationToken cancellationToken)
        {
            return _context.Comments.Select(c => new GetAllCommentQueryResponse
            {
                Content = c.Content,
                UserId = c.UserId
            }).ToList();
        }
    }
}
