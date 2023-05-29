using System.ComponentModel.DataAnnotations;

namespace BlogBsa.Domain.ViewModels.Roles
{
    public class RoleEditRequest
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Уровень доступа", Prompt = "Уровень")]
        public string? Description { get; set; } = null;
    }
}
