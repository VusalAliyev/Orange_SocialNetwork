using SocialNetwork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entites
{
    public class Like:BaseAuditableEntity
    {
        public int? Value { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
