using Api.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL
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