﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandRequest:IRequest<UpdateCommentCommandResponse>
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
