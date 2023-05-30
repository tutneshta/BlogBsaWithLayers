using BlogBsa.API.Data.Models.Response.Posts;

namespace BlogBsa.API.Data.Repositories.IRepositories
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();
        Post GetPost(Guid id);
        Task AddPost(Post post);
        Task UpdatePost(Post post);
        Task RemovePost(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
