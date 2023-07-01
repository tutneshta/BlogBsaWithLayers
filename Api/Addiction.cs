
using AutoMapper;
using BlogBsa.DAL.Interfaces;
using BlogBsa.DAL.Repositories;
using BlogBsa.Service.Implementations;
using BlogBsa.Service.Interfaces;


namespace Api
{
    public static class Addiction
    {
        public static void AddAddiction(WebApplicationBuilder builder, IMapper mapper1)
        {
            builder.Services

                .AddScoped<ITagService, TagService>()
                .AddScoped<ITagRepository, TagRepository>()

                .AddScoped<ICommentService, CommentService>()
                .AddScoped<ICommentRepository, CommentRepository>()

                .AddScoped<IPostRepository, PostRepository>()
                .AddScoped<IPostService, PostService>()

                .AddScoped<IAccountService, AccountService>()

                .AddScoped<ICommentRepository, CommentRepository>()
                .AddScoped<ICommentService, CommentService>();




        }

    }
}