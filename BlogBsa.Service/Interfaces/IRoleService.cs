using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Roles;

namespace BlogBsa.Service.Interfaces
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateViewModel model);

        Task EditRole(RoleEditViewModel model);

        Task RemoveRole(Guid id);

        Task<List<Role>> GetRoles();

        Task<Role?> GetRole(Guid id);
    }
}