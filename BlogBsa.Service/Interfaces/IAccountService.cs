﻿using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Users;
using Microsoft.AspNetCore.Identity;

namespace BlogBsa.Service.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(UserRegisterViewModel model);
        Task<SignInResult> Login(UserLoginViewModel model);
        Task<IdentityResult> EditAccount(UserEditViewModel model);
        Task<UserEditViewModel> EditAccount(Guid id);
        Task RemoveAccount(Guid id);
        Task<List<User>> GetAccounts();
        Task LogoutAccount();
    }
}