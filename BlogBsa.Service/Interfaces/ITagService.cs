using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Tags;

namespace BlogBsa.Service.Interfaces
{
    public interface ITagService
    {
        Task<Guid> CreateTag(TagCreateRequest model);
        //Task EditTag(TagEditRequest model);
        Task<TagEditRequest> EditTag(Guid id);
        Task EditTag(TagEditRequest model, Guid id);
        Task RemoveTag(Guid id);
        Task<List<Tag>> GetTags();
    }
}
