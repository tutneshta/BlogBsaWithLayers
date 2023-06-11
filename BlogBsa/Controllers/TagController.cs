using AutoMapper;
using BlogBsa.DAL.Interfaces;
using BlogBsa.Domain.ViewModels.Tags;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace BlogBsa.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private IMapper _mapper;
        readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public TagController(IMapper mapper, ITagService tagService)
        {
            _mapper = mapper;
            _tagService = tagService;
        }

        /// <summary>
        /// [Get] Метод, создания тега
        /// </summary>
        [Route("Tag/Create")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, создания тега
        /// </summary>
        [Route("Tag/Create")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> CreateTag(TagCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tagId = _tagService.CreateTag(model);

                _logger.Info($"создан тег - {model.Name}");

                return RedirectToAction("GetTags", "Tag");
            }
            else
            {
                _logger.Error($"Ошибка создания тега - {model.Name}");

                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, редактирования тега
        /// </summary>
        [Route("Tag/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> EditTag(Guid id)
        {
            var view = await _tagService.EditTag(id);

            return View(view);
        }

        /// <summary>
        /// [Post] Метод, редактирования тега
        /// </summary>
        [Route("Tag/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> EditTag(TagEditViewModel model, Guid id)
        {

            if (ModelState.IsValid)
            {
                await _tagService.EditTag(model, id);

                _logger.Info($"Изменен тег - {model.Name}");

                return RedirectToAction("GetTags", "Tag");
                
            }
            else
            {
                _logger.Error($"Ошибка изменения тега - {model.Name}");

                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, удаления тега
        /// </summary>
        [Route("Tag/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> RemoveTag(Guid id, bool isConfirm = true)
        {
            if (isConfirm)
                await RemoveTag(id);
            return RedirectToAction("GetTags", "Tag");
        }

        /// <summary>
        /// [Post] Метод, удаления тега
        /// </summary>
        [Route("Tag/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> RemoveTag(Guid id)
        {
            var tag = await _tagService.GetTag(id);

            await _tagService.RemoveTag(id);

            _logger.Debug($"Удален тег - {tag.Name}");

            return RedirectToAction("GetTags", "Tag");
        }

        /// <summary>
        /// [Get] Метод, получения всех тегов
        /// </summary>
        [Route("Tag/Get")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagService.GetTags();

            return View(tags);
        }

        public async Task<IActionResult> DetailsTag(Guid id)
        {
            var tags = await _tagService.GetTag(id);

            return View(tags);
        }
    }
}