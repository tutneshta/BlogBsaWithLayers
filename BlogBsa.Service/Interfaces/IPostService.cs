using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Posts;

namespace BlogBsa.Service.Interfaces
{
    public interface IPostService
    {
        Task<PostCreateViewModel> CreatePost();
        Task<Guid> CreatePost(PostCreateViewModel model);
        Task<PostEditViewModel> EditPost(Guid Id);
        Task EditPost(PostEditViewModel model, Guid Id);
        Task RemovePost(Guid id);
        Task<List<Post>> GetPosts();
        Task<Post> ShowPost(Guid id);
    }
}
