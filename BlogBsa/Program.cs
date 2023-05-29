using System.Data;
using AutoMapper;
using BlogBsa;
using BlogBsa.DAL;
using BlogBsa.DAL.Interfaces;
using BlogBsa.DAL.Repositories;
using BlogBsa.Domain.Entity;
using BlogBsa.Service.Implementations;
using BlogBsa.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Connect AutoMapper
var mapperConfig = new MapperConfiguration((v) =>
{
    v.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

// Connect DataBase
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection))
    .AddIdentity<User, Role>(opts =>
    {
        opts.Password.RequiredLength = 5;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequireLowercase = false;
        opts.Password.RequireUppercase = false;
        opts.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<BlogDbContext>();


// Services AddSingletons/Transient
builder.Services
    .AddSingleton(mapper)
    .AddTransient<ICommentRepository, CommentRepository>()
    .AddTransient<ITagRepository, TagRepository>()
    .AddTransient<IPostRepository, PostRepository>()
    .AddTransient<IAccountService, AccountService>()
    .AddTransient<ICommentService, CommentService>()
    .AddTransient<IHomeService, HomeService>()
    .AddTransient<IPostService, PostService>()
    .AddTransient<ITagService, TagService>()
    .AddTransient<IRoleService, RoleService>();

// Connect logger
builder.Logging
    .ClearProviders()
    .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
    .AddConsole();
    //.AddNLog("nlog");


// Start WebApplication
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();