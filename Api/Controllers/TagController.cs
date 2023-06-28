
using Api.Domain.Entity;
using Api.Service.Interfaces;
using BlogBsa.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tag = BlogBsa.Domain.Entity.Tag;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagSerive;
       

        public TagController(ITagService tagService)
        {
            _tagSerive = tagService;
           
        }
        /// <summary>
        /// Получение всех тегов
        /// </summary>
       // [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetTags")]
        public async Task<List<Tag>> GetTags()
        {
            var tags = await _tagSerive.GetTags();
            return tags;
        }
    }
}
