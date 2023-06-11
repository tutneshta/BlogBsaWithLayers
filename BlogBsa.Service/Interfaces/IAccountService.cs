using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BlogBsa.Service.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(UserRegisterViewModel model);

        Task<IdentityResult> CreateUser(UserCreateViewModel model);

        Task<SignInResult> Login(UserLoginViewModel model);

        Task EditAccount(UserEditViewModel model);

        Task<UserEditViewModel> EditAccount(Guid id);

        Task RemoveAccount(Guid id);

        Task<List<User>> GetAccounts();

        Task<User> GetAccount(Guid id);

        Task LogoutAccount();
    }
}