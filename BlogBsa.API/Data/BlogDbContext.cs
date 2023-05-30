using BlogBsa.API.Data.Models.Response.Comments;
using BlogBsa.API.Data.Models.Response.Posts;
using BlogBsa.API.Data.Models.Response.Roles;
using BlogBsa.API.Data.Models.Response.Tags;
using BlogBsa.API.Data.Models.Response.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogBsa.API.Data
{
    public sealed class BlogDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

