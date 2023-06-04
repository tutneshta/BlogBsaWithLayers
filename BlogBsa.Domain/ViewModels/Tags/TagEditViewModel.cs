﻿using System.ComponentModel.DataAnnotations;

namespace BlogBsa.Domain.ViewModels.Tags
{
    public class TagEditViewModel
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }
    }
}