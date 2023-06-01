using AutoMapper;
using BlogBsa.DAL.Interfaces;
using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Tags;
using BlogBsa.Service.Interfaces;

namespace BlogBsa.Service.Implementations
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repo;
        private IMapper _mapper;

        public TagService(ITagRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Guid> CreateTag(TagCreateViewModel model)
        {
            var tag = _mapper.Map<Tag>(model);
            await _repo.AddTag(tag);

            return tag.Id;
        }
        public async Task<TagEditViewModel> EditTag(Guid id)
        {
            var tag = _repo.GetTag(id);

            var result = new TagEditViewModel()
            {
                Name = tag.Name
             
            };

            return result;

        }

        public async Task EditTag(TagEditViewModel model, Guid id)
        {
            var tag = _repo.GetTag(id);

            tag.Name = model.Name;
          

            await _repo.UpdateTag(tag);
        }

        public async Task RemoveTag(Guid id)
        {
            await _repo.RemoveTag(id);
        }

        public async Task<List<Tag>> GetTags()
        {
            return _repo.GetAllTags().ToList();
        }

        public async Task<Tag> GetTag(Guid id)
        {
            return _repo.GetTag(id);
        }
    }
}