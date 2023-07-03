using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Roles;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Получение всех ролей
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetRoles")]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _roleService.GetRoles();
            
            return roles;
        }

        /// <summary>
        /// Добавление роли
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(RoleCreateViewModel model)
        {
            await _roleService.CreateRole(model);

            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование роли
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        [Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditRole")]
        public async Task<IActionResult> EditRole(RoleEditViewModel model)
        {
            await _roleService.EditRole(model);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// /// <remarks>
        /// need administrator rights</remarks>
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemoveRole")]
        public async Task<IActionResult> RemoveRole(Guid id)
        {
            await _roleService.RemoveRole(id);

            return StatusCode(201);
        }
    }
}
