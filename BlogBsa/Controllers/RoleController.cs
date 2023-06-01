using AutoMapper;
using BlogBsa.Domain.ViewModels.Roles;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogBsa.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;
        private IMapper _mapper;
        public RoleController(IMapper mapper, IRoleService roleService, ILogger<RoleController> logger)
        {
            _mapper = mapper;
            _roleService = roleService;
            _logger = logger;
        }

        /// <summary>
        /// [Get] Метод, создания тега
        /// </summary>
        [Route("Role/Create")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, создания тега
        /// </summary>
        [Route("Role/Create")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleId = await _roleService.CreateRole(model);
                _logger.LogInformation($"Созданна роль - {model.Name}");
                return RedirectToAction("GetRoles", "Role");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, редактирования тега
        /// </summary>
        [Route("Role/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> EditRole(Guid id)
        {
            var role = _roleService.GetRole(id);
            var view = new RoleEditViewModel { Id = id, Description = role.Result?.Description, Name = role.Result?.Name};
           
            return View(view);
        }

        /// <summary>
        /// [Post] Метод, редактирования тега
        /// </summary>
        [Route("Role/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _roleService.EditRole(model);
                _logger.LogDebug($"Измененна роль - {model.Name}");
                return RedirectToAction("GetRoles", "Role");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, удаления тега
        /// </summary>
        [Route("Role/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> RemoveRole(Guid id, bool isConfirm = true)
        {
            if (isConfirm)
                await RemoveRole(id);
            return RedirectToAction("GetRoles", "Role");
        }

        /// <summary>
        /// [Post] Метод, удаления тега
        /// </summary>
        [Route("Role/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> RemoveRole(Guid id)
        {
            await _roleService.RemoveRole(id);
            _logger.LogDebug($"Удаленна роль - {id}");
            return RedirectToAction("GetRoles", "Role");
        }

        /// <summary>
        /// [Get] Метод, получения всех тегов
        /// </summary>
        [Route("Role/GetRoles")]
        [HttpGet]
        [Authorize(Roles = "Администратор, Модератор")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRoles();
            return View(roles);
        }
    }
}
