using System.ComponentModel.DataAnnotations;

namespace BlogBsa.Domain.ViewModels.Roles
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}