﻿using SocialNetwork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entites
{
    public class Comment:BaseAuditableEntity
    {
        public string Content { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public IEnumerable<Like> Likes { get; set; }

    }
}
