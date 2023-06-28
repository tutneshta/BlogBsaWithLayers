using Api.DAL.Interfaces;
using Api.Domain.Entity;
using Api.Domain.ViewModels.Comments;
using Api.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Api.Service.Implementations
{
    public class CommentService : ICommentService
    {
        public IMapper _mapper;
        private readonly ICommentRepository _commentRepo;
        private readonly UserManager<User> _userManager;

        public CommentService(IMapper mapper, ICommentRepository commentRepo, UserManager<User> userManager)
        {
            _mapper = mapper;
            _commentRepo = commentRepo;
            _userManager = userManager;
        }

        public async Task<Guid> CreateComment(CommentCreateViewModel model, Guid userId)
        {
            var comment = new Comment
            {
                Title = model.Title,
                Body = model.Description,
                Author = model.Author,
                PostId = model.PostId,
                AuthorId = userId,
                AuthorName = _userManager.FindByIdAsync(userId.ToString()).Result.UserName,
            };

            await _commentRepo.AddComment(comment);

            return comment.Id;
        }

        public async Task<CommentEditViewModel> EditComment(Guid id)
        {
            var comment = _commentRepo.GetComment(id);

            var result = new CommentEditViewModel
            {
                Title = comment.Title,
                Description = comment.Body,
                Author = comment.Author,
            };

            return result;
        }

        public async Task EditComment(CommentEditViewModel model, Guid id)
        {
            var comment = _commentRepo.GetComment(id);

            comment.Title = model.Title;
            comment.Body = model.Description;
            comment.Author = model.Author;

            await _commentRepo.UpdateComment(comment);
        }

        public async Task RemoveComment(Guid id)
        {
            await _commentRepo.RemoveComment(id);
        }

        public async Task<List<Comment>> GetComments()
        {
            return _commentRepo.GetAllComments().ToList();
        }
    }
}