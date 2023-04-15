using MediatR;
using SocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Queries.Post.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQueryRequest, GetPostByIdQueryResponse>
    {
        private readonly AppDbContext _context;

        public GetPostByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetPostByIdQueryResponse> Handle(GetPostByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == request.Id);

            return new GetPostByIdQueryResponse
            {
                ContentPhoto = post.ContentPhoto,
                ContentText = post.ContentText
            };
        }
    }
}
