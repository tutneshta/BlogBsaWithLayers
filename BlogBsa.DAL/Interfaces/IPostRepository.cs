using BlogBsa.Domain.Entity;

namespace BlogBsa.DAL.Interfaces;

public interface IPostRepository
{
    List<Post> GetAllPosts();
    Post GetPost(Guid id);
    Task AddPost(Post post);
    Task UpdatePost(Post post);
    Task RemovePost(Guid id);
    Task<bool> SaveChangesAsync();
}