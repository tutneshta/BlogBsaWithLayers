using AutoMapper;
using BlogBsa.API.Data.Models.Request.Comments;
using BlogBsa.API.Data.Models.Request.Posts;
using BlogBsa.API.Data.Models.Request.Tags;
using BlogBsa.API.Data.Models.Request.Users;
using BlogBsa.API.Data.Models.Response.Comments;
using BlogBsa.API.Data.Models.Response.Posts;
using BlogBsa.API.Data.Models.Response.Tags;
using BlogBsa.API.Data.Models.Response.Users;

namespace BlogBsa.API.Contracts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));

            CreateMap<CommentCreateRequest, Comment>();
            CreateMap<CommentEditRequest, Comment>();
            CreateMap<PostCreateRequest, Post>();
            CreateMap<PostEditRequest, Post>();
            CreateMap<TagCreateRequest, Tag>();
            CreateMap<TagEditRequest, Tag>();
            CreateMap<UserEditRequest, User>();
        }
    }
}
