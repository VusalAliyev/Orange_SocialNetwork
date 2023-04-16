using MediatR;
using SocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
    {
        private readonly AppDbContext _context;

        public UpdateCommentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedComment=_context.Comments.FirstOrDefault(c=>c.Id == request.Id);
            updatedComment.Content= request.Content;

            _context.SaveChanges();

            return new UpdateCommentCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
