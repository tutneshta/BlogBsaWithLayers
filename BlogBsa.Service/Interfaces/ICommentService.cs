using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Comments;

namespace BlogBsa.Service.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateRequest model, Guid UserId);
        Task EditComment(CommentEditRequest model);
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
    }
}
