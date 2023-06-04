using BlogBsa.Domain.ViewModels.Tags;
using System.ComponentModel.DataAnnotations;

namespace BlogBsa.Domain.ViewModels.Posts
{
    public class PostEditViewModel
    {
        public Guid id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string? Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string? Body { get; set; }

        [Display(Name = "Теги", Prompt = "Теги")]
        public List<TagViewModel>? Tags { get; set; }
    }
}