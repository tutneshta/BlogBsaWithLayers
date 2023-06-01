using AutoMapper;
using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Users;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogBsa.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;


        public AccountController(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IAccountService accountService)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;

        }

        [Route("Account/Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Account/Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Login(model);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        /// <summary>
        /// [Get] Метод, создания пользователя
        /// </summary>
        [Route("Account/Create")]
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }


        /// <summary>
        /// [Post] Метод, создания пользователя
        /// </summary>
        [Route("Account/Create")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.CreateUser(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetAccounts", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// [Get] Метод, регистрации
        /// </summary>
        [Route("Account/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// [Post] Метод, регистрации
        /// </summary>
        [Route("Account/Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Register(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// [Get] Метод, редактирования
        /// </summary>
        [Route("Account/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> EditAccount(Guid id)
        {
            var model = await _accountService.EditAccount(id);
            return View(model);
        }

        /// <summary>
        /// [Post] Метод, редактирования
        /// </summary>
        [Route("Account/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> EditAccount(UserEditViewModel model)
        {
            var result = await _accountService.EditAccount(model);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAccounts", "Account");
            }
            else
            {
                ModelState.AddModelError("", $"{result.Errors.First().Description}");
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, удаление аккаунта
        /// </summary>
        [Route("Account/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> RemoveAccount(Guid id, bool confirm = true)
        {
            if (confirm)
                await RemoveAccount(id);
            return RedirectToAction("GetAccounts", "Account");
        }

        /// <summary>
        /// [Post] Метод, удаление аккаунта
        /// </summary>
        [Route("Account/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> RemoveAccount(Guid id)
        {
            await _accountService.RemoveAccount(id);

            return RedirectToAction("GetAccounts", "Account");
        }

        /// <summary>
        /// [Post] Метод, выхода из аккаунта
        /// </summary>
        [Route("Account/Logout")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LogoutAccount(Guid id)
        {
            await _accountService.LogoutAccount();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// [Get] Метод, получения всех пользователей
        /// </summary>
        [Route("Account/Get")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var users = await _accountService.GetAccounts();

            return View(users);
        }

        /// <summary>
        /// [Get] Метод, просмотра
        /// </summary>
        [Route("Account/Details")]
        [Authorize(Roles = "Администратор, Модератор")]

        [HttpGet]
        public async Task<IActionResult> DetailsAccount(Guid id)
        {
            var model = await _accountService.GetAccount(id);
            return View(model);
        }
    }
}
