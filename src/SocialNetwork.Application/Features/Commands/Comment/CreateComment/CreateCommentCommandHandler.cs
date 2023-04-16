using MediatR;
using SocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
    {
        private readonly AppDbContext _context;

        public CreateCommentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _context.Comments.AddAsync(new()
            {
                Content = request.Content,
                PostId = request.PostId,
                UserId = request.UserId
            });

            _context.SaveChanges();

            return new CreateCommentCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
