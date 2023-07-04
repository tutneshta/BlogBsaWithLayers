using BlogBsa.Domain.ViewModels.Posts;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с постами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Получение всех постов
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает список постов</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetPosts")]
        public async Task<IEnumerable<ShowPostViewModel>> GetPosts()
        {
            var posts = await _postService.GetPosts();

            var postsResponse = posts.Select(p => new ShowPostViewModel { Id = p.Id, AuthorId = p.AuthorId, Title = p.Title, Body = p.Body, Tags = p.Tags.Select(_ => _.Name) }).ToList();

            return postsResponse;
        }

        /// <summary>
        /// Добавление поста
        /// </summary>
        /// <response code="200">Возвращает статус ОК</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost(PostCreateViewModel model)
        {
            await _postService.CreatePost(model);

            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование поста
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает статус ОК</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditPost")]
        public async Task<IActionResult> EditPost(PostEditViewModel model)
        {
            await _postService.EditPost(model, model.id);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление поста
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает статус ОК</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemovePost")]
        public async Task<IActionResult> RemovePost(Guid id)
        {
            await _postService.RemovePost(id);

            return StatusCode(201);
        }
    }
}