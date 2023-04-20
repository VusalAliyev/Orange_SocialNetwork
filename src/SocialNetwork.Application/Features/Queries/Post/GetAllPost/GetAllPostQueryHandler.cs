using AutoMapper;
using MediatR;
using SocialNetwork.Domain.Entites;
using SocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Queries.Post.GetAllPost
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, List<GetAllPostQueryResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPostQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public GetAllPostQueryHandler(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetAllPostQueryResponse>> Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)
        {
             var posts= _context.Posts.Select(p => new GetAllPostQueryResponse
            {
                ContentText = p.ContentText,
                ContentPhoto = p.ContentPhoto,
            }).ToList();

            _mapper.Map<SocialNetwork.Domain.Entites.Post>(posts);
            return posts;
        }
    }
}
