using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Tags;

namespace BlogBsa.Service.Interfaces
{
    public interface ITagService
    {
        Task<Guid> CreateTag(TagCreateRequest model);
        Task EditTag(TagEditRequest model);
        Task RemoveTag(Guid id);
        Task<List<Tag>> GetTags();
    }
}
