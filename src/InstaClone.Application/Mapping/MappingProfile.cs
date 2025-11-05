using AutoMapper;
using InstaClone.Core.DTOs;
using InstaClone.Core.Entities;

namespace InstaClone.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, PostDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User != null ? src.User.Username : ""))
            .ForMember(dest => dest.UserProfilePictureUrl, opt => opt.MapFrom(src => src.User != null ? src.User.ProfilePictureUrl : null))
            .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.Likes.Count))
            .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Comments.Count))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

        CreateMap<CreatePostDto, Post>();

        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User != null ? src.User.Username : ""));

        CreateMap<CreateCommentDto, Comment>();
    }
}
