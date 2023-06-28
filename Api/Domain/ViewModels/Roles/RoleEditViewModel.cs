using System.ComponentModel.DataAnnotations;

namespace Api.Domain.ViewModels.Roles
{
    public class RoleEditViewModel
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string? Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание роли", Prompt = "описание")]
        public string? Description { get; set; } = null;
    }
}