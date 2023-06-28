﻿using System.ComponentModel.DataAnnotations;
using Api.Domain.ViewModels.Tags;

namespace Api.Domain.ViewModels.Posts
{
    public class PostCreateViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string AuthorId { get; set; }
        public List<TagViewModel> Tags { get; set; }

        [Required(ErrorMessage = "Поле Заголовок обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле Описание обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string Body { get; set; }
    }
}