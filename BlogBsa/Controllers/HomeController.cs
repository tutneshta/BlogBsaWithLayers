using AutoMapper;
using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogBsa.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IHomeService _homeService;
        private readonly ILogger<HomeController> _logger;
        private IMapper _mapper;

        public HomeController(RoleManager<Role> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IHomeService homeService, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _homeService = homeService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            await _homeService.GenerateData();

            //int i = 1;
            //Console.WriteLine(5 / (i - 1));


            return View(new MainRequest());
        }

        [Authorize]
        public IActionResult MyPage()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Home/Error")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode == 404 || statusCode == 500)
                {
                    var viewName = statusCode.ToString();
                    _logger.LogWarning($"Произошла ошибка - {statusCode}\n{viewName}");
                    return View(viewName);
                }
                else
                    return View("500");
            }
            return View("500");
        }
    }
}