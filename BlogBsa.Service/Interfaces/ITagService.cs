using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Tags;

namespace BlogBsa.Service.Interfaces
{
    public interface ITagService
    {
        Task<Guid> CreateTag(TagCreateViewModel model);
        //Task EditTag(TagEditViewModel model);
        Task<TagEditViewModel> EditTag(Guid id);
        Task EditTag(TagEditViewModel model, Guid id);
        Task RemoveTag(Guid id);
        Task<List<Tag>> GetTags();
    }
}
