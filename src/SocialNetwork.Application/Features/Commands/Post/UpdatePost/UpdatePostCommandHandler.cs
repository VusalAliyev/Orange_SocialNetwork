using MediatR;
using SocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Post.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
    {
        private readonly AppDbContext _context;

        public UpdatePostCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedPost =  _context.Posts.FirstOrDefault(p => p.Id == request.Id);
            updatedPost.ContentText = request.ContentText;
            updatedPost.ContentPhoto = request.ContentPhoto;

            _context.SaveChanges();

            return new UpdatePostCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
