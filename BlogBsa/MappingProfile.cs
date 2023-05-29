using AutoMapper;
using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Comments;
using BlogBsa.Domain.ViewModels.Posts;
using BlogBsa.Domain.ViewModels.Tags;
using BlogBsa.Domain.ViewModels.Users;

namespace BlogBsa
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterViewModel, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));

            CreateMap<CommentCreateRequest, Comment>();
            CreateMap<CommentEditRequest, Comment>();
            CreateMap<PostCreateRequest, Post>();
            CreateMap<PostEditViewModel, Post>();
            CreateMap<TagCreateRequest, Tag>();
            CreateMap<TagEditRequest, Tag>();
            CreateMap<UserEditRequest, User>();
        }
    }
}
