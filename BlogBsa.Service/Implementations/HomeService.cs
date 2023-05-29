using AutoMapper;
using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Users;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BlogBsa.Service.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public IMapper _mapper;

        public HomeService(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task GenerateData()
        {
            var userAdmin = new UserRegisterViewModel { UserName = "UserAdmin", Email = "UserAdmin@gmail.com", Password = "123456", FirstName = "UserFirstName", LastName = "UserLastName" };
            var userModer = new UserRegisterViewModel { UserName = "UserModer", Email = "UserModer@gmail.com", Password = "123456", FirstName = "UserModerFirstName", LastName = "UserModerLastName" };
            var userRole = new UserRegisterViewModel { UserName = "UserRole", Email = "UserRole@gmail.com", Password = "123456", FirstName = "UserRoleFirstName", LastName = "UserRoleLastName" };

            var user = _mapper.Map<User>(userAdmin);
            var user1 = _mapper.Map<User>(userModer);
            var user2 = _mapper.Map<User>(userRole);

            var roleUser = new Role() { Name = "Пользователь", SecurityLvl = 0 };
            var moderRole = new Role() { Name = "Модератор", SecurityLvl = 1 };
            var adminRole = new Role() { Name = "Администратор", SecurityLvl = 3 };

            await _userManager.CreateAsync(user, userAdmin.Password);
            await _userManager.CreateAsync(user1, userModer.Password);
            await _userManager.CreateAsync(user2, userRole.Password);

            await _roleManager.CreateAsync(roleUser);
            await _roleManager.CreateAsync(moderRole);
            await _roleManager.CreateAsync(adminRole);

            await _userManager.AddToRoleAsync(user, adminRole.Name);
            await _userManager.AddToRoleAsync(user1, moderRole.Name);
            await _userManager.AddToRoleAsync(user2, roleUser.Name);
        }
    }
}
