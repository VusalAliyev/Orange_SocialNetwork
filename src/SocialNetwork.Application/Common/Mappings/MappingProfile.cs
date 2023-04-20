using AutoMapper;
using SocialNetwork.Application.Features.Queries.Post.GetAllPost;
using SocialNetwork.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, GetAllPostQueryResponse>().ReverseMap();
        }
    }
}
