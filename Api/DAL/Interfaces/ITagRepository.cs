using Api.Domain.Entity;

namespace Api.DAL.Interfaces;

public interface ITagRepository
{
    HashSet<Tag> GetAllTags();

    Tag GetTag(Guid id);

    Task AddTag(Tag tag);

    Task UpdateTag(Tag tag);

    Task RemoveTag(Guid id);

    Task<bool> SaveChangesAsync();
}