using AutoMapper;
using BlogBsa.DAL.Interfaces;
using BlogBsa.DAL.Repositories;
using BlogBsa.Service.Implementations;
using BlogBsa.Service.Interfaces;
using NLog.Extensions.Logging;

namespace BlogBsa
{
    public static class Addiction
    {
        public static void AddAddiction(WebApplicationBuilder builder, IMapper mapper1)
        {
            builder.Services
                .AddSingleton(mapper1)
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ITagRepository, TagRepository>()
                .AddTransient<IPostRepository, PostRepository>()
                .AddTransient<IAccountService, AccountService>()
                .AddTransient<ICommentService, CommentService>()
                .AddTransient<IHomeService, HomeService>()
                .AddTransient<IPostService, PostService>()
                .AddTransient<ITagService, TagService>()
                .AddTransient<IRoleService, RoleService>();
  
        }

    }
}