using MediatR;
using SocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
    {
        private readonly AppDbContext _context;
        public DeleteCommentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedComment=_context.Comments.FirstOrDefault(c=>c.Id==request.Id);
            _context.Comments.Remove(deletedComment);
            _context.SaveChanges();

            return new DeleteCommentCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
