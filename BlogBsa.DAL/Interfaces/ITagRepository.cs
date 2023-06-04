using BlogBsa.Domain.Entity;

namespace BlogBsa.DAL.Interfaces;

public interface ITagRepository
{
    HashSet<Tag> GetAllTags();
    Tag GetTag(Guid id);
    Task AddTag(Tag tag);
    Task UpdateTag(Tag tag);
    Task RemoveTag(Guid id);
    Task<bool> SaveChangesAsync();
}