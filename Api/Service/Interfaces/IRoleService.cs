using Api.Domain.Entity;
using Api.Domain.ViewModels.Roles;

namespace Api.Service.Interfaces
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