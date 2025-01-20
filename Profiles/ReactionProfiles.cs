using AutoMapper;
using FeedBackWebApi.DTO.PostReactionDTOs;
using FeedBackWebApi.Models;

namespace FeedBackWebApi.Profiles
{
    public class ReactionProfiles : Profile
    {
        public ReactionProfiles()
        {
            CreateMap<PostReaction, PostReadReactionDto>();
            CreateMap<PostUpdataReactionDto, PostReaction>();
            CreateMap<PostCreateReactionDto, PostReaction>();

        }
    }
}
