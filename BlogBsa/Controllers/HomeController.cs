using AutoMapper;
using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace BlogBsa.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public HomeController(IMapper mapper, IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            await _homeService.GenerateData();

            return View(new MainViewModel());
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

                    _logger.Error($"Произошла ошибка - {statusCode}\n{viewName}");

                    return View("402");
                }
                else
                    return View("500");
            }
            return View("500");
        }
    }
}