using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Posts;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace BlogBsa.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public PostController(IPostService postService, UserManager<User> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        /// <summary>
        /// [Get] Метод, показывания поста
        /// </summary>
        [Route("Post/Show")]
        [HttpGet]
        public async Task<IActionResult> ShowPost(Guid id)
        {
            var post = await _postService.ShowPost(id);

            return View(post);
        }

        /// <summary>
        /// [Get] Метод, создания поста
        /// </summary>
        [Route("Post/Create")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreatePost()
        {
            var model = await _postService.CreatePost();

            return View(model);
        }

        /// <summary>
        /// [Post] Метод, создания поста
        /// </summary>
        [Route("Post/Create")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreateViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            model.AuthorId = user.Id;

            if (string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Body))
            {
                ModelState.AddModelError("", "Не все поля заполненны");

                _logger.Error($"Попытка создания поста неудачна. Не все поля заполнены");

                return View(model);
            }

            await _postService.CreatePost(model);

            _logger.Info($"Создан новый пост {model.Title}");

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Get] Метод, редактирования поста
        /// </summary>
        [Route("Post/Edit")]
        [HttpGet]
        public async Task<IActionResult> EditPost(Guid id)
        {
            var model = await _postService.EditPost(id);

            return View(model);
        }

        /// <summary>
        /// [Post] Метод, редактирования поста
        /// </summary>
        [Authorize]
        [Route("Post/Edit")]
        [HttpPost]
        public async Task<IActionResult> EditPost(PostEditViewModel model, Guid Id)
        {
            if (string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Body))
            {
                ModelState.AddModelError("", "Не все поля заполненны");

                _logger.Error($"Попытка редактирования поста неудачна. Не все поля заполнены");

                return View(model);
            }

            await _postService.EditPost(model, Id);

            _logger.Info($"Отредактирован пост {model.Title}");

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Get] Метод, удаления поста
        /// </summary>
        [HttpGet]
        [Route("Post/Remove")]
        public async Task<IActionResult> RemovePost(Guid id, bool confirm = true)
        {
            if (confirm)

                await RemovePost(id);

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Post] Метод, удаления поста
        /// </summary>
        [HttpPost]
        [Route("Post/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        public async Task<IActionResult> RemovePost(Guid id)
        {
            await _postService.RemovePost(id);

            _logger.Info($"удален пост с id: {id}");

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Get] Метод, получения всех постов
        /// </summary>
        [HttpGet]
        [Route("Post/Get")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetPosts();

            return View(posts);
        }
    }
}