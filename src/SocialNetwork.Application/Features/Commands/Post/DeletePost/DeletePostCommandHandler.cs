using MediatR;
using SocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Post.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest, DeletePostCommandResponse>
    {
        private readonly AppDbContext _context;

        public DeletePostCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeletePostCommandResponse> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedPost = _context.Posts.FirstOrDefault(p => p.Id == request.Id);
            _context.Posts.Remove(deletedPost);

            await _context.SaveChangesAsync();

            return new DeletePostCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
