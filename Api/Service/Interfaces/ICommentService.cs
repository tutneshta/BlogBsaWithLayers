using Api.Domain.Entity;
using Api.Domain.ViewModels.Comments;

namespace Api.Service.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateViewModel model, Guid UserId);

        Task RemoveComment(Guid id);

        Task<List<Comment>> GetComments();

        Task<CommentEditViewModel> EditComment(Guid id);

        Task EditComment(CommentEditViewModel model, Guid id);
    }
}