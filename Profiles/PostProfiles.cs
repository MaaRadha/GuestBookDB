using AutoMapper;
using FeedBackWebApi.DTO.PostCommentDTOs;
using FeedBackWebApi.Models;

namespace FeedBackWebApi.Profiles
{
    public class PostProfiles : Profile
    {
        public PostProfiles()
        {
            CreateMap<PostComment, PostReadCommentDto>();
            CreateMap<PostUpdateCommentDto, PostComment>();
            CreateMap<PostCreateCommentDto, PostComment>();
        }
    }
}
