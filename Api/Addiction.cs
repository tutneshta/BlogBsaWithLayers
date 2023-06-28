using Api.DAL.Interfaces;
using Api.DAL.Repositories;
using AutoMapper;
using BlogBsa.Service.Implementations;
using BlogBsa.Service.Interfaces;
using AccountService = Api.Service.Implementations.AccountService;
using CommentService = Api.Service.Implementations.CommentService;
using HomeService = Api.Service.Implementations.HomeService;
using IAccountService = Api.Service.Interfaces.IAccountService;
using ICommentService = Api.Service.Interfaces.ICommentService;
using IHomeService = Api.Service.Interfaces.IHomeService;
using IPostService = Api.Service.Interfaces.IPostService;
using IRoleService = Api.Service.Interfaces.IRoleService;
using PostService = Api.Service.Implementations.PostService;
using RoleService = Api.Service.Implementations.RoleService;

namespace Api
{
    public static class Addiction
    {
        public static void AddAddiction(WebApplicationBuilder builder, IMapper mapper1)
        {
            builder.Services

                .AddScoped<ITagService, TagService>();

        }

    }
}