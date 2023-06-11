using BlogBsa.Domain.ViewModels.Roles;
using System.ComponentModel.DataAnnotations;

namespace BlogBsa.Domain.ViewModels.Users
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Поле Имя обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя", Prompt = "Имя")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Поле Фамилия обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия", Prompt = "Фамилия")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Поле Никнейм обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Никнейм", Prompt = "Никнейм")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Поле Почта обязательно для заполнения")]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Поле пароль обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string? NewPassword { get; set; }

        [Display(Name = "Роли")]
        public List<RoleViewModel>? Roles { get; set; }

        public Guid Id { get; set; }
    }
}