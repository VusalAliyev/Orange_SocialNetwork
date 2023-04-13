using SocialNetwork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entites
{
    public class Post:BaseAuditableEntity
    {
        public string ContentText { get; set; }
        public string ContentPhoto { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Like> Likes { get; set; }

    }
}
