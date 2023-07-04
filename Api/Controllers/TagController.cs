using BlogBsa.Domain.ViewModels.Tags;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tag = BlogBsa.Domain.Entity.Tag;

namespace Api.Controllers
{
    /// <summary>
    /// контроллер для работы с тегами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagSerive;

        public TagController(ITagService tagService)
        {
            _tagSerive = tagService;
        }

        /// <summary>
        /// Получение всех тегов
        /// </summary>
        /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает список тегов</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetTags")]
        public async Task<List<Tag>> GetTags()
        {
            var tags = await _tagSerive.GetTags();
            return tags;
        }

        /// <summary>
        /// Добавление тега
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает статус ОК</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route("AddTag")]
        public async Task<IActionResult> AddTag(TagCreateViewModel model)
        {
            var result = await _tagSerive.CreateTag(model);
            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование тега
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает статус ОК</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditTag")]
        public async Task<IActionResult> EditTag(TagEditViewModel model)
        {
            await _tagSerive.EditTag(model, model.Id);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление тега
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        /// <response code="200">Возвращает статус ОК</response>
        /// <response code="404">Необходимы права администратора</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemoveTag")]
        public async Task<IActionResult> RemoveTag(Guid id)
        {
            await _tagSerive.RemoveTag(id);

            return StatusCode(201);
        }
    }
}