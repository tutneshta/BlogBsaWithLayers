using Api.Domain.Entity;
using Api.Domain.ViewModels.Posts;

namespace Api.Service.Interfaces
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