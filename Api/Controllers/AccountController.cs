﻿using BlogBsa.Domain.Entity;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;
using BlogBsa.Domain.ViewModels.Users;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;

        public AccountController(IAccountService accountService, UserManager<User> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetUsers")]
        public Task<List<User>> GetUsers()
        {
            var users = _accountService.GetAccounts();

            return Task.FromResult(users.Result);
        }

        /// <summary>
        /// Авторизация Аккаунта
        /// </summary>
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(UserLoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                throw new ArgumentNullException("Запрос не корректен");

            var result = await _accountService.Login(model);

            if (!result.Succeeded)
                throw new AuthenticationException("Введенный пароль не корректен или не найден аккаунт");

            var user = await _userManager.FindByEmailAsync(model.Email);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            if (roles.Contains("Администратор"))
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, "Администратор"));
            }
            else
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.First()));
            }

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return StatusCode(200);
        }

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserRegisterViewModel model)
        {
            var result = await _accountService.Register(model);

            return StatusCode(result.Succeeded ? 201 : 204);
        }

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(UserEditViewModel model)
        {
            var result = await _accountService.EditAccount(model);

            if (result.Succeeded)
                return StatusCode(201);
            else
                return StatusCode(204);
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemoveUser")]
        public async Task<IActionResult> RemoveUser(Guid id)
        {
            await _accountService.RemoveAccount(id);

            return StatusCode(201);
        }

    }
}