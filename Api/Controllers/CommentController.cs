﻿using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Comments;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с комментариями
    /// </summary>
    [ApiController]
    [Route("Controller")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;

        public CommentController(ICommentService commentService, UserManager<User> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        /// <summary>
        /// Получение всех комментарий поста
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает список комментариев</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetPostComment")]
        public async Task<IEnumerable<Comment>> GetUsers(Guid id)
        {
            var comment = await _commentService.GetComments();

            return comment.Where(c => c.PostId == id);
        }

        /// <summary>
        /// Создания комментария к посту
        /// </summary>
        /// <response code="200">Возвращает статус ОК</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route("CreateComment")]
        public async Task<IActionResult> CreateComment(CommentCreateViewModel model, Guid postId)
        {
            model.PostId = postId;

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            await _commentService.CreateComment(model, new Guid(user.Id));

            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование комментария
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает статус ОК</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditComment")]
        public async Task<IActionResult> EditComment(CommentEditViewModel model)
        {
            await _commentService.EditComment(model, model.Id);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает статус ОК</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemoveComment")]
        public async Task<IActionResult> RemoveComment(Guid id)
        {
            await _commentService.RemoveComment(id);

            return StatusCode(201);
        }
    }
}