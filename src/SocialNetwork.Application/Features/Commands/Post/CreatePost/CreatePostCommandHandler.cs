using MediatR;
using SocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Post.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        private readonly AppDbContext _context;

        public CreatePostCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
           await _context.Posts.AddAsync(new()
            {
                  ContentPhoto = request.ContentPhoto,
                  ContentText = request.ContentText,
                  UserId = request.UserId,
            });
            _context.SaveChangesAsync();
            return new CreatePostCommandResponse
            {
                IsSuccess = true
            };

        }
    }
}
