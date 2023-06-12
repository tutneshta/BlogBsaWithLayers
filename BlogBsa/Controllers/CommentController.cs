using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Comments;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace BlogBsa.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CommentController(ICommentService commentService, UserManager<User> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        // <summary>
        /// [Get] Метод, добавление комментария
        /// </summary>
        [HttpGet]
        [Route("Comment/CreateComment")]
        public IActionResult CreateComment(Guid postId)
        {
            var model = new CommentCreateViewModel() { PostId = postId };

            return View(model);
        }

        // <summary>
        /// [Post] Метод, добавление комментария
        /// </summary>
        [HttpPost]
        [Route("Comment/CreateComment")]
        public async Task<IActionResult> CreateComment(CommentCreateViewModel model, Guid PostId)
        {
            model.PostId = PostId;

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var post = _commentService.CreateComment(model, new Guid(user.Id));

            _logger.Info($"Пользователь {user.UserName} добавил комментарий");

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Get] Метод, редактирования коментария
        /// </summary>
        [Route("Comment/Edit")]
        [HttpGet]
        public async Task<IActionResult> EditComment(Guid id)
        {
            var view = await _commentService.EditComment(id);

            return View(view);
        }

        /// <summary>
        /// [Post] Метод, редактирования коментария
        /// </summary>
        [Authorize]
        [Route("Comment/Edit")]
        [HttpPost]
        public async Task<IActionResult> EditComment(CommentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _commentService.EditComment(model, model.Id);

                _logger.Info($"изменение комментария {model.Title} автор {model.Author}");

                return RedirectToAction("GetPosts", "Post");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");

                _logger.Error($"Попытка редактирования комментария {model.Title} неудачна. Некорректные данные");

                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, удаления коментария
        /// </summary>
        [HttpGet]
        [Route("Comment/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        public async Task<IActionResult> RemoveComment(Guid id, bool confirm = true)
        {
            if (confirm)

                await RemoveComment(id);

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Delete] Метод, удаления коментария
        /// </summary>
        [HttpDelete]
        [Route("Comment/Remove")]
        public async Task<IActionResult> RemoveComment(Guid id)
        {
            await _commentService.RemoveComment(id);

            _logger.Info($"удален комментарий c id: {id.ToString()}");

            return RedirectToAction("GetPosts", "Post");
        }
    }
}